namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
