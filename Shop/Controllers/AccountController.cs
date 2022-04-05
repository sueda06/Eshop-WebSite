﻿using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        DataContext db = new DataContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email,false);
                Session["Mail"] = bilgiler.Email.ToString();
                Session["Ad"] = bilgiler.Name.ToString();
                Session["Soyad"] = bilgiler.SurName.ToString();
                Session["userId"] = bilgiler.Id.ToString();
                Session["Password"] = bilgiler.Password.ToString();
                Session["RePassword"] = bilgiler.RePassword.ToString();
                return RedirectToAction("Index","Home");
            }
            ViewBag.hata = "Mail Veya Şifre Hatalı";
            return View(data);
        }

        [HttpPost]
        public ActionResult Register(User data)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(data);
                data.Role = "User";
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Hatalı");
            return View("Login",data);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}