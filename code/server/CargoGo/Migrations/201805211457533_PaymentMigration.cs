namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentDirectionCode = c.String(),
                        CompanyCode = c.String(),
                        PaymentTypeCode = c.String(),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
