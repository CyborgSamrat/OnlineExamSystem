using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class McqQuestion : Question
    {
        public Guid McqQuestionId { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }

        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public string CorrectAnswer { get; set; }

        public McqQuestion()
        {
            this.McqQuestionId = Guid.NewGuid();
        }
        
    }
}