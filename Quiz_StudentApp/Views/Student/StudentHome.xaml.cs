using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using Quiz_StudentApp.ViewModels;
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

namespace Quiz_StudentApp.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentHome.xaml
    /// </summary>
    public partial class StudentHome : Page
    {
        User _user;
        IList<Quiz> _quizlist;
        HomeViewModel vm;

        public StudentHome(User user)
        {
            
            InitializeComponent();
            _user = user;
            vm = new HomeViewModel(_user);
        }

        private void btnNewQuiz_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnOldQuiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_user.Name);
            userInfoTemplate.DataContext = vm;
            quizListTemplate.ItemsSource = vm.UserQuizs;
            resultListTemplate.ItemsSource = vm.UserResults;
        }
    }
}
