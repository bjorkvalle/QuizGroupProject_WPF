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
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();
            ObservableCollection<Quiz> oList = new ObservableCollection<Quiz>();
            quizzes.ForEach(u => oList.Add(u));

            return oList;
        }

        public ObservableCollection<Result> GetUserResults()
        {
            var quizzes = Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();
            ObservableCollection<Result> oList = new ObservableCollection<Result>();
            quizzes.ForEach(u => oList.Add(u));

            return oList;

            //var results = Repository<Result>.GetInstance().GetDataList().Where(result => result.User_Id == Repository<User>.GetInstance().GetData(ActiveUser.Id).Id);
            //return results as ObservableCollection<Result>;
        }
    }
}
