using System.Collections.Generic;
using Quiz_WPFVersion.Enum;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_WPFVersion.Models
{
    public class User
    {
        public User()
        {
            this.Courses = new Collection<Course>();
            this.Quizs = new Collection<Quiz>();
            this.Results = new Collection<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

        public int? EducationId { get; set; }
        [ForeignKey("EducationId")]
        public virtual Education Education { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
