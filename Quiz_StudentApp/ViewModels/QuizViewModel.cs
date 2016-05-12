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
using System.Windows.Threading;
using Quiz_StudentApp.HelperClass;
using Quiz_StudentApp.Enums;

namespace Quiz_StudentApp.ViewModels
{
    public class QuizViewModel
    {
        public SingleChoiceCommand SingleChoiceCommand { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
        public Quiz ActiveQuiz { get; set; }
        public string TimeLeft { get; set; }
        Random randomizer = new Random();

        private QuizCorrector _quizCorrector;
        public QuizCorrector QuizCorrectorProp
        {
            get { return _quizCorrector; }
            set { _quizCorrector = value; }
        }

        //private QuizTimer _quizTimer;


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
            _quizCorrector = new QuizCorrector(ActiveQuiz);
            //SetupTimer();//temp position
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
            ObservableCollection<Question> activeQuiz;//

            using (var db = new QuizContext())
            {
                ActiveQuiz = db.Quizs.Include("User").Include("Questions").Include("Questions.Alternatives")
                               .Where(s => s.Id == ActiveQuiz.Id).FirstOrDefault<Quiz>();

                activeQuiz = new ObservableCollection<Question>(ActiveQuiz.Questions);

                ActiveQuiz.User = db.Users.Include("Results").Include("Quizs").Include("Education")
                               .Where(s => s.Id == ActiveQuiz.User.Id).FirstOrDefault<User>();
            }

            //Randomize 
            //QuestionType.RankQuestion

            foreach (var question in activeQuiz)
            {
                if (question.Type == QuestionType.RankQuestion)
                {
                   question.Alternatives = question.Alternatives.OrderBy(a => randomizer.Next()).ToList();
                }
                Questions.Add(question);
            }
        }

        public void SetActiveQuiz(Quiz quiz)
        {
            this.ActiveQuiz = quiz;
        }

        //private void SetupTimer()
        //{
        //    _quizTimer = new QuizTimer((TimeSpan)ActiveQuiz.TimeLimit);
        //}

        //public TimeSpan CheckTimeLeft()
        //{
        //    if (_quizTimer.TimeLeft <= new TimeSpan(0, 0, 0))
        //        _quizCorrector.SaveResult();

        //    return _quizTimer.TimeLeft;
        //}

        //save/hand in
        public bool HandInExam()
        {
            return _quizCorrector.HandleQuiz();
        }

        public string DisplayExamHandInError()
        {
            return _quizCorrector.ErrorMessage;
        }
    }
}
