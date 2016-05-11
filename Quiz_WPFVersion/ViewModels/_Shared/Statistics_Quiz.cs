using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels._Shared
{
    [NotMapped]
    public class Statistics_Quiz : Quiz
    {
        [NotMapped]
        public DateTime AverageTime { get; set; }
        [NotMapped]
        public int GradeG { get; set; }
        [NotMapped]
        public int GradeF { get; set; }

        public int QuizTaken { get; set; }
        public int QuizNotTaken { get; set; }


    }
}
