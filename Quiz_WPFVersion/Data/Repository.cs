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
                {
                    return (T)Convert.ChangeType(db.Users.Find(dataId) as User, typeof(T));
                }
                else
                    return (T)Convert.ChangeType(null, typeof(T));
            }
        }
    }
}
