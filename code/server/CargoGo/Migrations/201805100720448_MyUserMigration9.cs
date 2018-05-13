namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "MobileNumber1", c => c.String());
            DropColumn("dbo.MyUsers", "MobileNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyUsers", "MobileNumber", c => c.String());
            DropColumn("dbo.MyUsers", "MobileNumber1");
        }
    }
}
