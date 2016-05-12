using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels.Admin;
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

namespace Quiz_WPFVersion.View.Admin
{
    /// <summary>
    /// Interaction logic for AddRemoveUsers.xaml
    /// </summary>
    public partial class AddRemoveUsers : Page
    {
        public AddRemoveUsers()
        {
            InitializeComponent();
            ((AddRemoveViewModel)DataContext).GetInstanceView(this);
           
        }


        private void btn_RemoveUser(object sender, RoutedEventArgs e)
        {

            User temp = listUsers.SelectedItem as User;
            ((AddRemoveViewModel)DataContext).RemoveUser(temp);

        }

        private void btn_AddUser(object sender, RoutedEventArgs e)
        {


            ((AddRemoveViewModel)DataContext).AddUser();
        }

        private void txtbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ((AddRemoveViewModel)DataContext).SearchUsers(((TextBox)sender).Text);
        }


    }
}
