using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels
{


    class StatisticsViewModel2
    {
        Repository<Course> repo_Courses = new Repository<Course>();
        Repository<Education> repo_Education = new Repository<Education>();

        public ObservableCollection<Course> _Courses { get; private set; }
        public ObservableCollection<Education> _Education { get; private set; }


        public StatisticsViewModel2()
        {
            _Courses = new ObservableCollection<Course>();
            _Education = new ObservableCollection<Education>();

            var course_temp = repo_Courses.GetDataList().ToList();
            course_temp.ForEach(u => _Courses.Add(u));

            var education_temp = repo_Education.GetDataList().ToList();
            education_temp.ForEach(u => _Education.Add(u));
        }
    }
}
