using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> Quiz_Id { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
