using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public Nullable<int> QuizId_Id { get; set; }
        public Nullable<int> UserId_Id { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}