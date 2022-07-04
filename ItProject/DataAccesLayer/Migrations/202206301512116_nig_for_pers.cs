namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nig_for_pers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyAnswers", "PersonalId", c => c.Int());
            CreateIndex("dbo.SurveyAnswers", "PersonalId");
            AddForeignKey("dbo.SurveyAnswers", "PersonalId", "dbo.Personals", "PersonalId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyAnswers", "PersonalId", "dbo.Personals");
            DropIndex("dbo.SurveyAnswers", new[] { "PersonalId" });
            DropColumn("dbo.SurveyAnswers", "PersonalId");
        }
    }
}
