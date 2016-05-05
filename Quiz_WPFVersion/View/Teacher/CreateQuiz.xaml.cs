using Quiz_WPFVersion.HelperClass;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels.Teacher;
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

namespace Quiz_WPFVersion.View.Teacher
{
    /// <summary>
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : Page
    {

        CreateQuizViewModel viewModel;
        public List<Alternative> alternative { get; set; }

        public CreateQuiz()
        {
            InitializeComponent();
            viewModel = this.DataContext as CreateQuizViewModel;
        }

        private void btn_AddSingelQuestion(object sender, RoutedEventArgs e)
        {
            viewModel.AddSingelChoice_Question();

        }
        private void btnMultiQuestion_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddMultiChoice_Question();
        }

        private void btnRankQuestion_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddRankChoice_Question();
        }


    }
}
