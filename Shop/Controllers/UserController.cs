using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        // GET: User
        public ActionResult Update()
        {
            var userName = (string)Session["Mail"];
            var degerler = db.Users.FirstOrDefault(x=>x.Email==userName);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Update(User data)
        {
            var userName = (string)Session["Mail"];
            var user = db.Users.Where(x => x.Email == userName).FirstOrDefault();
            user.Name = data.Name;
            user.SurName = data.SurName;
            user.Email = data.Email;
            user.Password = data.Password;
            user.RePassword = data.Password;
            user.UserName = data.UserName;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
         
        public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(string eposta)
        {
            var mail = db.Users.Where(x => x.Email == eposta).SingleOrDefault();
            if (mail!=null)
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();
                User sifre = new User();
                mail.Password = Convert.ToString(yenisifre);
                mail.RePassword = mail.Password;
                db.SaveChanges();
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "suedakin.07@gmail.com";
                WebMail.Password = "***";
                WebMail.SmtpPort=587;
                WebMail.Send(eposta, "Giriş şifreniz", "Şifreniz" + yenisifre);
                ViewBag.uyari = "Şifreniz başarıyla gönderilmiştir.";
            }
            else
            {
                ViewBag.uyari = "Hata oluştu tekrar deneyiniz";
            }
            return View();
        }
    }
}