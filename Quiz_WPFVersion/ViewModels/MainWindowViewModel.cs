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

        ////public TestCommand testCommand { get; set; }
        private IRepository repository { get; set; }
        private User activeUser { get; set; }


        public MainWindowViewModel()
        {

        }

        public void Navigate(Frame frame, string command)
        {
            switch (command)
            {
                case "menuLogo":
                    if (activeUser.Type == UserType.Techer)
                    {
                        frame.Content = new TeacherView();
                    }
                    else if (activeUser.Type == UserType.Admin)
                    {
                        frame.Content = new AdminView();
                    }
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

        public void RenderAccessibility(User user, MainWindow window)
        {
            activeUser = user;

            switch (user.Type)
            {
                case UserType.Techer:
                    window.btnSendQuiz.Visibility = Visibility.Collapsed;
                    window.btnAdministrate.Visibility = Visibility.Collapsed;
                    window.MainFrame.Content = new TeacherView();
                    break;
                case UserType.Admin:
                    window.btnCreateQuiz.Visibility = Visibility.Collapsed;
                    window.MainFrame.Content = new AdminView();
                    break;
                case UserType.Student:
                    throw new ArgumentException("User is student - no acessibility should be allowed in this program");
                default:
                    break;
            }

        }
    }
}
