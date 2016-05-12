using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_WPFVersion.Data
{
    public class SeedData
    {
        public SeedData()
        {
            Repository<User>.GetInstance().AddData(CreateUser());
        }

        private User CreateUser()
        {
            User user = new User()
            {
                Name = "student",
                Password = "1",
                Type = Enum.UserType.Student
            };

            User user2 = new User()
            {
                Name = "teacher",
                Password = "1",
                Type = Enum.UserType.Teacher
            };

            User user3 = new User()
            {
                Name = "admin",
                Password = "1",
                Type = Enum.UserType.Admin
            };

            user.Education = CreateEducation(user);
            user.Quizs = CreateQuiz();
            user.Results = CreateResult(user, user.Quizs.First());

            return user;
        }

        private ICollection<Result> CreateResult(User user, Quiz quiz)
        {
            List<Result> rlist = new List<Result>();

            Result qz = new Result()
            {
                Quiz = quiz,
                Score = 2,
                User = user
            };
            
            rlist.Add(qz);

            return rlist;
        }

        private ICollection<Quiz> CreateQuiz()
        {
            List<Quiz> qlist = new List<Quiz>();

            Quiz qz = new Quiz()
            {
                Title = "quiz1",
                Description = "descr1",
                GScore = 1,
                VGScore = 2,
                StartDate = new DateTime(2016, 01, 01),
                EndDate = new DateTime(2016, 01, 01),
                SentToAdmin = true,
                SentToStudent = true,
                ShowStudentResult = true,
                TimeLimit = new TimeSpan(1, 1, 1)
            };

            qz.Questions = CreateQuestion();
            qlist.Add(qz);

            return qlist;
        }

        private ICollection<Question> CreateQuestion()
        {
            List<Question> qlist = new List<Question>();

            Question qz = new Question()
            {
                Title = "question1",
                Type = Enum.QuestionType.SingleChoiceQuestion
            };
            Question qz2 = new Question()
            {
                Title = "question2",
                Type = Enum.QuestionType.MultiChoiceQuestion
            };
            Question qz3 = new Question()
            {
                Title = "question3",
                Type = Enum.QuestionType.RankQuestion
            };

            qz.Alternatives = CreateAlternatives();
            qz2.Alternatives = CreateAlternatives();
            qz3.Alternatives = CreateAlternatives();
            qlist.Add(qz);
            qlist.Add(qz2);
            qlist.Add(qz3);

            return qlist;
        }

        private ICollection<Alternative> CreateAlternatives()
        {
            List<Alternative> qlist = new List<Alternative>();

            Alternative qz = new Alternative()
            {
                Title = "alternative1",
                ScoreValue = 1
            };
            Alternative qz2 = new Alternative()
            {
                Title = "alternative2",
                ScoreValue = 0
            };

            qlist.Add(qz);
            qlist.Add(qz2);

            return qlist;
        }

        private Education CreateEducation(User user)
        {
            Education edu = new Education()
            {
                Name = "Education1"
            };
            edu.Users.Add(user);
            edu.Courses.Add(CreateCourse(user));

            return edu;
        }

        private Course CreateCourse(User user)
        {
            Course cor = new Course()
            {
                Name = "Course1"
            };
            cor.Users.Add(user);

            return cor;
        }
    }
}
