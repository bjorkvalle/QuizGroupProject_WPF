using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Models
{
    public class Quiz 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GScore { get; set; }
        public int VGScore { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan TimeLimit { get; set; } //correct type?
        public IList<Question> Questions { get; set; }
    }
}
