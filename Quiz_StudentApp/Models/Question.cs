using System;
using System.Collections.Generic;

namespace Quiz_StudentApp.Models
{
    public partial class Question
    {
        public Question()
        {
            this.Alternatives = new List<Alternative>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public Nullable<int> Quiz_Id { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
