using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_StudentApp.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int? UserId { get; set; }
        public int? QuizId { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
