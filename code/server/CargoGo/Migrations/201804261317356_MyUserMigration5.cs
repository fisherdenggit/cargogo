namespace CargoGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyUserMigration5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyUsers", "MyWeChatUserOpenID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyUsers", "MyWeChatUserOpenID");
        }
    }
}
