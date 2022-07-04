namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_int : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Managers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "CompanyId" });
            AlterColumn("dbo.Managers", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Managers", "CompanyId");
            AddForeignKey("dbo.Managers", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "CompanyId" });
            AlterColumn("dbo.Managers", "CompanyId", c => c.Int());
            CreateIndex("dbo.Managers", "CompanyId");
            AddForeignKey("dbo.Managers", "CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
