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
using Quiz_WPFVersion.ViewModels;
using Quiz_WPFVersion.Models;

namespace Quiz_WPFVersion.View._Shared
{
    /// <summary>
    /// Interaction logic for SendQuiz.xaml
    /// </summary>
    public partial class SendQuiz : Page
    {

        AdminViewModel adminVM;

        public SendQuiz()
        {
            InitializeComponent();
            adminVM = new AdminViewModel(AdminViewModel.activeUser);



        }
    }
}
