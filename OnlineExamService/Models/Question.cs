using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineExamService.Models
{
    public class Question
    {
       
        public string SubjectCode { get; set; }
        public string DifficultyLevel { get; set; }
        public string Class { get; set; }
        public string Type { get; set; } 
      
    }
}