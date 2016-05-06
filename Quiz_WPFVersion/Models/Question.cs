using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Enum;

namespace Quiz_WPFVersion.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type{ get; set; }
        public IList<Alternative> Alternatives { get; set; }
    }
}
