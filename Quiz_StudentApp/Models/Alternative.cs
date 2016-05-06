using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Alternative
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ScoreValue { get; set; }
        public Nullable<int> questionId_Id { get; set; }
        public virtual Question Question { get; set; }
    }
}
