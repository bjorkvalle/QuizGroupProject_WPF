using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels.Teacher
{
    [NotMapped]
    public class Question_Binding : Question
    {
        [NotMapped]
        public int ScoreValue { get; set; }
    }
}
