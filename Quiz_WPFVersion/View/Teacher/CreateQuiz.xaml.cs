using Quiz_WPFVersion.HelperClass;
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
        public CreateQuiz()
        {
            InitializeComponent();
        }

        private void btnAddAlternative_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestionHelper createQuizHelper = new CreateQuestionHelper(this);
            createQuizHelper.CreateAlternativeSingleQuestionType();
        }
    }
}
