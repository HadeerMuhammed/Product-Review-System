namespace Product_Review_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        YourFeedback = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
