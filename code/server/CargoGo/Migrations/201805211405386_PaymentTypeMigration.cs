namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTypeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentTypeCode = c.String(),
                        PaymentTypeDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
        }
    }
}
