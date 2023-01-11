namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messageupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsSpam", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsSpam");
            DropColumn("dbo.Messages", "Trash");
        }
    }
}
