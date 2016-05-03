using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            this.Questions = new List<Question>();
            this.QuizPayloads = new List<QuizPayload>();
            this.Results = new List<Result>();
            this.UserCourses = new List<UserCourse>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int GScore { get; set; }
        public int VGScore { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public System.TimeSpan TimeLimit { get; set; }
        public bool ShowStudentResult { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuizPayload> QuizPayloads { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
