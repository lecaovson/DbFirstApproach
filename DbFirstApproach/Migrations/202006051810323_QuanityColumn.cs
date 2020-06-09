namespace DbFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuanityColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quanity", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quanity");
        }
    }
}
