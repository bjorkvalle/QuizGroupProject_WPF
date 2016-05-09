using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quiz_StudentApp.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            this.Questions = new Collection<Question>();
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
        public bool SentToAdmin { get; set; }
        public bool SentToStudent { get; set; }
        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
