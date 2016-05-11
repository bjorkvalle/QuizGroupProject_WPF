using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Quiz_StudentApp.ViewModels
{
    public class HomeViewModel
    {
        public User ActiveUser { get; set; }
        public ObservableCollection<Quiz> UserQuizs { get; set; }
        public ObservableCollection<Result> UserResults { get; set; }

        public HomeViewModel(User user)
        {
            ActiveUser = user;//Repository<User>.GetInstance().GetDataList().First();//user;
            UserQuizs = GetUserQuizs();
            UserResults = GetUserResults();
        }

        public ObservableCollection<Quiz> GetUserQuizs()
        {
            //prevent from being able to retake same quiz
            //check if quizId already in result table

            var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();

            ObservableCollection<Quiz> oList = new ObservableCollection<Quiz>();
            quizzes.ForEach(u => oList.Add(u));

            //foreach (var r in GetUserResults())
            //{
            //    foreach (var q in oList)
            //    {
            //        if (r.QuizId == q.Id)
            //            oList.Remove(q);
            //    }
            //}

            return oList;
        }

        public ObservableCollection<Result> GetUserResults()
        {
            var results = Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();
            ObservableCollection<Result> oList = new ObservableCollection<Result>();
            results.ForEach(u => oList.Add(u));

            return oList;
        }
    }
}
