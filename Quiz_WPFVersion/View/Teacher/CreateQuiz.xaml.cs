using Quiz_WPFVersion.HelperClass;
using Quiz_WPFVersion.Models;
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
        //public List<Alternative> alternative = new List<Alternative>();

        public List<Alternative> alternative { get; set; }

        public CreateQuiz()
        {
            InitializeComponent();
            alternative = new List<Alternative>();
            listAlternative.ItemsSource = alternative;
        }

        public void btnAddAlternative_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestionHelper createQuizHelper = new CreateQuestionHelper(this);
            createQuizHelper.CreateAlternativeSingleQuestionType();
        }

        private void btn_Add_alt_NEW(object sender, RoutedEventArgs e)
        {
            alternative.Add(new Alternative() { Title ="Hej", ScoreValue=35 });
            listAlternative.ItemsSource = alternative;
        }

        private void btn_AddSignleQuestion(object sender, RoutedEventArgs e)
        {
            CreateQuestionHelper createQuizHelper = new CreateQuestionHelper(this);
            createQuizHelper.CreateQuestion();
        }
    }
}
