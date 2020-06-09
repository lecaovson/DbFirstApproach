namespace DbFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredValidation4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            AlterColumn("dbo.Products", "BrandID", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "BrandID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandID" });
            AlterColumn("dbo.Products", "BrandID", c => c.Long());
            CreateIndex("dbo.Products", "BrandID");
            AddForeignKey("dbo.Products", "BrandID", "dbo.Brands", "BrandID");
        }
    }
}
