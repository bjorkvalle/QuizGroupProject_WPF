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
            //UserResults = DisplayListData<Result>();
        }

        public ObservableCollection<Quiz> GetUserQuizs()
        {
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == Repository<User>.GetInstance().GetData(ActiveUser.Id).Id);
            return quizzes as ObservableCollection<Quiz>;
            //ObservableCollection<Quiz> quizs = (Repository<Quiz>.GetInstance().GetDataList() as List<QuizPayload>).FindAll(x => x.UserId_Id == ActiveUser.Id)) as ObservableCollection<Quiz>;

            //return GetListData<Quiz>() as ObservableCollection<Quiz>;
        }
    }
}
