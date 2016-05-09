using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_StudentApp.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Quiz_Id { get; set; }
        [ForeignKey("Quiz_Id")]
        public virtual Quiz Quiz { get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
    }
}
