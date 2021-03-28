using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Core.Model;
using Simple.Core.Model.Entity;

namespace Simple_UI.Controllers
{
    public class HomeController : SimpleControllerBase
    {
        SimpleDB db = new SimpleDB();

        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            var db = new SimpleDB();
            var menus = db.Categories.Where(x => x.ParentId == 0).ToList();
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string Email, string Password)
        {
            var db = new SimpleDB();
            var users = db.Users.Where(x => x.Email == Email
                                            && x.Password == Password
                                            && x.IsActive == true
                                            && x.IsAdmin == false).ToList();
            if (users.Count == 1)
            {
                //Giriş Ok
                Session["LoginUserId"] = users.FirstOrDefault().Id;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Kullanıcı veya Parola Hatalı!";
                return View();
            }
        }
        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserId = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}