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
    public partial class CommenceQuiz : Page
    {
        //QuizViewModel vm;

        public CommenceQuiz(Quiz quiz)
        {
            InitializeComponent();
            ((QuizViewModel)DataContext).SetActiveQuiz(quiz);
            ((QuizViewModel)DataContext).SetQuizContent2();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtblockQuizTitle.Text = ((QuizViewModel)DataContext).ActiveQuiz.Title;
        }

        private void Btn_HandIn(object sender, RoutedEventArgs e)
        {
            if (((QuizViewModel)DataContext).HandInExam())
            {
                NavigationService.GoBack();
            }
            else
            {
                //Display ErrorMessage property
                //TEXTBLOCK = ((QuizViewModel)DataContext).DisplayExamHandInError();
            }
        }
    }
}
