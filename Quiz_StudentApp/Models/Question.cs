using Quiz_StudentApp.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quiz_StudentApp.Models
{
    public partial class Question
    {
        public Question()
        {
            this.Alternatives = new Collection<Alternative>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; }
        public Nullable<int> Quiz_Id { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
