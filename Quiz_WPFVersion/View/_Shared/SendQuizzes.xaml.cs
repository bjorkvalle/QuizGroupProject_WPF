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
using Quiz_WPFVersion.Data;

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
        //List<Quiz> quizzes;
        Quiz selectedQuiz;


        public SendQuiz(User user)
        {
            InitializeComponent();
            activeUser = user;
            adminVM = new AdminViewModel(activeUser);
            quizListBox.ItemsSource = Repository<Quiz>.GetInstance().GetDataList().ToList();
            userListBox.ItemsSource = Repository<User>.GetInstance().GetDataList().ToList();
            selectedStudents = new List<User>();
            comboBox_Education.ItemsSource = Repository<Education>.GetInstance().GetDataList().ToList();

        }


        //private void Button_Click_DotNet(object sender, RoutedEventArgs e)
        //{
        //    students = adminVM.GetStudentByEducation(1);
        //    userListBox.ItemsSource = adminVM.GetStudentByEducation(1);
        //}

        //private void Button_Click_Java(object sender, RoutedEventArgs e)
        //{
        //    students = adminVM.GetStudentByEducation(2);
        //    userListBox.ItemsSource = adminVM.GetStudentByEducation(2);
        //}

        private void Button_Click_All(object sender, RoutedEventArgs e)
        {
            students = adminVM.GetAllStudents();
            userListBox.ItemsSource = adminVM.GetAllStudents();
            quizListBox.ItemsSource = Repository<Quiz>.GetInstance().GetDataList().ToList();
            comboBox_Education.SelectedIndex = -1;
            ResetMessage();
        }

        private void Button_Click_SendQuiz(object sender, RoutedEventArgs e)
        {
            if (selectedStudents != null && selectedQuiz != null)
            {
                adminVM.SendQuizToStudents(selectedQuiz, selectedStudents);
                lblMessage.Text = "• Provet är nu skickat";
                quizListBox.ItemsSource = Repository<Quiz>.GetInstance().GetDataList().ToList();
                userListBox.ItemsSource = Repository<User>.GetInstance().GetDataList().ToList();

                comboBox_Education.SelectedIndex = -1;
                selectedStudents.Clear();
            }
        }

        public void ResetMessage()
        {
            lblMessage.Text = "";
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Listbox.selectedItems act weird o.O
            selectedStudents.Clear();
            ResetMessage();
            foreach (User user in userListBox.SelectedItems)
            {
                selectedStudents.Add(user);
            }

        }

        private void quizListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedQuiz = quizListBox.SelectedItem as Quiz;
            ResetMessage();
        }

        private void comboBox_SelectionChanged_Education(object sender, SelectionChangedEventArgs e)
        {
            ResetMessage();
            var tempComb = sender as ComboBox;
            var tempEdu = tempComb.SelectedItem as Education;
            if (tempEdu == null){return;}

            var joinedUserList = from edu in Repository<User>.GetInstance().GetDataList()
                                 where (edu.EducationId == tempEdu.Id)
                                 select edu;




            var joinedQuizList = from quiz in Repository<Quiz>.GetInstance().GetDataList()
                                 join user in Repository<User>.GetInstance().GetDataList()
                                 on quiz.UserId equals user.Id
                                 where (user.EducationId == tempEdu.Id)
                                 select quiz;

            quizListBox.ItemsSource = joinedQuizList.ToList();
            userListBox.ItemsSource = joinedUserList.ToList();
        }
    }
}
