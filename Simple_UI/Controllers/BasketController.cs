using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Core.Model;

namespace Simple_UI.Controllers
{
    public class BasketController : SimpleControllerBase
    {
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int productId, int quantity)
        {
            var db = new SimpleDB();
            db.Baskets.Add(new Simple.Core.Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserId = LoginUserId,
                ProductId = productId,
                Quantity = quantity,
                UserId = LoginUserId
            });
            var rt = db.SaveChanges();
            return Json(rt, JsonRequestBehavior.AllowGet);
        }

        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new SimpleDB();
            var data = db.Baskets.Include("Product").Where(x => x.UserId == LoginUserId).ToList();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new SimpleDB();
            var deleteitem = db.Baskets.Where(x => x.Id == id).FirstOrDefault();
            db.Baskets.Remove(deleteitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}