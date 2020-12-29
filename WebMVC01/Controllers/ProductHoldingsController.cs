using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC01.Models;

namespace WebMVC01.Controllers
{
    public class ProductHoldingsController : Controller
    {
        private KangtingBizModel db = new KangtingBizModel();

        // GET: ProductHoldings
        public ActionResult Index()
        {
            return View(db.ProductHoldings.ToList());
        }

        // GET: ProductHoldings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHolding productHoldings = db.ProductHoldings.Find(id);
            if (productHoldings == null)
            {
                return HttpNotFound();
            }
            return View(productHoldings);
        }

        // GET: ProductHoldings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductHoldings/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Quantity,ReorderLevel")] ProductHolding productHoldings)
        {
            if (ModelState.IsValid)
            {
                db.ProductHoldings.Add(productHoldings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productHoldings);
        }

        // GET: ProductHoldings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHolding productHoldings = db.ProductHoldings.Find(id);
            if (productHoldings == null)
            {
                return HttpNotFound();
            }
            return View(productHoldings);
        }

        // POST: ProductHoldings/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Quantity,ReorderLevel")] ProductHolding productHoldings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productHoldings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productHoldings);
        }

        // GET: ProductHoldings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductHolding productHoldings = db.ProductHoldings.Find(id);
            if (productHoldings == null)
            {
                return HttpNotFound();
            }
            return View(productHoldings);
        }

        // POST: ProductHoldings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductHolding productHoldings = db.ProductHoldings.Find(id);
            db.ProductHoldings.Remove(productHoldings);
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
