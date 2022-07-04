namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyAnswers", "SurveyAnsweStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyAnswers", "SurveyAnsweStatus");
        }
    }
}
