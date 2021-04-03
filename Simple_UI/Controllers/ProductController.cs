using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple.Core.Model;

namespace Simple_UI.Controllers
{
    public class ProductController : SimpleControllerBase
    {
        // GET: Product
        [Route("Urun/{title}/{id}")]
        public ActionResult Detail( string title, int id)
        {
            var db = new SimpleDB();
            var prod = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(prod);
        }
    }
}