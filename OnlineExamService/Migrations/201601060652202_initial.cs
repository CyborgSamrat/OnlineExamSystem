namespace OnlineExamService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.McqExams",
                c => new
                    {
                        McqExamId = c.Guid(nullable: false),
                        NumberOfMcqQuestion = c.Int(nullable: false),
                        Title = c.String(),
                        Type = c.String(),
                        CourseName = c.String(),
                        FullMarks = c.Int(nullable: false),
                        ExamTime = c.DateTime(nullable: false),
                        AllocatedTimeInMinute = c.Int(nullable: false),
                        DifficultyLevel = c.String(),
                    })
                .PrimaryKey(t => t.McqExamId);
            
            CreateTable(
                "dbo.McqQuestions",
                c => new
                    {
                        McqQuestionId = c.Guid(nullable: false),
                        QuestionText = c.String(),
                        OptionA = c.String(),
                        OptionB = c.String(),
                        OptionC = c.String(),
                        OptionD = c.String(),
                        Answer = c.String(),
                        SubjectCode = c.String(),
                        DifficultyLevel = c.String(),
                        Class = c.String(),
                        Type = c.String(),
                        McqExam_McqExamId = c.Guid(),
                    })
                .PrimaryKey(t => t.McqQuestionId)
                .ForeignKey("dbo.McqExams", t => t.McqExam_McqExamId)
                .Index(t => t.McqExam_McqExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.McqQuestions", "McqExam_McqExamId", "dbo.McqExams");
            DropIndex("dbo.McqQuestions", new[] { "McqExam_McqExamId" });
            DropTable("dbo.McqQuestions");
            DropTable("dbo.McqExams");
        }
    }
}
