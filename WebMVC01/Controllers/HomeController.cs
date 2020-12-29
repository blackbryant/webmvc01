using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebMVC01.Models;

namespace WebMVC01.Controllers
{
    public class HomeController : Controller
    {
        private KangtingBizModel db = new KangtingBizModel();

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Product> products = db.Products;
            return View(products); 
        }

        public ActionResult EditList()
        {
            IEnumerable<Product> products = db.Products;
            return View(products);
        }

        [HttpPost]
        public ActionResult EditList(IEnumerable<Product> products)
        {
            using (var transatction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                foreach(var p in products)
                {
                    System.Diagnostics.Debug.WriteLine(p.ProductID+","+p.Quantity);
                    db.Products.Find(p.ProductID).Quantity = p.Quantity;
                    Thread.Sleep(1000 * 30);
                }
                System.Diagnostics.Debug.WriteLine("SaveChagne()");
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("commit()");
                transatction.Commit();

            }
            return Redirect("EditList");
        }


    }
}