using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Quiz_StudentApp.ViewModels
{
    class HomeViewModel
    {
        public User ActiveUser { get; set; }
        public ObservableCollection<Quiz> UserQuizs { get; set; }
        public ObservableCollection<Result> UserResults { get; set; }

        public HomeViewModel(User user)
        {
            ActiveUser = user;
            UserQuizs = GetUserQuizs();
            UserResults = GetUserResults();
        }

        public ObservableCollection<Quiz> GetUserQuizs()
        {
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == Repository<User>.GetInstance().GetData(ActiveUser.Id).Id);
            return quizzes as ObservableCollection<Quiz>;
        }

        public ObservableCollection<Result> GetUserResults()
        {
            var results = Repository<Result>.GetInstance().GetDataList().Where(result => result.UserId_Id == Repository<User>.GetInstance().GetData(ActiveUser.Id).Id);
            return results as ObservableCollection<Result>;
        }
    }
}
