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


        public List<Alternative> alternative { get; set; }

        public CreateQuiz()
        {
            InitializeComponent();
            
        }

        public void btnAddAlternative_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_Add_alt_NEW(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_AddSignleQuestion(object sender, RoutedEventArgs e)
        {
          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CreateQuizViewModel vm = this.DataContext as CreateQuizViewModel;

            vm.AddNewItem(this);
        }
    }
}
