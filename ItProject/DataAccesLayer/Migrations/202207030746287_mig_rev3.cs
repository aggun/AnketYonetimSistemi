namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_rev3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Personals", new[] { "CompanyId" });
            AlterColumn("dbo.Personals", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personals", "CompanyId");
            AddForeignKey("dbo.Personals", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Personals", new[] { "CompanyId" });
            AlterColumn("dbo.Personals", "CompanyId", c => c.Int());
            CreateIndex("dbo.Personals", "CompanyId");
            AddForeignKey("dbo.Personals", "CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
