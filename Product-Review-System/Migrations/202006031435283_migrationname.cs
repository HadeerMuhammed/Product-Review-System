namespace Product_Review_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationname : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Int(nullable: false),
                        description = c.String(),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "category_id" });
            DropTable("dbo.Products");
        }
    }
}
