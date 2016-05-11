using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

using System.Collections.ObjectModel;
using System.Data.Entity;
using Quiz_StudentApp.HelperClass;

namespace Quiz_StudentApp.ViewModels
{
    public class QuizViewModel
    {
        public SingleChoiceCommand SingleChoiceCommand { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
        public Quiz ActiveQuiz { get; set; }
        public TimeSpan TimeLeft { get; set; }

        private QuizCorrector _quizCorrector;
        private QuizTimer _quizTimer;

        //public QuizViewModel()
        //{
        //    Questions = new ObservableCollection<Question>();

        //    //SetQuizContent2();
        //}

        //körs i view xaml
        public QuizViewModel()
        {

        }

        //körs i view cs
        public QuizViewModel(Quiz quiz)
        {
            Questions = new ObservableCollection<Question>();
            ActiveQuiz = quiz;
            SetQuizContent2();
            SetupTimer();//temp position
        }

        //public QuizViewModel(Quiz quiz)
        //{
        //    ActiveQuiz = quiz;
        //    //_student = Repository<User>.GetInstance().GetDataList().Where(x => x.Id == quiz.UserId).ToList().First() as User;

        //    //HandInExam();
        //}

        // SetQuizContent();
        //}

        public void SetQuizContent2()
        {
            ObservableCollection<Question> x;//

            using (var db = new QuizContext())
            {
                ActiveQuiz = db.Quizs.Include("User").Include("Questions").Include("Questions.Alternatives")
                               .Where(s => s.Id == ActiveQuiz.Id).FirstOrDefault<Quiz>();

                x = new ObservableCollection<Question>(ActiveQuiz.Questions);

                ActiveQuiz.User = db.Users.Include("Results").Include("Quizs").Include("Education")
                               .Where(s => s.Id == ActiveQuiz.User.Id).FirstOrDefault<User>();
            }

            foreach (var item in x)
            {
                Questions.Add(item);
            }
        }

        public void SetActiveQuiz(Quiz quiz)
        {
            this.ActiveQuiz = quiz;
        }

        private void SetupTimer()
        {
            _quizTimer = new QuizTimer((TimeSpan)ActiveQuiz.TimeLimit);
            
        }

        public TimeSpan CheckTimeLeft()
        {
            if (_quizTimer.TimeLeft <= new TimeSpan(0, 0, 0))
                _quizCorrector.SaveResult();

            TimeLeft = _quizTimer.TimeLeft;
            return _quizTimer.TimeLeft;
        }

        //save/hand in
        public bool HandInExam()
        {
            _quizCorrector = new QuizCorrector(ActiveQuiz);//i brist på bättre ställe att lägga den på atm
            return _quizCorrector.HandleQuiz();
        }

        public string DisplayExamHandInError()
        {
            return _quizCorrector.ErrorMessage;
        }
    }
}
