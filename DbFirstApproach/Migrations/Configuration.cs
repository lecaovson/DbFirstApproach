namespace DbFirstApproach.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbFirstApproach.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbFirstApproach.Models.CompanyDbContext context)
        {
            //context.Brands.AddOrUpdate(new Models.Brand { BrandID = 1, BrandName = "Samsung" });
            //context.Brands.AddOrUpdate(new Models.Brand { BrandID = 2, BrandName = "Iphone" });
            //context.Categories.AddOrUpdate(new Models.Category { CategoryID = 1, CategoryName = "Electronics" });
            //context.Categories.AddOrUpdate(new Models.Category { CategoryID = 2, CategoryName = "Electronics2" });
            //context.Products.AddOrUpdate(new Models.Product
            //{
            //    ProductID = 1,
            //    ProductName = "Samsung Galaxy Mobile",
            //    CategoryID = 1,
            //    DateOfPurchase = DateTime.Now,
            //    Active = true,
            //    Photo = null,
            //    Price = 10000,
            //    AvailabilityStatus = "InStock"
            //});
            //context.Products.AddOrUpdate(new Models.Product
            //{
            //    ProductID = 2,
            //    ProductName = "Samsung Galaxy S10",
            //    CategoryID = 2,
            //    DateOfPurchase = DateTime.Now,
            //    Active = true,
            //    Photo = null,
            //    Price = 10000,
            //    AvailabilityStatus = "InStock"
            //});
        }
    }
}
