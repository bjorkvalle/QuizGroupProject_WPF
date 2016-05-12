using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View._Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Quiz_WPFVersion.ViewModels._Shared;

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


            _Education = new ObservableCollection<Education>(Repository<Education>.GetInstance().GetDataList());
            _Courses = new ObservableCollection<Course>(Repository<Course>.GetInstance().GetDataList());
            _Users = new ObservableCollection<User>(Repository<User>.GetInstance().GetDataList());
            _Quiz = new ObservableCollection<Statistics_Quiz>();

        }

        //private DateTime GetAverageTime(List<Quiz> quizList)
        //{
        //    List<DateTime> temp = new List<DateTime>();

        //    foreach (var quiz in quizList)
        //    {
        //        temp.Add(new DateTime(quiz.EndDate.Value.Ticks - quiz.StartDate.Value.Ticks));
        //    }

        //    var first = temp.First().Ticks;
        //    DateTime average;
        //    return average = new DateTime(first + (long)temp.Average(d => d.Ticks - first));

        //}

        private int GetGradeG(Quiz passedQuiz)
        {
            List<Result> tmpResults = Repository<Result>.GetInstance().GetDataList().Where(result => result.QuizId == passedQuiz.Id).ToList();

            int gUsers = 0;

            foreach (Result result in tmpResults)
            {
                if (result.Score >= passedQuiz.GScore)
                    gUsers++;
            }

            return gUsers;
        }

        private int GetGradeF(Quiz passedQuiz)
        {
            List<Result> tmpResults = Repository<Result>.GetInstance().GetDataList().Where(result => result.QuizId == passedQuiz.Id).ToList();

            int fUsers = 0;

            foreach (Result result in tmpResults)
            {
                if (result.Score < passedQuiz.GScore)
                    fUsers++;
            }

            return fUsers;
        }

        private int GetCompletedTestsCount(Quiz passedQuiz)
        {
            return Repository<Result>.GetInstance().GetDataList().Where(result => result.QuizId == passedQuiz.Id).ToList().Count;
        }

        private int GetNotCompletedTestsCount(Quiz passedQuiz)
        {
            int usersThatGotTheQuiz = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == passedQuiz.UserId).ToList().Count;
            return (usersThatGotTheQuiz - GetCompletedTestsCount(passedQuiz));
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
            SearchByEducation();
        }

        private void SearchByEducation()
        {

            var joinedQuizList = from quiz in Repository<Quiz>.GetInstance().GetDataList()
                                 join user in Repository<User>.GetInstance().GetDataList()
                                              on quiz.UserId equals user.Id
                                 where (user.EducationId == selEducation.Id)
                                 select quiz;



            CreateStatisticQuizList(joinedQuizList.ToList());

            //Fils the user box with user from the selected Education
            _Users.Clear();

            List<User> tmpUsers = Repository<User>.GetInstance().GetDataList().Where(user => user.EducationId == selEducation.Id).ToList();

            foreach (var user in tmpUsers)
            {
                _Users.Add(user);
            }

        }


        public void SearchByUser()
        {
            List<Quiz> tmpQuizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == selUser.Id).ToList();

            CreateStatisticQuizList(tmpQuizzes);

        }


        private void CreateStatisticQuizList(List<Quiz> quizList)
        {
            _Quiz.Clear();

            foreach (var quiz in quizList)
            {
                Statistics_Quiz tmpQuiz = new Statistics_Quiz
                {
                    Title = quiz.Title,
                    GradeG = GetGradeG(quiz),
                    //AverageTime = null, check later
                    GradeF = GetGradeF(quiz),
                    QuizTaken = GetCompletedTestsCount(quiz),
                    QuizNotTaken = GetNotCompletedTestsCount(quiz)

                };

                _Quiz.Add(tmpQuiz);

            }
        }





        public void SetSelUser(object selUser)
        {
            if (selUser == null)
                return;
            this.selUser = selUser as User;
            SearchByUser();
        }
    }
}
