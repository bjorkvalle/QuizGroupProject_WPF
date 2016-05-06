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
using Quiz_WPFVersion.Models;

namespace Quiz_WPFVersion.View._Shared
{
    /// <summary>
    /// Interaction logic for NavigationWindowView.xaml
    /// </summary>
    public partial class NavigationWindowView : Page
    {

        internal NavigationWindowViewModel viewModel;
        public NavigationWindowView(User user)
        {
            InitializeComponent();

            viewModel = this.DataContext as NavigationWindowViewModel;
            viewModel.RenderAccessibility(user, this);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (sender == null || viewModel == null) return;
            viewModel.Navigate(this, senderButton.Name);

        }

        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            Image senderImage = sender as Image;
            if (senderImage == null || viewModel == null) return;
            viewModel.Navigate(this, senderImage.Name);
        }
    }
}
