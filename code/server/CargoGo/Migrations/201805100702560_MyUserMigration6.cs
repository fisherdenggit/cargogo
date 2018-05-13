namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "Permission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyUsers", "Permission");
        }
    }
}
