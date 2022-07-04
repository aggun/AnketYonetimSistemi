namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_rev : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            AddColumn("dbo.Admins", "AdminSurname", c => c.String());
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            AddColumn("dbo.Roles", "AdminId", c => c.Int());
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String());
            CreateIndex("dbo.Roles", "AdminId");
            AddForeignKey("dbo.Roles", "AdminId", "dbo.Admins", "AdminId");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "RoleId", c => c.Int());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            DropForeignKey("dbo.Roles", "AdminId", "dbo.Admins");
            DropIndex("dbo.Roles", new[] { "AdminId" });
            AlterColumn("dbo.Admins", "AdminUsername", c => c.Binary());
            DropColumn("dbo.Roles", "AdminId");
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "AdminSurname");
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "RoleId");
        }
    }
}
