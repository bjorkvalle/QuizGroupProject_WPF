using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public System.TimeSpan? TimeLimit { get; set; }
        public bool ShowStudentResult { get; set; }
        public bool SentToAdmin { get; set; }
        public bool SentToStudent { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
