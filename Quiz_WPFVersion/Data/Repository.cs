using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Quiz_WPFVersion.Data
{
    public class Repository<T> : IGenericRepository<T>
    {
        private static Repository<T> _instance;

        public static Repository<T> GetInstance()
        {
            if (_instance == null)
                _instance = new Repository<T>();
            
            return _instance;
        }

        public bool AddData(T data)
        {
            using (var db = new QuizContext())
            {
                if (typeof(T) == typeof(User))
                    db.Users.Add(data as User);
                else if (typeof(T) == typeof(Quiz))
                    db.Quizzes.Add(data as Quiz);
                else if (typeof(T) == typeof(Result))
                    db.Results.Add(data as Result);
                else if (typeof(T) == typeof(QuizPayload))
                    db.QuizPayloads.Add(data as QuizPayload);
                else if (typeof(T) == typeof(Education))
                    db.Educations.Add(data as Education);
                else if (typeof(T) == typeof(Course))
                    db.Courses.Add(data as Course);
                else if (typeof(T) == typeof(UserCourse))
                    db.UserCourses.Add(data as UserCourse);
                else if (typeof(T) == typeof(Alternative))
                    db.Alternatives.Add(data as Alternative);
                else if (typeof(T) == typeof(Question))
                    db.Questions.Add(data as Question);
                else
                    return false;

                db.SaveChanges();
                return true;
            }
        }

        public T GetData(int dataId)
        {
            using(var db = new QuizContext())
            {
                if (typeof(T) == typeof(User))
                    return (T)Convert.ChangeType(db.Users.Find(dataId) as User, typeof(T));
                if (typeof(T) == typeof(Quiz))
                    return (T)Convert.ChangeType(db.Quizzes.Find(dataId) as Quiz, typeof(T));
                if (typeof(T) == typeof(Question))
                    return (T)Convert.ChangeType(db.Questions.Find(dataId) as Question, typeof(T));
                if (typeof(T) == typeof(Alternative))
                    return (T)Convert.ChangeType(db.Alternatives.Find(dataId) as Alternative, typeof(T));
                if (typeof(T) == typeof(Result))
                    return (T)Convert.ChangeType(db.Results.Find(dataId) as Result, typeof(T));
                if (typeof(T) == typeof(QuizPayload))
                    return (T)Convert.ChangeType(db.QuizPayloads.Find(dataId) as QuizPayload, typeof(T));
                if (typeof(T) == typeof(Education))
                    return (T)Convert.ChangeType(db.Educations.Find(dataId) as Education, typeof(T));
                if (typeof(T) == typeof(Course))
                    return (T)Convert.ChangeType(db.Courses.Find(dataId) as Course, typeof(T));
                if (typeof(T) == typeof(UserCourse))
                    return (T)Convert.ChangeType(db.UserCourses.Find(dataId) as UserCourse, typeof(T));
                else
                    return (T)Convert.ChangeType(null, typeof(T));
            }
        }
        public IList<T> GetDataList()
        {
            using (var db = new QuizContext())
            {
                if (typeof(T) == typeof(User))
                    return (IList<T>)Convert.ChangeType(db.Users.ToList() as IList<User>, typeof(T));
                //if (typeof(T) == typeof(Quiz))
                //    return (T)Convert.ChangeType(db.Quizzes.Find(dataId) as Quiz, typeof(T));
                //if (typeof(T) == typeof(Question))
                //    return (T)Convert.ChangeType(db.Questions.Find(dataId) as Question, typeof(T));
                //if (typeof(T) == typeof(Alternative))
                //    return (T)Convert.ChangeType(db.Alternatives.Find(dataId) as Alternative, typeof(T));
                //if (typeof(T) == typeof(Result))
                //    return (T)Convert.ChangeType(db.Results.Find(dataId) as Result, typeof(T));
                //if (typeof(T) == typeof(QuizPayload))
                //    return (T)Convert.ChangeType(db.QuizPayloads.Find(dataId) as QuizPayload, typeof(T));
                //if (typeof(T) == typeof(Education))
                //    return (T)Convert.ChangeType(db.Educations.Find(dataId) as Education, typeof(T));
                //if (typeof(T) == typeof(Course))
                //    return (T)Convert.ChangeType(db.Courses.Find(dataId) as Course, typeof(T));
                //if (typeof(T) == typeof(UserCourse))
                //    return (T)Convert.ChangeType(db.UserCourses.Find(dataId) as UserCourse, typeof(T));
                else
                    return (IList<T>)Convert.ChangeType(null, typeof(T));
            }
        }

    }
}
