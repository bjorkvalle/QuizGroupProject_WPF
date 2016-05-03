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
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels;
using Quiz_WPFVersion.Enum;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.View._Shared
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        LoginViewModel loginVM = new LoginViewModel();
        TeacherViewModel teacherVM = new TeacherViewModel();
        AdminViewModel adminVM = new AdminViewModel();

        public LoginView()
        {
            InitializeComponent();

            User user = new User
            {
                Name = "Test",
                Password = "123",
                Type = UserType.Admin
            };

            Repository<User>.GetInstance().AddData(user);

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = loginVM.LoginControll(UsernameBox.Text, PasswordBox.Text);

            if (user != null)
                UserTypeNavigation(user);
            else
            errormessageBox.Visibility = Visibility.Visible;

        }

        private void UserTypeNavigation(User user)
        {
            switch(user.Type)
            {
                case UserType.Techer:
                    teacherVM.GetUser(user);
                    this.NavigationService.Navigate(new NavigationWindowView());
                    break;
                case UserType.Admin:
                    adminVM.GetUser(user);
                    this.NavigationService.Navigate(new NavigationWindowView());
                    break;
                default:
                    break;

            }
        }


    }
}
