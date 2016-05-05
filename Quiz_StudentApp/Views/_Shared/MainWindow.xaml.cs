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
using Quiz_StudentApp.Models;
using Quiz_StudentApp.Data;
using Quiz_StudentApp.ViewModels;

namespace Quiz_StudentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user1)
        {
            InitializeComponent();
            
            User user = Repository<User>.GetInstance().GetDataList().Last();
            Console.WriteLine(user.Name);

            Console.WriteLine(new HomeViewModel(user).GetUserQuizs());
        }
    }
}
