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
using Quiz_WPFVersion.ViewModels;
using Quiz_WPFVersion.Models;


namespace Quiz_WPFVersion.View.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Page
    {
        User activeUser;
        TeacherViewModel teacherVM;
        Quiz selectedQuiz;
        List<Quiz> quizzes;

        public TeacherView(User user)
        {
            InitializeComponent();
            activeUser = user;
            teacherVM = new TeacherViewModel(activeUser);
            txtbName.Text = user.Name;
            quizzes = teacherVM.GetQuizzes();
            quizListBox.ItemsSource = quizzes;
            //Console.WriteLine(teacherVM.GetQuizzes().First().Title);
        }

        private void quizListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedQuiz = quizzes[quizListBox.SelectedIndex];
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuiz == null)
                return;

            teacherVM.SendQuizToAdmin(selectedQuiz);

        }
    }
}
