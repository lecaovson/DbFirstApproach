namespace DbFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "DesImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DesImg");
            DropColumn("dbo.Products", "Description");
        }
    }
}
