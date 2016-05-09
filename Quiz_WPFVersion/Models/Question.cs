using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Enum;
using System.Collections.ObjectModel;

namespace Quiz_WPFVersion.Models
{
    public class Question
    {
        public Question()
        {
            Alternatives = new Collection<Alternative>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type{ get; set; }
        public virtual ICollection<Alternative> Alternatives { get; set; }
        public int? Quiz_Id { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
