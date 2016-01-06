using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class Result
    {
        public Guid ResultId { get; set; }
        public virtual McqAnswer Answers { get; set; }

        public virtual List<McqQuestion> CorrectAnswers { get; set; }
        public virtual List<McqQuestion> WorngAnswer { get; set; }

        public int ObtainedMarks { get; set; }

    }
}