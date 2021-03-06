﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineExamService.DbContexts
{
    public class ExamDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ExamDbContext() : base("name=ExamDbContext")
        {
        }

        public System.Data.Entity.DbSet<OnlineExamService.Models.McqQuestion> McqQuestions { get; set; }

        public System.Data.Entity.DbSet<OnlineExamService.Models.McqExam> McqExams { get; set; }

        public System.Data.Entity.DbSet<OnlineExamService.Models.McqAnswer> McqAnswers { get; set; }

        public System.Data.Entity.DbSet<OnlineExamService.Models.Result> Results { get; set; }


    }
}
