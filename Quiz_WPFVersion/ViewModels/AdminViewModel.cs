using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;


namespace Quiz_WPFVersion.ViewModels
{
    class AdminViewModel
    {
        User activeUser;

        public AdminViewModel(User user)
        {
            activeUser = user;
        }

        public List<Quiz> GetQuizzes()
        {
            var quizzes = Repository<Quiz>.GetInstance().GetDataList().
                Where(quiz => quiz.UserId == activeUser.Id);
            return quizzes.ToList();
        }

        public List<User> GetAllStudents()
        {
            var students = Repository<User>.GetInstance().GetDataList().
                Where(user => user.Type == Enum.UserType.Student);
            return students.ToList();
        }

        public List<User> GetStudentByEducation(int edId)
        {
            var students = Repository<User>.GetInstance().GetDataList().
                Where(user => user.EducationId == edId);
            return students.ToList();
        }

        public void SendQuizToStudents(Quiz quiz, List<User> students)
        {
            foreach (var student in students)
            {
                quiz.UserId = student.Id;
                Repository<Quiz>.GetInstance().AddData(quiz);
            }
        }

        public void AddQuizTime(DateTime datetime, Quiz quiz)
        {
            var tmpTimeSpan = new TimeSpan();

            Repository<Quiz>.GetInstance().DeleteData(quiz);
            quiz.TimeLimit = tmpTimeSpan;
            Repository<Quiz>.GetInstance().AddData(quiz);
        }


    }
}
