using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Quiz_WPFVersion.Enum;
using System.Collections.ObjectModel;

namespace Quiz_WPFVersion.Models
{
    public class User
    {
        public User()
        {
            Courses = new List<Course>();
            Quizs = new List<Quiz>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public Education EducationId { get; set; }
        public IList<Course> Courses { get; set; }
        public IList<Quiz> Quizs { get; set; }
    }
}
