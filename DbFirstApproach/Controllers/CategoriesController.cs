using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirstApproach.Models;

namespace DbFirstApproach.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}