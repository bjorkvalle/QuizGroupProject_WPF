using Quiz_StudentApp.Models;
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
        public StudentHome(User user)
        {
            
            InitializeComponent();
            var quiz1 = new Quiz() { Title = "Quiz1", Description = "Blabla" };
            //_quizlist.Add(quiz1);
            //_quizlist.Add(new Quiz()
            //{
            //    Title = "Quiz2",
            //    Description = "derpderp"
            //});



            _user = user;
            //vm.ActiveUser = user;
            //list1.ItemsSource = vm.DisplayListData<Quiz>();
            //list2.ItemsSource = vm.DisplayListData<Result>();
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
            userInfoTemplate.DataContext = _user;
            quizListTemplate.ItemsSource = _quizlist;
        }
    }
}
