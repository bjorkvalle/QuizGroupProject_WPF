using Quiz_StudentApp.Models;
using Quiz_WPFVersion.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quiz_StudentApp.ViewModels
{
    class HomeViewModel
    {
        public User ActiveUser { get; set; }
        public ObservableCollection<Quiz> UserQuizs { get; set; }
        public ObservableCollection<Result> UserResults { get; set; }

        public HomeViewModel()
        {
            //UserQuizs = GetUserQuizs();
            //UserResults = DisplayListData<Result>();
        }

        //private ObservableCollection<Quiz> GetUserQuizs()
        //{
        //    ObservableCollection<Quiz> quizs = (Repository<Quiz>.GetInstance().GetDataList() as List<QuizPayload>).FindAll(x=>x.UserId_Id==ActiveUser.Id)) as ObservableCollection<Quiz>;

        //    return GetListData<Quiz>() as ObservableCollection<Quiz>;
        //}
    }
}
