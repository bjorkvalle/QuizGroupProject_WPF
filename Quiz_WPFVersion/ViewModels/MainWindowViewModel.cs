using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.Enum;
using Quiz_WPFVersion.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Interfaces;

namespace Quiz_WPFVersion.ViewModels
{
    class MainWindowViewModel
    {

        //public TestCommand testCommand { get; set; }
        private IRepository repository { get; set; }

        public MainWindowViewModel()
        {

        }

        public void Navigate(Frame frame, string command)
        {
            switch (command)
            {
                case "btnBack":
                    Debug.WriteLine("btnBackward");
                    break;
                case "btnForward":
                    Debug.WriteLine("btnForward");
                    break;
                case "btnSeeQuizzes":
                    frame.Content = new SeeQuiz();
                    break;
                case "btnCreateQuiz":
                    frame.Content = new CreateQuiz();
                    break;
                case "btnSendQuiz":
                    frame.Content = new SendQuiz();
                    break;
                case "btnAdministrate":
                    frame.Content = new AddRemoveUsers();
                    break;

                default:
                    break;
            }
        }

        //public UserType CheckAcessibility(User user)
        //{


        //    return UserType.Student;
        //}

        public void RenderAccessibility(User user, MainWindow window)
        {
            switch (user.AcessLevel)
            {
                case UserType.Techer:
                    window.menuItemSendQuiz.Visibility = Visibility.Collapsed;
                    window.menuItemAdministrateUsers.Visibility = Visibility.Collapsed;
                    break;
                case UserType.Admin:
                    window.menuItemCreateQuiz.Visibility = Visibility.Collapsed;
                    break;
                case UserType.Student:
                    break;
                default:
                    break;
            }

        }
    }
}
