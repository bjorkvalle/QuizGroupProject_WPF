using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels.Teacher
{
    public class CreateQuizViewModel
    {
        public ObservableCollection<Question> questionList { get; set; }
        public ObservableCollection<Alternative> alternativeList { get; set; }

        public CreateQuizViewModel()
        {
            //questionList.Add(new Question
            //{
            //    Title = "Första",
            //    Type = Enum.QuestionType.SingleChoiceQuestion,
            //});
        }

    }
}
