﻿using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View.Teacher;
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
            //questionList = new ObservableCollection<Question>();
            alternativeList = new ObservableCollection<Alternative>();


            alternativeList.Add(new Alternative
            {
                Id = 45,
                Title = "KingKong",
                ScoreValue = 45,
            });

            //questionList.Add(new Question
            //{
            //    Id = 45,
            //    Title = "KingKong",
            //    Type = Enum.QuestionType.SingleChoiceQuestion,
            //    Alternatives = new List<Alternative>(),
            //});

            //questionList.Add(new Question
            //{
            //    Title = "KorreBorre",
            //    Type = Enum.QuestionType.SingleChoiceQuestion,
            //});
            //questionList.Add(new Question
            //{
            //    Title = "Fänrik",
            //    Type = Enum.QuestionType.SingleChoiceQuestion,
            //});
        }

        public void AddNewItem(CreateQuiz view)
        {
            questionList.Add(new Question
            {
                Id = 25,
                Title = "KorreBorre",
                Type = Enum.QuestionType.SingleChoiceQuestion,
                Alternatives = new List<Alternative>(),
                
            });

            //view.listQuestion.ItemsSource = questionList;
        }

    }
}
