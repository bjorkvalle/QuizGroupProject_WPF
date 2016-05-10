﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_WPFVersion.Models
{
    public class Alternative
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ScoreValue { get; set; }
        public int AnsweredValue { get; set; }

        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
