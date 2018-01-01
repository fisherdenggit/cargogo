namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruckMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trucks", "Driver1Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trucks", "Driver1Name");
        }
    }
}
