using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Core.Model;
using Simple.Core.Model.Entity;

namespace Simple_UI.Controllers
{
    public class OrderController : SimpleControllerBase
    {
        // GET: Order
        [Route("Siparisver")]
        public ActionResult AddressList()
        {
            var db = new SimpleDB();
            var data = db.UserAddresses.Where(x => x.UserId == LoginUserId).ToList();
            return View(data);
        }
        
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult CreateUserAddress(UserAddress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserId = LoginUserId;
            entity.IsActive = true;
            entity.UserId = LoginUserId;

            var db = new SimpleDB();
            db.UserAddresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }
        public ActionResult CreateOrder(int id)
        {
            var db = new SimpleDB();


            var sepet = db.Baskets.Include("Product").Where(x => x.UserId == LoginUserId).ToList();
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.CreateUserId = LoginUserId;
            order.StatusId = 2;
            order.TotalProductPrice = sepet.Sum(x => x.Product.Price);
            order.TotalTaxPrice = sepet.Sum(x => x.Product.Tax);
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice;
            order.UserAddressId = id;
            order.UserId = LoginUserId;
            order.OrderProducts = new List<OrderProduct>();

            foreach (var item in sepet)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    CreateDate = DateTime.Now,
                    CreateUserId = LoginUserId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
                db.Baskets.Remove(item);
            }
            db.Orders.Add(order);

            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.Id });
            //var orderid = order.Id;
            //return RedirectToAction("Detail", new { id = orderid });
        }
        public ActionResult Detail(int id)
        {
            var db = new SimpleDB();
            var data = db.Orders
                .Include("OrderProducts")
                .Include("OrderProducts.Product")
                .Include("OrderPayments")
                .Include("Status")
                .Include("UserAddress")
                .Where(x => x.Id == id).FirstOrDefault();

            return View(data);
        }
        [Route("Siparislerim")]
        public ActionResult Index()
        {
            var db = new SimpleDB();
            var data = db.Orders.Include("Status").Where(x => x.UserId == LoginUserId).ToList();
            return View(data);
        }

        public ActionResult Pay(int id)
        {
            var db = new SimpleDB();
            var order = db.Orders.Where(x => x.Id == id).FirstOrDefault();
            order.StatusId = 4;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.Id });
        }
    }
}