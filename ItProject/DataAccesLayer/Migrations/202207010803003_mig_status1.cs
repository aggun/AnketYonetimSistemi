namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_status1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyQuestions", "SurveyQuestionStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyQuestions", "SurveyQuestionStatus");
        }
    }
}
