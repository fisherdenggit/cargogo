namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyDeliveryAddressMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyDeliveryAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(),
                        CargoDeliveryAddress = c.String(),
                        CargoDeliveryContact = c.String(),
                        CargoDeliveryContactMobile = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompanyDeliveryAddresses");
        }
    }
}
