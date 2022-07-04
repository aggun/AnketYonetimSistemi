namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personals", "PersonalPasswordHash", c => c.Binary());
            AddColumn("dbo.Personals", "PersonalPasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personals", "PersonalPasswordSalt");
            DropColumn("dbo.Personals", "PersonalPasswordHash");
        }
    }
}
