using System;
using System.Collections.Generic;
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
using Quiz_StudentApp.Models;
using Quiz_StudentApp.ViewModels;
using Quiz_StudentApp.Enums;
using Quiz_StudentApp.Data;
using System.Diagnostics;
using Quiz_StudentApp.Views.Student;

namespace Quiz_StudentApp.View._Shared
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        LoginViewModel loginVM = new LoginViewModel();

        public LoginView()
        {
            InitializeComponent();

        


        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = loginVM.LoginControll(UsernameBox.Text, PasswordBox.Password);

            if (user != null) {
                if (user.Type != UserType.Student)
                {
                    errormessageBox.Visibility = Visibility.Visible;

                    return;
                }
                this.NavigationService.Navigate(new StudentHome(user));
            }
            else { 
            errormessageBox.Visibility = Visibility.Visible;
            }

        }

    }
}
