using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View._Shared;
using Quiz_WPFVersion.ViewModels._Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.ViewModels
{
    public class Statistics_ViewModel
    {
        //Repository<Course> repo_Courses = new Repository<Course>();
        //Repository<Education> repo_Education = new Repository<Education>();

        public ObservableCollection<Course> _Courses { get; private set; }
        public ObservableCollection<Education> _Education { get; private set; }
        public ObservableCollection<User> _Users { get; private set; }

        public ObservableCollection<Statistics_Quiz> _Quiz { get; private set; }
        private List<Quiz> quizList;

        private Statistics viewStatistics{ get; set; }

        public Statistics_ViewModel()
        {
            CreateQuizzes();

            

            _Quiz = new ObservableCollection<Statistics_Quiz>
            {
                new Statistics_Quiz
                {
                    Title = "Prov1",
                    AverageTime = GetAverageTime(),
                },
                new Statistics_Quiz
                {
                    Title = "Prov2"
                },
                new Statistics_Quiz
                {
                    Title = "Prov3"
                },
                new Statistics_Quiz
                {
                    Title = "Prov4"

                },
            };


            #region Edu, Course, User + Repository

            _Users = new ObservableCollection<User>
            {
                new User
                {
                    Name = "Ba",
                },
                new User
                {
                    Name = "Ka",
                },
                new User
                {
                    Name = "Raad",
                },
                new User
                {
                    Name = "Da",
                },
                new User
                {
                    Name = "Fz",
                },

            };

            _Courses = new ObservableCollection<Course>()
            {
                new Course
                {
                    Name = "Logic",

                }, new Course
                {
                    Name = "Basic",

                },
                 new Course
                {
                    Name = "Expert",

                },

            };
            _Education = new ObservableCollection<Education>()
            {
                new Education
                {
                    Name = "Java"
                },
                new Education
                {
                    Name = "C-Sharp"
                },
                 new Education
                {
                    Name = "Phyton"
                },

            };

            //var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == ActiveUser.Id);


            //var course_temp = repo_Courses.GetDataList().ToList();
            //course_temp.ForEach(u => _Courses.Add(u));

            //var education_temp = repo_Education.GetDataList().ToList();
            //education_temp.ForEach(u => _Education.Add(u));

            //Education = repo_Education.GetDataList();
            #endregion

        }

        private DateTime GetAverageTime()
        {
            List<DateTime> temp = new List<DateTime>();

            foreach (var quiz in quizList)
            {
                temp.Add(new DateTime(quiz.EndDate.Value.Ticks - quiz.StartDate.Value.Ticks));
            }

            var first = temp.First().Ticks;
            DateTime average;
            return average = new DateTime(first + (long)temp.Average(d => d.Ticks - first));
           
        }

        private void CreateQuizzes()
        {
            quizList = new List<Quiz>()
            {
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, 13, 30, 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, 13, 45, 00),
                },

            };

        }



        public void GetInstanceOfView(Statistics viewStatistics)
        {
            this.viewStatistics = viewStatistics;
        }
    }
}
