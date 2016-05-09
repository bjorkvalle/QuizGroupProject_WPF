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
using Quiz_WPFVersion.ViewModels;


namespace Quiz_WPFVersion.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {

        User activeUser;
        AdminViewModel adminVM;

        public AdminView(User user)
        {
            InitializeComponent();
            activeUser = user;
            adminVM = new AdminViewModel(user);
        }





    }
}
