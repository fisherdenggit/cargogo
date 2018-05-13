namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "Permission", c => c.Int(nullable: false));
            DropColumn("dbo.MyUsers", "Permission1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyUsers", "Permission1", c => c.Int(nullable: false));
            DropColumn("dbo.MyUsers", "Permission");
        }
    }
}
