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
        HomeViewModel vm;

        public StudentHome(User user)
        {

            InitializeComponent();
            vm = new HomeViewModel(user);
        }

        private void btnNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            resultListTemplate.Visibility = Visibility.Collapsed;
            quizListTemplate.Visibility = Visibility.Visible;
        }

        private void btnOldQuiz_Click(object sender, RoutedEventArgs e)
        {
            quizListTemplate.Visibility = Visibility.Collapsed;
            resultListTemplate.Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userInfoTemplate.DataContext = vm.ActiveUser; ;
            quizListTemplate.ItemsSource = vm.GetUserQuizs();
            resultListTemplate.ItemsSource = vm.GetUserResults();
        }
        private void quizListTemplate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Quiz quiz = (Quiz)quizListTemplate.SelectedItem;
            this.NavigationService.Navigate(new CommenceQuiz(quiz));

            Console.WriteLine(quiz.Title);
            Console.WriteLine(quiz.Description);
        }
    }
}
