using Quiz_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_StudentApp.ViewModels
{
    class QuizViewModel
    {
        public Quiz ActiveQuiz { get; set; }

        public QuizViewModel(Quiz quiz)
        {
            ActiveQuiz = quiz;
        }


    }
}
