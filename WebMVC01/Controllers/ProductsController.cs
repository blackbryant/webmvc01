using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC01.Models;

namespace WebMVC01.Controllers
{
    public class ProductsController : Controller
    {
        private KangtingBizModel db = new KangtingBizModel();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,UnitPrice,Description")] Product products)
        {
            db.Database.Log = logmsg => System.Diagnostics.Debug.WriteLine(logmsg); 



            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            db.Database.Log = logmsg => System.Diagnostics.Debug.WriteLine(logmsg);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            int vnumber = (new Random()).Next(1024);
            System.Diagnostics.Debug.WriteLine("\n("+vnumber+") ready:"+BitConverter.ToInt64(products.RowVersion,0));
            ViewBag.vn = vnumber; 

            return View(products);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,UnitPrice,Description,Quantity,RowVersion")] Product products, int vnumber)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(products).State = EntityState.Modified;
                    System.Diagnostics.Debug.WriteLine("\n(" + vnumber + ") ready:" + BitConverter.ToInt64(products.RowVersion, 0));

                    db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("\n(" + vnumber + ") ready:" + BitConverter.ToInt64(products.RowVersion, 0));

                    System.Diagnostics.Debug.WriteLine("====Product SaveChanges====");
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                   System.Diagnostics.Debug.WriteLine("====Exception ====");
                   System.Diagnostics.Debug.WriteLine(""+ex.Message);
                   System.Diagnostics.Debug.WriteLine("" + ex.StackTrace);
                   System.Diagnostics.Debug.WriteLine("====End ====");
                    var entry = ex.Entries.Single();
                    var clientValues = (Product)entry.Entity;
                    var databaseEntry = entry.GetDatabaseValues();
                    var databaseValues = (Product)databaseEntry.ToObject();

                    if (databaseValues.ProductID != clientValues.ProductID)
                        ModelState.AddModelError("ProductID", "Current value: "
                            + databaseValues.ProductID);
                    if (databaseValues.ProductName != clientValues.ProductName)
                        ModelState.AddModelError("ProductName", "Current value: "
                            +   databaseValues.ProductName);
                    if (databaseValues.Description != clientValues.Description)
                        ModelState.AddModelError("Description", "Current value: "
                            +   databaseValues.Description);
                    if (databaseValues.UnitPrice != clientValues.UnitPrice)
                        ModelState.AddModelError("UnitPrice", "Current value: "
                            + String.Format("{0:c}", databaseValues.UnitPrice));
                    if (databaseValues.Quantity != clientValues.Quantity)
                        ModelState.AddModelError("Quantity", "Current value: "
                            + String.Format("{0:c}", databaseValues.Quantity));
                    ModelState.AddModelError(string.Empty, "資料不是最新版本無法更新!");
                    products.RowVersion = databaseValues.RowVersion;
                    ViewBag.vn = vnumber;

                    return View(products);
                }
              
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.Log = logmsg => System.Diagnostics.Debug.WriteLine(logmsg);

            Product products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
