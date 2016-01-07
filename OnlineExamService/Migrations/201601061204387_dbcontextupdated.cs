namespace OnlineExamService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontextupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.McqAnswers",
                c => new
                    {
                        McqAnswerId = c.Guid(nullable: false),
                        Exam_McqExamId = c.Guid(),
                    })
                .PrimaryKey(t => t.McqAnswerId)
                .ForeignKey("dbo.McqExams", t => t.Exam_McqExamId)
                .Index(t => t.Exam_McqExamId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Guid(nullable: false),
                        ObtainedMarks = c.Int(nullable: false),
                        Answers_McqAnswerId = c.Guid(),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.McqAnswers", t => t.Answers_McqAnswerId)
                .Index(t => t.Answers_McqAnswerId);
            
            AddColumn("dbo.McqQuestions", "Result_ResultId", c => c.Guid());
            AddColumn("dbo.McqQuestions", "Result_ResultId1", c => c.Guid());
            CreateIndex("dbo.McqQuestions", "Result_ResultId");
            CreateIndex("dbo.McqQuestions", "Result_ResultId1");
            AddForeignKey("dbo.McqQuestions", "Result_ResultId", "dbo.Results", "ResultId");
            AddForeignKey("dbo.McqQuestions", "Result_ResultId1", "dbo.Results", "ResultId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.McqQuestions", "Result_ResultId1", "dbo.Results");
            DropForeignKey("dbo.McqQuestions", "Result_ResultId", "dbo.Results");
            DropForeignKey("dbo.Results", "Answers_McqAnswerId", "dbo.McqAnswers");
            DropForeignKey("dbo.McqAnswers", "Exam_McqExamId", "dbo.McqExams");
            DropIndex("dbo.Results", new[] { "Answers_McqAnswerId" });
            DropIndex("dbo.McqQuestions", new[] { "Result_ResultId1" });
            DropIndex("dbo.McqQuestions", new[] { "Result_ResultId" });
            DropIndex("dbo.McqAnswers", new[] { "Exam_McqExamId" });
            DropColumn("dbo.McqQuestions", "Result_ResultId1");
            DropColumn("dbo.McqQuestions", "Result_ResultId");
            DropTable("dbo.Results");
            DropTable("dbo.McqAnswers");
        }
    }
}
