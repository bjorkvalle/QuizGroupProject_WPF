using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels._Shared
{
    public class Statistics_Quiz : Quiz
    {
        public DateTime AverageTime { get; set; }
        public int GradeG { get; set; }
        public int GradeF { get; set; }


    }
}
