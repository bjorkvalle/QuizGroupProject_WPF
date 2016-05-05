using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Quiz_WPFVersion.Enum;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_WPFVersion.Models
{
    public class User
    {
        public User()
        {
            Courses = new Collection<Course>();
            Quizs = new Collection<Quiz>();
            Results = new Collection<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public int? Education_Id { get; set; }
        public Education Education { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
