namespace OnlineExamService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerAndResultAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.McqQuestions", "CorrectAnswer", c => c.String());
            DropColumn("dbo.McqQuestions", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.McqQuestions", "Answer", c => c.String());
            DropColumn("dbo.McqQuestions", "CorrectAnswer");
        }
    }
}
