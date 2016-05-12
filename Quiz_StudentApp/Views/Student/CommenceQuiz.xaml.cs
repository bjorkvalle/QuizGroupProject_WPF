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
using System.Windows.Threading;

namespace Quiz_StudentApp.Views.Student
{
    public partial class CommenceQuiz : Page
    {
        //quick solution to timer
        public TimeSpan TimeLeft { get; set; }
        private TimeSpan _endTime;
        private DispatcherTimer _timer = new DispatcherTimer();
        

        public CommenceQuiz(Quiz quiz)
        {
            InitializeComponent();
            
            DataContext = new QuizViewModel(quiz);
            TimeLeft = new TimeSpan(99,99,99);

            //((QuizViewModel)DataContext).SetActiveQuiz(quiz);
            //((QuizViewModel)DataContext).SetQuizContent2();

            //quick solution to timer
            _endTime = DateTime.Now.TimeOfDay + (TimeSpan)((QuizViewModel)DataContext).ActiveQuiz.TimeLimit;
            SetTimer();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtblockQuizTitle.Text = ((QuizViewModel)DataContext).ActiveQuiz.Title;
        }

        private void Btn_HandIn(object sender, RoutedEventArgs e)
        {
            if (((QuizViewModel)DataContext).HandInExam())
            {
                _timer.Stop();
                NavigationService.GoBack();
            }
            else
            {
                //Display ErrorMessage property
                //TEXTBLOCK = ((QuizViewModel)DataContext).DisplayExamHandInError();
            }
        }

        /// <summary>
        /// quick solution to timer
        /// </summary>
        private void SetTimer()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            TimeLeft = (_endTime - DateTime.Now.TimeOfDay);
            
            ((QuizViewModel)DataContext).TimeLeft = TimeLeft.ToString();

            Console.WriteLine(_endTime.ToString());
            Console.WriteLine(TimeLeft.ToString() + ", " + new TimeSpan(0, 0, 0));

            if (TimeLeft <= new TimeSpan(0, 0, 0))
            {
                _timer.Stop();
                ((QuizViewModel)DataContext).QuizCorrectorProp.SaveResult();

                //this.NavigationService.Navigate(new StudentHome(((QuizViewModel)DataContext).ActiveQuiz.User));
                NavigationService.GoBack();
            }
            else { 
                Timer.Text = new DateTime(TimeLeft.Ticks).ToString("HH:mm:ss");
                Timer.Visibility = Visibility.Visible;
            }
        }
    }
}
