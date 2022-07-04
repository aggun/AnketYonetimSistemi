namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminRole");
        }
    }
}
