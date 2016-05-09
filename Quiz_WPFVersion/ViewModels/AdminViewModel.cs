using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;


namespace Quiz_WPFVersion.ViewModels
{
    class AdminViewModel
    {
        public static User activeUser;

        public AdminViewModel(User user)
        {
            activeUser = user;
        }

        public List<Quiz> GetQuizzes()
        {
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == activeUser.Id);
            return quizzes.ToList();
        }


    }
}
