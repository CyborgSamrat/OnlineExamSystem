using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class McqExam: Exam
    {
        public Guid McqExamId { get; set; }
        public int NumberOfMcqQuestion { get; set; }
        public virtual List<McqQuestion> McqQuestions { get; set; }
        public  List<string> McqAnswers { get; set; }

        public McqExam()
        {
            this.McqExamId = Guid.NewGuid();
        }
    }
}