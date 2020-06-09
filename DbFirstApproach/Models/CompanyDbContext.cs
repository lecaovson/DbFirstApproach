using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;
using DbFirstApproach.Migrations;

namespace DbFirstApproach.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Migrations.Configuration>()) ;
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}