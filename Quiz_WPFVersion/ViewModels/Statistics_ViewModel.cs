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
using System.Windows.Controls;

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

        private Statistics viewStatistics { get; set; }

        public Statistics_ViewModel()
        {

            _Quiz = new ObservableCollection<Statistics_Quiz>
            {
                new Statistics_Quiz
                {
                    Title = "Prov1",
                    AverageTime = GetAverageTime(CreateQuizzes()),
                    QuizTaken = 14,  //Metod för att se hur många som är klara
                    QuizNotTaken = 2, //Metod för att se hur många som INTE är klara
                    GradeG = 13,  //Metod för att hämta alla godkända
                    GradeF = 1   //Metod för att hämta alla underkända
                },
                new Statistics_Quiz
                {
                    Title = "Prov2",
                    AverageTime = GetAverageTime(CreateQuizzes()),
                    QuizTaken = 30,
                    QuizNotTaken = 0,
                    GradeG = 20,
                    GradeF = 10
                },
                new Statistics_Quiz
                {
                    Title = "Prov3",
                    AverageTime = GetAverageTime(CreateQuizzes()),
                    QuizTaken = 37,
                    QuizNotTaken = 2,
                    GradeG = 33,
                    GradeF = 5

                },
                new Statistics_Quiz
                {
                    Title = "Prov4",
                    AverageTime = GetAverageTime(CreateQuizzes()),
                    QuizTaken = 32,
                    QuizNotTaken = 5,
                    GradeG = 2,
                    GradeF = 30


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

        private DateTime GetAverageTime(List<Quiz> quizList)
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
        Random rand = new Random();

        private List<Quiz> CreateQuizzes()
        {

            List<Quiz> quizList;
            quizList = new List<Quiz>()
            {
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                      
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },
                new Quiz
                {
                      Id = 1,
                      Title = "JavaQuiz",
                      StartDate = new DateTime(2016, 05, 07, 13, 00, 00),
                      EndDate = new DateTime(2016, 05, 07, rand.Next(13,17), rand.Next(00,59), 00),
                },


            };

            return quizList;

        }



        public void GetInstanceOfView(Statistics viewStatistics)
        {
            this.viewStatistics = viewStatistics;
        }


        private Education selEducation;
        private Course selCourse;
        private User selUser;
        public void SetSelEducation(object selEducation)
        {
            this.selEducation = selEducation as Education;
            Search();
        }

        private void Search()
        {
            if (selEducation != null)
            {

            }else if (selCourse != null)
            {

            } else if(selUser != null)
            {

            }

            //sök med tre värden
        }

        public void SetSelCourse(object selCourse)
        {
            this.selCourse = selCourse as Course;
        }

        public void SetSelUser(object selUser)
        {
            this.selUser = selUser as User;
        }
    }
}
