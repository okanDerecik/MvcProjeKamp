namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminguncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            DropColumn("dbo.Admins", "AdminName");
            DropColumn("dbo.Admins", "AdminUserNamee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserNamee", c => c.Binary());
            AddColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminMail");
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}
