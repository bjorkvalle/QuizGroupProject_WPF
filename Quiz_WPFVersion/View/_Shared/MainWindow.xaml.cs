﻿using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Quiz_WPFVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //internal MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LoginView();

            Repository<User>.GetInstance().AddData(new User() { Name = "Timmy!" });

            //using (var db = new QuizContext())
            //{
            //    db.Database.Delete();
            //}

            //User user = new User();
            //user.Name = "Timmy";

            //user.Quizs.Add(new Quiz()
            //{
            //    Title = "TimmysQuiz1"
            //});
            //user.Quizs.Add(new Quiz()
            //{
            //    Title = "TimmysQuiz2"
            //});

            //Repository<User>.GetInstance().AddData(user);

            //var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == Repository<User>.GetInstance().GetData(1).Id);



            Question q = new Question();
            q.Alternatives = new List<Alternative>()
            {
                new Alternative(),
                new Alternative(),
                new Alternative()
            };

            Repository<Question>.GetInstance().AddData(q);

            Console.WriteLine(q.Alternatives.First().Id + ", " + q.Alternatives.First().questionId.Id.ToString());
            Console.WriteLine(q.Alternatives.ToList()[1].Id + ", " + q.Alternatives.ToList()[1].questionId.Id.ToString());
            Console.WriteLine(q.Alternatives.Last().Id + ", " + q.Alternatives.Last().questionId.Id.ToString());
        }
    }
}
