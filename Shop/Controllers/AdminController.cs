using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.Concrete;

namespace Shop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        CommentRepository commentRepository = new CommentRepository();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Comment(int sayfa=1)
        {
            return View(commentRepository.List().ToPagedList(sayfa,3));
        }
        public ActionResult Delete(int id)
        {
            var delete = commentRepository.GetById(id);
            commentRepository.Delete(delete);

            return RedirectToAction("Comment");
        }
        public ActionResult UserList() 
        {
            var user = db.Users.Where(x => x.Role == "User").ToList();
            return View(user);
        }
        public ActionResult UserDelete(int id)
        {
            var userid = db.Users.Where(x => x.Id == id ).FirstOrDefault();
            db.Users.Remove(userid);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }
    }
}