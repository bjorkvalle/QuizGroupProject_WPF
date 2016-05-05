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
using Quiz_StudentApp.Models;
using Quiz_StudentApp.Data;
using Quiz_StudentApp.ViewModels;
using Quiz_StudentApp.Views.Student;

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

            //User user = Repository<User>.GetInstance().GetData(1);
            //Console.WriteLine(user.Name);

           // Console.WriteLine(new HomeViewModel(user).GetUserQuizs());

            //User currentUser = Repository<User>.GetInstance().GetData(1);
            User currentUser = new User() {
                Name = "bengt",
                Password = "123",
                Type = 1
            };
            MainFrame.Content = new StudentHome(currentUser);

        }
    }
}
