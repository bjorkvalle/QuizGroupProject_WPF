using Quiz_WPFVersion.ViewModels;
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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
            ((Statistics_ViewModel)this.DataContext).GetInstanceOfView(this);

        }


        private void comboBox_SelectionChanged_Education(object sender, SelectionChangedEventArgs e)
        {
            ((Statistics_ViewModel)this.DataContext).SetSelEducation((sender as ComboBox).SelectedItem);
        }


        private void comboBox_SelectionChanged_User(object sender, SelectionChangedEventArgs e)
        {
            ((Statistics_ViewModel)this.DataContext).SetSelUser((sender as ComboBox).SelectedItem);
        }
    }
}
