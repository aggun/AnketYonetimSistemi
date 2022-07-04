namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_rev_surveyquest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyAnswers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SurveyAnswers", "Survey_SurveyId", "dbo.Surveys");
            DropIndex("dbo.SurveyAnswers", new[] { "CompanyId" });
            DropIndex("dbo.SurveyAnswers", new[] { "Survey_SurveyId" });
            DropColumn("dbo.SurveyAnswers", "CompanyId");
            DropColumn("dbo.SurveyAnswers", "Survey_SurveyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyAnswers", "Survey_SurveyId", c => c.Int());
            AddColumn("dbo.SurveyAnswers", "CompanyId", c => c.Int());
            CreateIndex("dbo.SurveyAnswers", "Survey_SurveyId");
            CreateIndex("dbo.SurveyAnswers", "CompanyId");
            AddForeignKey("dbo.SurveyAnswers", "Survey_SurveyId", "dbo.Surveys", "SurveyId");
            AddForeignKey("dbo.SurveyAnswers", "CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
