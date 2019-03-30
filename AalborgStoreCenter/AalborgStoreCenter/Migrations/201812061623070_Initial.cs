namespace AalborgStoreCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductDescription = c.String(maxLength: 100),
                        ProductTitle = c.String(nullable: false),
                        ProductImage = c.String(nullable: false),
                        ProductPrice = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        StoreLogo = c.String(nullable: false),
                        LocationImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.SelectedProducts",
                c => new
                    {
                        SelectedProductID = c.Int(nullable: false, identity: true),
                        ListID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SelectedProductID)
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ListID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelectedProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SelectedProducts", "ListID", "dbo.Lists");
            DropForeignKey("dbo.Lists", "UserID", "dbo.Users");
            DropForeignKey("dbo.Products", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.SelectedProducts", new[] { "ProductID" });
            DropIndex("dbo.SelectedProducts", new[] { "ListID" });
            DropIndex("dbo.Lists", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "StoreID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.SelectedProducts");
            DropTable("dbo.Users");
            DropTable("dbo.Lists");
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
