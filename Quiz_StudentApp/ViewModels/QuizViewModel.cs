using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
<<<<<<< HEAD
=======
using System.Collections.ObjectModel;
using System.Data.Entity;
>>>>>>> refs/remotes/origin/takeQuiz

namespace Quiz_StudentApp.ViewModels
{
    public class QuizViewModel
    {
        public Quiz ActiveQuiz { get; set; }
        public string ErrorMessage { get; set; }

<<<<<<< HEAD
        private User _student;
=======
        //private User _student;
>>>>>>> refs/remotes/origin/takeQuiz

        public QuizViewModel(Quiz quiz)
        {
            ActiveQuiz = quiz;
<<<<<<< HEAD
            _student = Repository<User>.GetInstance().GetDataList().Where(x => x.Id == quiz.UserId) as User;
        }

=======
            //_student = Repository<User>.GetInstance().GetDataList().Where(x => x.Id == quiz.UserId).ToList().First() as User;

            SetQuizContent2();
            HandInExam();
        }

        public void SetQuizContent()
        {
            //var questions = Repository<Question>.GetInstance().GetDataList().Where(u => u.Quiz_Id == ActiveQuiz.Id).ToList();

            ////get alternatives and set correct quiz ref
            //for (int i = 0; i < questions.Count; i++)
            //{
            //    questions[i].Alternatives = Repository<Alternative>.GetInstance().GetDataList()
            //                                .Where(a => a.QuestionId == questions[i].Id).ToList();
            //    questions[i].Quiz = ActiveQuiz;
            //}

            //ActiveQuiz.User = _student;
            //ActiveQuiz.Questions = questions;
        }
        
        public void SetQuizContent2()
        {
            //inkluderar även questions
            using (var db = new QuizContext())
            {
                ActiveQuiz = db.Quizs.Include("User").Include("Questions").Include("Questions.Alternatives")
                               .Where(s => s.Id == ActiveQuiz.Id).FirstOrDefault<Quiz>();
            }
        }

>>>>>>> refs/remotes/origin/takeQuiz
        //save/hand in
        public bool HandInExam()
        {
            //validate quiz data
            if (!ValidateQuizData())
                return false;
             
            //correct the quiz
            if (!CorrectQuiz())
                return false;

            //prevent from being able to retake same quiz
<<<<<<< HEAD

            return true;
        }

        private bool ValidateQuizData()
        {
            //what needs to be validated?

            if ("1" == 1.ToString())
            {
                return true;
            }
            else
            {
                ErrorMessage = "What did you do?!";
                return false;
            }
        }

        private bool CorrectQuiz()
        {
            //om inte alla frågor är besvarade, skicka ett prompt för att bekräfta
            if (!ReadyToHandIn())
                return false;

            //save the result
            SaveResult();

            return true;
        }

        private bool ReadyToHandIn()
        {
            if ("1" == 1.ToString()) //PromptWindow
            {
                ErrorMessage = "";
                return true;
            }
            else
            {
                ErrorMessage = "Hand in cancelled";
                return false;
            }
        }

=======

            return true;
        }

        private bool ValidateQuizData()
        {
            //what needs to be validated?

            if ("1" == 1.ToString())
            {
                return true;
            }
            else
            {
                ErrorMessage = "What did you do?!";
                return false;
            }
        }

        private bool CorrectQuiz()
        {
            //om inte alla frågor är besvarade, skicka ett prompt för att bekräfta
            if (!ReadyToHandIn())
                return false;

            //save the result
            SaveResult();

            return true;
        }

        private bool ReadyToHandIn()
        {
            if ("1" == 1.ToString()) //PromptWindow
            {
                ErrorMessage = "";
                return true;
            }
            else
            {
                ErrorMessage = "Hand in cancelled";
                return false;
            }
        }

>>>>>>> refs/remotes/origin/takeQuiz
        private void SaveResult()
        {
            Result res = new Result
            {
                Score = CalculateScore(),
                Quiz = ActiveQuiz,
<<<<<<< HEAD
                User = _student //not needed?
            };

            _student.Results.Add(res);
            Repository<User>.GetInstance().UpdateData(_student); //saves quiz too?
=======
                User = ActiveQuiz.User //not needed?
            };

            ActiveQuiz.User.Results.Add(res);
            Repository<User>.GetInstance().UpdateData(ActiveQuiz.User); //saves quiz too?
>>>>>>> refs/remotes/origin/takeQuiz
        }

        private int CalculateScore()
        {
            int score = 0;

            foreach (var item in ActiveQuiz.Questions)
            {
                switch (item.Type)
                {
                    case Enums.QuestionType.SingleChoiceQuestion:
                        ScoreSingleChoice(item, ref score);
                        break;
                    case Enums.QuestionType.MultiChoiceQuestion:
                        ScoreMultiChoice(item, ref score);
                        break;
                    case Enums.QuestionType.RankQuestion:
                        ScoreRanked(item, ref score);
                        break;
                    default:
                        break;
                }
            }
            return score;
        }

        private void ScoreSingleChoice(Question question, ref int score)
        {
            foreach (var item in question.Alternatives)
            {
                //if(item.ScoreValue >0 && )
            }
        }

        private void ScoreMultiChoice(Question question, ref int score)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            //throw new NotImplementedException();
>>>>>>> refs/remotes/origin/takeQuiz
        }

        private void ScoreRanked(Question question, ref int score)
        {
<<<<<<< HEAD
            throw new NotImplementedException();
=======
            //throw new NotImplementedException();
>>>>>>> refs/remotes/origin/takeQuiz
        }
    }
}
