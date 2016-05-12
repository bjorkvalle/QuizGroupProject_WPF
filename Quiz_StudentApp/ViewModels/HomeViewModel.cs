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
            //ActiveUser = user;
            ActiveUser = GetUserWithIncludes(user);//quick fix

            UserQuizs = GetUserQuizs();
            UserResults = GetUserResults();
            Education = GetUserEducation();
        }

        private User GetUserWithIncludes(User user)
        {
            using (var db = new QuizContext())
            {
                return db.Users.Include("Results").Include("Quizs").Include("Education")
                               .Where(s => s.Id == user.Id).FirstOrDefault<User>();
            }
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
                {
                    q.User = ActiveUser;
                    oList.Add(q);
                }
            }
            return oList;
            
        }

        public ObservableCollection<Result> GetUserResults()
        {
            ObservableCollection<Result> oList = new ObservableCollection<Result>();

            foreach (var r in Repository<Result>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList())
            {
                foreach (var q in Repository<Quiz>.GetInstance().GetDataList().Where(u => u.UserId == ActiveUser.Id).ToList())
                {
                    if (r.QuizId == q.Id && q.ShowStudentResult)
                    {
                        using (var db = new QuizContext())
                        {
                            r.Quiz = q;
                            r.User = ActiveUser;
                            oList.Add(r);
                            break;
                        }
                    }
                }
            }
            return oList; 
        }
    }
}
