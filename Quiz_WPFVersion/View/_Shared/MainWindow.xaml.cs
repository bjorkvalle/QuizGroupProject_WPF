using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.ViewModels;
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
        internal MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = this.DataContext as MainWindowViewModel;
            
            //Mock-up User
            User ActiveUser = new User
            {
                Id = 13,
                Name = "Haroun",
                Password = "123",
                Type = Enum.UserType.Techer
            };
            
            viewModel.RenderAccessibility(ActiveUser, this);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (sender == null || viewModel == null) return;
            viewModel.Navigate(MainFrame, senderButton.Name);

        }

        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            Image senderImage = sender as Image;
            if (senderImage == null || viewModel == null) return;
            viewModel.Navigate(MainFrame, senderImage.Name);
        }
    }
}
