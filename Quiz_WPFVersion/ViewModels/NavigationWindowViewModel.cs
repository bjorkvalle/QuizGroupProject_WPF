using Quiz_WPFVersion.View.Teacher;
using Quiz_WPFVersion.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels
{
    public class NavigationWindowViewModel
    {
        public TestCommand testCommand { get; set; }

        public NavigationWindowViewModel()
        {
            NavigationWindowViewModel xx = this;
           
            this.testCommand = new TestCommand(this);
        }

        public void Simple()
        {
            Debug.WriteLine("Hello");
            //this.Content = new TeacherView();

        }
    }
}
