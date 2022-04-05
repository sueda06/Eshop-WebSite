using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository CategoryRepository = new CategoryRepository();
        // GET: Category
        public PartialViewResult CategoryList()
        {
            return PartialView(CategoryRepository.List());
        }
        public ActionResult Details(int id)
        {
            var category=CategoryRepository.CategoryDetails(id);
            return View(category);
        }
    }
}