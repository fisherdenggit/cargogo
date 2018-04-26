namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MyUsers", "MyWeChatUserOpenID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyUsers", "MyWeChatUserOpenID", c => c.String());
        }
    }
}
