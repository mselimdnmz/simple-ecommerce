using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Core.Model;

namespace Simple_UI.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        SimpleDB db = new SimpleDB();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            var data = db.Users.Where(x =>
                x.Email == Email &&
                x.Password == Password &&
                x.IsActive == true &&
                x.IsAdmin == true).ToList();
            if (data.Count == 1)
            {
                //Doğru Giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                //Hatalı Giriş
                return View();
            }
        }
    }
}