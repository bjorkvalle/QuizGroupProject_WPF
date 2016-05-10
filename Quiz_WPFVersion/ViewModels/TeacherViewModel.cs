using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.ViewModels
{
    class TeacherViewModel
    {

        User ActiveUser;

        public TeacherViewModel(User user)
        {
            ActiveUser = user;
        }


        public List<Quiz> GetQuizzes()
        {
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().
                Where(quiz => quiz.UserId == ActiveUser.Id);
            return quizzes.ToList();
        }

        public void SendQuizToAdmin(Quiz quiz)
        {
            var admins = Repository<User>.GetInstance().GetDataList().
                Where(user =>  user.Type == Enum.UserType.Admin);

            foreach (var admin in admins)
            {
                quiz.UserId = admin.Id;
                Repository<Quiz>.GetInstance().AddData(quiz);
            }

        }



    }
}
