using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.View.Teacher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Quiz_WPFVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //menuItemCreateQuiz.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (sender == null) return;

            switch (senderButton.Name)
            {
                case "btnBack":
                    Debug.WriteLine("btnBackward");
                    break;
                case "btnForward":
                    Debug.WriteLine("btnForward");
                    break;
                case "btnSeeQuizzes":
                    MainFrame.Content = new SeeQuizzes();
                    break;
                case "btnCreateQuiz":
                    MainFrame.Content = new CreateQuiz();
                    break;
                case "btnSendQuiz":
                    MainFrame.Content = new SendQuizzes();
                    break;
                case "btnAdministrate":
                    MainFrame.Content = new AddRemoveUsers();
                    break;

                default:
                    break;
            }

        }
    }
}
