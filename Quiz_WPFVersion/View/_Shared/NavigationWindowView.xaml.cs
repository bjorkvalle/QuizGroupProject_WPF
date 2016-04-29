using Quiz_WPFVersion.ViewModels;
using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.View.Student;
using Quiz_WPFVersion.View.Admin;
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
    /// Interaction logic for NavigationWindowView.xaml
    /// </summary>
    public partial class NavigationWindowView : Page
    {
        public NavigationWindowView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new SeeQuizzes());
            this.Content = new SeeQuizzes();
            //this.NavigationService.Source = new Uri("SeeQuizzes.xaml",UriKind.RelativeOrAbsolute);
        }
    }
}
