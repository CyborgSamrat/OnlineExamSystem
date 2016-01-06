using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class Exam
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string CourseName { get; set; }
        public int FullMarks { get; set; }
        public DateTime ExamTime { get; set; }
        public int AllocatedTimeInMinute { get; set; }
        public string DifficultyLevel { get; set; }
       
    }
}