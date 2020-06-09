using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirstApproach.Models;

namespace DbFirstApproach.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}