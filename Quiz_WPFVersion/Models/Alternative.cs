using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Alternative
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ScoreValue { get; set; }
        public int AnsweredValue { get; set; }
        public int? QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
