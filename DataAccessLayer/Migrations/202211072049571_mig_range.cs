namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_range : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillRange", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SkillRange");
        }
    }
}
