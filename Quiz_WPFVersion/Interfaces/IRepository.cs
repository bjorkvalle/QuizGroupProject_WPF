using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Interfaces
{
    public interface IRepository
    {
        //Create
        bool AddUser(User user);
        bool AddQuiz(Quiz quiz);
        bool AddQuestion(Question question);
        bool AddAlternative(Alternative alternative);
        bool AddResult(Result result);
        bool AddEducation(Education education);
        bool AddCourse(Course course);


        //Read
        User GetUser(int userId);
        Quiz GetQuiz(int quizId);
        Question GetQuestion(int questionId);
        Alternative GetAlternative(int alternativeId);
        Result GetResult(int resultId);
        Education GetEducation(int educationId);
        Course GetCourse(int courseId);

        IList<User> GetAllUsers();
        IList<Quiz> GetAllQuizzes();
        IList<Question> GetAllQuestions();
        IList<Alternative> GetAllAlternatives();
        IList<Result> GetAllResults();
        IList<Education> GetEducations();
        IList<Course> GetCourses();

        //Update
        bool UpdateUser(User user);
        bool UpdateQuiz(Quiz quiz);
        bool UpdateQuestion(Question question);
        bool UpdateAlternative(Alternative alternative);
        bool UpdateResult(Result result);
        bool UpdateEducation(Education education);
        bool UpdateCourse(Course course);

        //Delete
        bool DeleteUser(int userId);
        bool DeleteQuiz(int quizId);
        bool DeleteQuestion(int questionId);
        bool DeleteAlternative(int alternativeId);
        bool DeleteResult(int resultId);
        bool DeleteQuizPayload(int quizPayloadId);
        bool DeleteEducation(int educationId);
        bool DeleteCourse(int courseId);
        bool DeleteUserCourse(int userCourseId);



    }
}
