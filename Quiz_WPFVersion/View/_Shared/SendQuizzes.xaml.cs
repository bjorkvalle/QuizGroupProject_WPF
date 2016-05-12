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

namespace Quiz_WPFVersion.View._Shared
{
    /// <summary>
    /// Interaction logic for SendQuiz.xaml
    /// </summary>
    public partial class SendQuiz : Page
    {
<<<<<<< HEAD
        public SendQuiz()
        {
            InitializeComponent();
=======

        AdminViewModel adminVM;
        User activeUser;
        List<User> selectedStudents;
        Quiz selectedQuiz;


        public SendQuiz(User user)
        {
            InitializeComponent();
            activeUser = user;
            adminVM = new AdminViewModel(activeUser);
            quizListBox.ItemsSource = adminVM.GetQuizzes();
            userListBox.ItemsSource = adminVM.GetAllStudents();
            selectedStudents = new List<User>();
            comboBox_Education.ItemsSource = Repository<Education>.GetInstance().GetDataList().ToList();

        }

        private void Button_Click_All(object sender, RoutedEventArgs e)
        {
            comboBox_Education.SelectedIndex = -1;
            userListBox.ItemsSource = adminVM.GetAllStudents();
            ResetMessage();
        }

        private void Button_Click_SendQuiz(object sender, RoutedEventArgs e)
        {
            if (selectedStudents.Count != 0 && selectedQuiz != null)
            {
                adminVM.SendQuizToStudents(selectedQuiz, selectedStudents);
                lblMessage.Text = "• Provet är nu skickat";

                comboBox_Education.SelectedIndex = -1;
                selectedStudents.Clear();
                e.Handled = true;
            }
        }

        public void ResetMessage()
        {
            lblMessage.Text = "";
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

            userListBox.ItemsSource = adminVM.GetStudentByEducation(tempEdu.Id);

>>>>>>> refs/remotes/origin/master
        }
    }
}
