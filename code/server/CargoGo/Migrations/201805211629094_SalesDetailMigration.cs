namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesDetailMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OutDate = c.DateTime(nullable: false),
                        CompanyCode = c.String(),
                        ProductCode = c.String(),
                        ContractCode = c.String(),
                        PricePerTon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutWeightAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuationPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuationWeightAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuationSalesAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        InvoiceBooked = c.Boolean(nullable: false),
                        InvoiceCode = c.String(),
                        ShippingPricePerTon = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuationShippingWeightAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingCompanyCode = c.String(),
                        TruckCode = c.String(),
                        TruckDriverMobile = c.String(),
                        Note2 = c.String(),
                        ShippingCostInvoiceBooked = c.Boolean(nullable: false),
                        ShippingCostInvoiceCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesDetails");
        }
    }
}
