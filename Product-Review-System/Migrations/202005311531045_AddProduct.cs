namespace Product_Review_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddProducts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        description = c.String(),
                        category_id = c.Int(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        no_of_products = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddProducts", "category_id", "dbo.Categories");
            DropIndex("dbo.AddProducts", new[] { "category_id" });
            DropTable("dbo.Categories");
            DropTable("dbo.AddProducts");
        }
    }
}
