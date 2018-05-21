namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyCode", c => c.String());
            DropColumn("dbo.Companies", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "CompanyName", c => c.String());
            DropColumn("dbo.Companies", "CompanyCode");
        }
    }
}
