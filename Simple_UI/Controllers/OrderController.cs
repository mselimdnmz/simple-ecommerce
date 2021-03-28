using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_UI.Controllers
{
    public class OrderController : SimpleControllerBase
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}