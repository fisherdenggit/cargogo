namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyUsers", "MobileNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyUsers", "MobileNumber", c => c.String());
        }
    }
}
