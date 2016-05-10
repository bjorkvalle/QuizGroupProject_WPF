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

namespace Quiz_WPFVersion.View._Shared
{
    /// <summary>
    /// Interaction logic for SendQuiz.xaml
    /// </summary>
    public partial class SendQuiz : Page
    {

        AdminViewModel adminVM;
        User activeUser;
        List<User> students;
        List<User> selectedStudents;
        List<Quiz> quizzes;
        Quiz selectedQuiz;


        public SendQuiz(User user)
        {
            InitializeComponent();
            activeUser = user;
            adminVM = new AdminViewModel(activeUser);

            quizzes = adminVM.GetQuizzes();
            quizListBox.ItemsSource = quizzes;

            students = adminVM.GetAllStudents();
            userListBox.ItemsSource = students;

            selectedStudents = new List<User>();

        }


        private void Button_Click_DotNet(object sender, RoutedEventArgs e)
        {
            students = adminVM.GetStudentByEducation(1);
            userListBox.ItemsSource = adminVM.GetStudentByEducation(1);
        }

        private void Button_Click_Java(object sender, RoutedEventArgs e)
        {
            students = adminVM.GetStudentByEducation(2);
            userListBox.ItemsSource = adminVM.GetStudentByEducation(2);
        }

        private void Button_Click_All(object sender, RoutedEventArgs e)
        {
            students = adminVM.GetAllStudents();
            userListBox.ItemsSource = adminVM.GetAllStudents();
        }

        private void Button_Click_SendQuiz(object sender, RoutedEventArgs e)
        {
            if (selectedStudents != null && selectedQuiz != null)
            {
                adminVM.SendQuizToStudents(selectedQuiz, selectedStudents);
            }
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Listbox.selectedItems act weird o.O
            selectedStudents.Clear();

            foreach (User user in userListBox.SelectedItems)
            {
                selectedStudents.Add(user);
            }

        }

        private void quizListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedQuiz = quizListBox.SelectedItem as Quiz;
        }
    }
}
