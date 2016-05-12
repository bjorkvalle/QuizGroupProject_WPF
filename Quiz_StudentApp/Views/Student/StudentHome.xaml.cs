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
using System.Windows.Media.Animation;
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
            btnNewQuiz.IsEnabled = false;
        }

        private void btnNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            
            ((Storyboard)FindResource("FlyInQuiz")).Begin();
            btnNewQuiz.IsEnabled = false;
            btnOldQuiz.IsEnabled = true;
        }

        private void btnOldQuiz_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)FindResource("FlyoutQuiz")).Begin();
            resultListTemplate.Visibility = Visibility.Visible;
            btnNewQuiz.IsEnabled = true;
            btnOldQuiz.IsEnabled = false;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userInfoTemplate.DataContext = vm.ActiveUser;
            quizListTemplate.ItemsSource = vm.GetUserQuizs(); //Randomize
            resultListTemplate.ItemsSource = vm.GetUserResults();
            txtBlockEducation.Text = vm.Education.Name;
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
