using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirstApproach.Models;

namespace DbFirstApproach.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDbContext db = new CompanyDbContext();
        // GET: Products
        public ActionResult Index(string search="", string SortColumn="ProductName",string IconClass="fa-sort-asc")
        {
            
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.search = search;

            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if(ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();

            }
            if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();

            }
            if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();

            }
            if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();

            }
            if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();

            }
            if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();

            }
            if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();

            }
            return View(products);
        }
        public ActionResult Details(long? id)
        {
            
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
        
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }
        

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Price,DateOfPurchase,Description,AvailabilityStatus,CategoryID,BrandID,,Active,Photo")] Product p)
        {
           
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    //taking the first file
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(long id)
        {
         
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    existingProduct.Photo = base64String;
                }
              
                existingProduct.ProductName = p.ProductName;
                existingProduct.Price = p.Price;
                existingProduct.DateOfPurchase = p.DateOfPurchase;
                existingProduct.CategoryID = p.CategoryID;
                existingProduct.BrandID = p.BrandID;
                existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                existingProduct.Active = p.Active;
                
                db.SaveChanges();
            }
            return RedirectToAction("Index","Products");
        }
        public ActionResult Delete(long id)
        {
           
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id,Product p)
        {
        
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index","Products");
        }

    }
}