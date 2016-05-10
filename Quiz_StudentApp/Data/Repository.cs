using Quiz_StudentApp.Interfaces;
using Quiz_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz_StudentApp.Data
{
    public class Repository<T> : IGenericRepository<T> where T : class
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
                db.Set<T>().Add(data);
                db.SaveChanges();
                return true;
            }
        }

        public T GetData(int dataId)
        {
            using(var db = new QuizContext())
            {
                return (T)Convert.ChangeType(db.Set<T>().Find(dataId), typeof(T));
            }
        }
        public IList<T> GetDataList()
        {
            using (var db = new QuizContext())
            {
                return db.Set<T>().ToList();
            }
        }
        public bool UpdateData(T data)
        {
            using (var db = new QuizContext())
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }
        public bool DeleteData(T data)
        {
            using (var db = new QuizContext())
            {
                db.Set<T>().Attach(data);
                db.Set<T>().Remove(data);
                db.SaveChanges();
                return true;
            }             
        }
    }
}