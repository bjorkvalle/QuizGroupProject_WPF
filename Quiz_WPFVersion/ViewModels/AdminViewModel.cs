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
                using (var db = new QuizContext())
                {
                    quiz = db.Quizs.Include("Questions").Include("Questions.Alternatives")
                                   .Where(s => s.Id == quiz.Id).FirstOrDefault<Quiz>();
                }

                quiz.SentToStudent = true;
                quiz.UserId = student.Id;
                Repository<Quiz>.GetInstance().AddData(quiz);
            }
        }

        public void AddQuizTimeAndDates(TimeSpan? timespan, DateTime? startDate, DateTime? endDate, Quiz quiz)
        {
            //Repository<Quiz>.GetInstance().DeleteData(quiz);
            quiz.StartDate = startDate;
            quiz.EndDate = endDate;
            quiz.TimeLimit = timespan;

            Repository<Quiz>.GetInstance().UpdateData(quiz);
            //Repository<Quiz>.GetInstance().AddData(quiz);
        }

        //public void AddStartDateAndEndDate(DateTime? startDate, DateTime? endDate, Quiz quiz)
        //{
        //    Repository<Quiz>.GetInstance().DeleteData(quiz);
        //    quiz.StartDate = startDate;
        //    quiz.EndDate = endDate;
        //    Repository<Quiz>.GetInstance().AddData(quiz);
        //}



    }
}
