namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContractCode = c.String(),
                        ContractDate = c.DateTime(nullable: false),
                        CompanyCode = c.String(),
                        ProductCode = c.String(),
                        ContractAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractExcutedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contracts");
        }
    }
}
