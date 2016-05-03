using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class QuizPayload
    {
        public int Id { get; set; }
        public bool SentToAdmin { get; set; }
        public bool SentToStudent { get; set; }
        public Nullable<int> QuizId_Id { get; set; }
        public Nullable<int> UserId_Id { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
