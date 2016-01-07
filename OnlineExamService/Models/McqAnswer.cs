using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class McqAnswer
    {
        public Guid McqAnswerId { get; set; }
        public virtual McqExam Exam { get; set; }
        public string McqAnswers { get; set; }
    }
}