namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_for_manager : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(maxLength: 20),
                        ManagerSurname = c.String(maxLength: 20),
                        ManagerUsername = c.String(maxLength: 20),
                        ManagerPassword = c.String(maxLength: 100),
                        ManagerMail = c.String(maxLength: 50),
                        ManagerStatus = c.Boolean(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Managers", new[] { "CompanyId" });
            DropTable("dbo.Managers");
        }
    }
}
