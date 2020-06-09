using DbFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Detail(long? id)
        {
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
    }
}