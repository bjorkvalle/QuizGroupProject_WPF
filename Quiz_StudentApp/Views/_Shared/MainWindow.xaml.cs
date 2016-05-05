using System.Windows;
using Quiz_StudentApp.Models;
using Quiz_StudentApp.Views.Student;

namespace Quiz_StudentApp.Views._Shared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            User currentUser = new User() {
                Name = "bengt",
                Password = "123",
                Type = 1
            };
            MainFrame.Content = new StudentHome(currentUser);

            

        }
    }
}
