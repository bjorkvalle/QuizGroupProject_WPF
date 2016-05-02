using Quiz_WPFVersion.Enum;
using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz_WPFVersion.ViewModels
{
    public class NavigationWindowViewModel
    {
        private IRepository repository { get; set; }
        private User activeUser { get; set; }
        public NavigationWindowView window { get; set; }

        public NavigationWindowViewModel()
        {

        }

        public void Navigate(NavigationWindowView frame, string command)
        {
            switch (command)
            {
                case "menuLogo":
                    if (activeUser.AcessLevel == UserType.Techer)
                    {
                        
                        window.DetailFrame.Content = new TeacherView();
                    }
                    else if (activeUser.AcessLevel == UserType.Admin)
                    {
                        window.DetailFrame.Content = new AdminView();
                    }
                    break;
                case "btnSeeQuizzes":
                    window.DetailFrame.Content = new SeeQuiz();
                    break;
                case "btnCreateQuiz":
                    window.DetailFrame.Content = new CreateQuiz();
                    break;
                case "btnSendQuiz":
                    window.DetailFrame.Content = new SendQuiz();
                    break;
                case "btnAdministrate":
                    window.DetailFrame.Content = new AddRemoveUsers();
                    break;

                default:
                    break;
            }
        }

        public void RenderAccessibility(User user, NavigationWindowView window)
        {
            this.window = window;
            activeUser = user;
            switch (user.AcessLevel)
            {
                case UserType.Techer:
                    window.btnSendQuiz.Visibility = Visibility.Collapsed;
                    window.btnAdministrate.Visibility = Visibility.Collapsed;
                    var page = new TeacherView();
                    //window.NavigationService.Navigate(page,);
                    window.DetailFrame.Content = new TeacherView();
                    //var x =  window.Parent;
                    break;
                case UserType.Admin:
                    window.btnCreateQuiz.Visibility = Visibility.Collapsed;
                    window.DetailFrame.Content = new AdminView();
                    break;
                case UserType.Student:
                    throw new ArgumentException("User is student - no acessibility should be allowed in this program");
                default:
                    break;
            }

        }
    }
}
