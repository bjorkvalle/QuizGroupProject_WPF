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
    /// Interaction logic for CommenceQuiz.xaml
    /// </summary>
    public partial class CommenceQuiz : Page
    {
        QuizViewModel vm;
        public CommenceQuiz(Quiz quiz)
        {
            InitializeComponent();
            vm = new QuizViewModel(quiz);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = vm.ActiveQuiz;
            //Console.WriteLine(vm.ActiveQuiz.Questions);
        }
    }
}
