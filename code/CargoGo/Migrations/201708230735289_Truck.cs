namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Truck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        TruckID = c.String(nullable: false, maxLength: 128),
                        TruckType = c.String(),
                    })
                .PrimaryKey(t => t.TruckID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trucks");
        }
    }
}
