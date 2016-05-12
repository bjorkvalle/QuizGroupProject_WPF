using Quiz_StudentApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_StudentApp.Models
{
    public class QuizCorrector
    {
        public string ErrorMessage { get; set; }
        private Quiz _quiz;

        public QuizCorrector(Quiz quiz)
        {
            _quiz = quiz;
        }

        public bool HandleQuiz()
        {
            //validate quiz data
            if (!ValidateQuizData())
                return false;

            //correct the quiz
            if (!CorrectQuiz())
                return false;

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

        public void SaveResult()
        {
            Result res = new Result
            {
                Score = CalculateScore(),
                QuizId = _quiz.Id,
                UserId = _quiz.User.Id //not needed?
            };

            Repository<Result>.GetInstance().AddData(res);
        }

        private int CalculateScore()
        {
            int score = 0;

            foreach (var item in _quiz.Questions)
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

        //done
        private void ScoreSingleChoice(Question question, ref int score)
        {
            foreach (var item in question.Alternatives)
            {
                if (item.ScoreValue > 0 && item.AnsweredValue > 0)
                    score++;
            }
        }

        private void ScoreMultiChoice(Question question, ref int score)
        {
            int tempScore = 0;

            foreach (var item in question.Alternatives)
            {
                if (item.ScoreValue > 0 && item.AnsweredValue > 0) //rätt svarsalternativ och användaren har svarat att det är är rätt
                    tempScore++;
                else if (item.ScoreValue <= 0 && item.AnsweredValue > 0) //fel svarsalternativ men användaren har svarat att det är är rätt
                    tempScore--;
            }
            score += tempScore > 0 ? tempScore : 0;
        }

        private void ScoreRanked(Question question, ref int score)
        {
            int tempScore = 0;

            foreach (var item in question.Alternatives)
            {
                if (item.ScoreValue == item.AnsweredValue)
                    tempScore++;
            }
            score += tempScore > 0 ? tempScore : 0;
        }
    }
}
