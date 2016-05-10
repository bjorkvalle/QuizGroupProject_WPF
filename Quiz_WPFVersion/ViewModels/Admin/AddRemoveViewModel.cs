using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.ViewModels.Admin
{

    public class AddRemoveViewModel
    {
        public User userBinding { get; set; }
        public ObservableCollection<Education> educationList { get; set; }
        public ObservableCollection<Course> courseList { get; set; }

        public AddRemoveViewModel()
        {
            userBinding = new User();

            #region declaration
            //educationList = new ObservableCollection<Education>( Repository<Education>.GetInstance().GetDataList());
            //courseList = new ObservableCollection<Course>( Repository<Course>.GetInstance().GetDataList());
            educationList = new ObservableCollection<Education>
            {
                new Education
                {
                    Name="Java",
                },
                new Education
                {
                    Name=".Net",
                },

            };
            courseList = new ObservableCollection<Course>
            {
                new Course
                {
                    Name="Logic"
                },
                new Course
                {
                    Name="Object"
                },
                new Course
                {
                    Name="String"
                },
            };

            #endregion
        }
    }
}
