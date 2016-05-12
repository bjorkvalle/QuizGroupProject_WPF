using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace Quiz_StudentApp.ViewModels
{
    public class HomeViewModel
    {
        public User ActiveUser { get; set; }
        public Education Education { get; set; }
        public ObservableCollection<Quiz> UserQuizs { get; set; }
        public ObservableCollection<Result> UserResults { get; set; }

        public HomeViewModel(User user)
        {
            ActiveUser = user;//Repository<User>.GetInstance().GetDataList().First();//user;
            UserQuizs = GetUserQuizs();
            UserResults = GetUserResults();
            Education = GetUserEducation();
        }

        private Education GetUserEducation()
        {
            Education userEducation = Repository<Education>.GetInstance().GetDataList().Where(e => e.Id == ActiveUser.EducationId).FirstOrDefault();
            return userEducation;
        }

        public ObservableCollection<Quiz> GetUserQuizs()
        {
            //var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();
            ObservableCollection<Quiz> oList = new ObservableCollection<Quiz>();
            //quizzes.ForEach(u => oList.Add(u));

            //prevent from being able to retake same quiz
            //check if quizId already in result table
            foreach (var q in Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList()) 
            {
                bool foundMatch = false;

                foreach (var r in Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList())
                {
                    if (r.QuizId == q.Id)
                    {
                        foundMatch = true;
                        break;
                    }
                }
                if (!foundMatch)
                    oList.Add(q);
            }
            return oList;
        }

        public ObservableCollection<Result> GetUserResults()
        {
            ObservableCollection<Result> oList = new ObservableCollection<Result>();

            //prevent from being able to retake same quiz
            //check if quizId already in result table
            foreach (var r in Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList())
            {
                foreach (var q in Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList())
                {
                    if (r.QuizId == q.Id && q.ShowStudentResult)
                    {
                        oList.Add(r);
                        break;
                    }
                }
            }

            return oList;
        }

        //public ObservableCollection<Result> GetUserResults()
        //{
        //    ObservableCollection<Result> oList = new ObservableCollection<Result>();

        //    var results = Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList();

        //    results.ForEach(u => oList.Add(u));

        //    return oList;
        //}
    }
}
