﻿
using System;
using System.Collections.Generic;
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
        public Question questionId { get; set; }
    }
}
