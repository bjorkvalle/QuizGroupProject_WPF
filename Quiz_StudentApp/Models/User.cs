using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class User
    {
        public User()
        {
            this.QuizPayloads = new List<QuizPayload>();
            this.Results = new List<Result>();
            this.UserCourses = new List<UserCourse>();
            this.Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public Nullable<int> EducationId_Id { get; set; }
        public virtual Education Education { get; set; }
        public virtual ICollection<QuizPayload> QuizPayloads { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
