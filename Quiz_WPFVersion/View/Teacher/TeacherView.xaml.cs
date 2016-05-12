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
using Quiz_WPFVersion.Enum;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.View.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Page
    {
        public TeacherView(User user)
        {
            InitializeComponent();
            txtbName.Text = user.Name;
            listBox.ItemsSource = Repository<Quiz>.GetInstance().GetDataList().Where(q => q.UserId == user.Id && !String.IsNullOrEmpty(q.Title) && q.SentToStudent).ToList();
        }

       
    }
}
