namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "MyWeChatUserNickName", c => c.String());
            DropColumn("dbo.MyUsers", "MyUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyUsers", "MyUserName", c => c.String());
            DropColumn("dbo.MyUsers", "MyWeChatUserNickName");
        }
    }
}
