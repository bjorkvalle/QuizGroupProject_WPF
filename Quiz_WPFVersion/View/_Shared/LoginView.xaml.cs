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
using System.Diagnostics;

namespace Quiz_WPFVersion.View._Shared
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

            if (user != null)
            {
                if (user.Type == UserType.Student)
                {
                    return;
                }
                this.NavigationService.Navigate(new NavigationWindowView(user));

            }
            else
            {

                errormessageBox.Visibility = Visibility.Visible;
            }

        }

    }
}
