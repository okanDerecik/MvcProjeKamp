namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_mig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserNamee", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserNamee");
        }
    }
}
