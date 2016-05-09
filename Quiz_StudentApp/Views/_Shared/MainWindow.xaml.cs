using System;
using System.Collections.Generic;
using System.Windows;
using Quiz_StudentApp.Models;
using Quiz_StudentApp.Views.Student;
using Quiz_StudentApp.Data;
using System.Linq;

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

            User currentUser = new User() {
                Name = "bengt",
                Password = "123",
                Type = Enums.UserType.Student
            };

            currentUser.Quizs.Add(new Quiz()
            {
                Title = "Quiz1"
            });

            Repository<User>.GetInstance().AddData(currentUser);
                 
            User currentUser = Repository<User>.GetInstance().GetDataList().Where(c => c.Id == 1).First();

            Console.WriteLine(currentUser.Name);
            MainFrame.Content = new StudentHome(currentUser);
        }
    }
}
