namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_rev2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personals", "PersonalPasswordHash");
            DropColumn("dbo.Personals", "PersonalPasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personals", "PersonalPasswordSalt", c => c.Binary());
            AddColumn("dbo.Personals", "PersonalPasswordHash", c => c.Binary());
        }
    }
}
