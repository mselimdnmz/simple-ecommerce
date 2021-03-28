using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Simple.Core.Model.Entity;

namespace Simple_UI
{
    public class SimpleControllerBase : Controller
    {
        /// <summary>
        /// Kullanıcı Login Kontrolü
        /// </summary>
        public bool IsLogin { get; private set; }
        /// <summary>
        /// Giriş Yapmış Kişinin IDsi
        /// </summary>
        public int LoginUserId { get; private set; }
        /// <summary>
        /// Login User Entity
        /// </summary>
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUserId"]
            // Session["LoginUser"] 
            if (requestContext.HttpContext.Session["LoginUserId"] != null)
            {
                //Kullanıcı Giriş Yapmış
                IsLogin = true;
                LoginUserId = (int)requestContext.HttpContext.Session["LoginUserId"];
                LoginUserEntity = (Simple.Core.Model.Entity.User)requestContext.HttpContext.Session["lOGİNuSER"];
            }
            base.Initialize(requestContext);
        }
    }
}