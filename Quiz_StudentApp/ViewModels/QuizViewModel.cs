using Quiz_StudentApp.Data;
using Quiz_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace Quiz_StudentApp.ViewModels
{
    public class QuizViewModel
    {
        public Quiz ActiveQuiz { get; set; }
        public string ErrorMessage { get; set; }

        private User _student;

        public QuizViewModel(Quiz quiz)
        {
            ActiveQuiz = quiz;
            _student = Repository<User>.GetInstance().GetDataList().Where(x => x.Id == quiz.UserId) as User;
        }

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

        private void SaveResult()
        {
            Result res = new Result
            {
                Score = CalculateScore(),
                Quiz = ActiveQuiz,
                User = _student //not needed?
            };

            _student.Results.Add(res);
            Repository<User>.GetInstance().UpdateData(_student); //saves quiz too?
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
            throw new NotImplementedException();
        }

        private void ScoreRanked(Question question, ref int score)
        {
            throw new NotImplementedException();
        }
    }
}
