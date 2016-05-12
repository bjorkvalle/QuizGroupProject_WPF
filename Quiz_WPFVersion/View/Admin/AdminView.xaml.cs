using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {
        public AdminView(User user)
        {
            InitializeComponent();
            txtbName.Text = user.Name;
            listBox.ItemsSource = Repository<Quiz>.GetInstance().GetDataList().Where(q => q.SentToAdmin && !q.SentToStudent && !String.IsNullOrEmpty(q.Title)).ToList();

        }
    }
}
