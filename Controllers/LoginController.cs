﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    
    public class LoginController : Controller
    {

        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        
        
            public ActionResult Logins()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Logins(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();

            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logins", "Login");
        }
    }
}