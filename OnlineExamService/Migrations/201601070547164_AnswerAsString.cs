namespace OnlineExamService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerAsString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.McqAnswers", "McqAnswers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.McqAnswers", "McqAnswers");
        }
    }
}
