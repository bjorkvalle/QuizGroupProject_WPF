using System;
using System.Collections.Generic;
using System.Windows;
using Quiz_StudentApp.Models;
using Quiz_StudentApp.Views.Student;
using Quiz_StudentApp.Data;
using System.Linq;
using System.Data.Entity;
using Quiz_StudentApp.View._Shared;

namespace Quiz_StudentApp.Views._Shared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //new SeedData();
            MainFrame.Content = new LoginView();

            //REFS-->
            //Question q = Repository<Question>.GetInstance().GetDataList().First();
            //var alts = Repository<Alternative>.GetInstance().GetDataList().Where(a => a.QuestionId == q.Id).ToList();

            //var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == 2).ToList();
            //<--



            //Console.WriteLine(q.Title);

            //q.Title = q.Title + "Updated";

            //Repository<Question>.GetInstance().UpdateData(q);

            //Console.WriteLine(q.Title);
            //Console.WriteLine(Repository<Question>.GetInstance().GetDataList().First().Title);

            //var t = Repository<Question>.GetInstance().GetDataList().Include(p => p.Alternatives).ToList();

            //var r = Repository<Alternative>.GetInstance().GetDataList();//.Where(alt => alt.Question.Id == q.Id).ToList();//.ForEach(w => Repository<Alternative>.GetInstance().DeleteData(w));



            //r = r.Where(alt => alt.Question.Id == q.Id).ToList();

            //Repository<Question>.GetInstance().DeleteData(q);

            //Console.WriteLine(currentUser.Name);
            //MainFrame.Content = new StudentHome(currentUser);

        }
    }
}
