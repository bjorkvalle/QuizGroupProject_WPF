using Quiz_StudentApp.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_StudentApp.Models
{
    public partial class User
    {
        public User()
        {
            this.Quizs = new Collection<Quiz>();
            this.Results = new Collection<Result>();
            this.Courses = new Collection<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

        public int? EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
