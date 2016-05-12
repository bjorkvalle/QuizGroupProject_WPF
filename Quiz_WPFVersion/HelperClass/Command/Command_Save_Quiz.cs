using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.HelperClass.Command
{
    public class Command_Save_Quiz : ICommand
    {
        public event EventHandler CanExecuteChanged;
        CreateQuizViewModel vModel;

        Repository<Quiz> repo = new Repository<Quiz>();

        public Command_Save_Quiz(CreateQuizViewModel vModel)
        {
            this.vModel = vModel;

        }

        public bool CanExecute(object parameter)
        {

            if (CheckEmptyValues())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckEmptyValues()
        {
            string message = "• Kan inte spara. Vissa fält är inte ifyllda";
            foreach (var question in vModel.questionList)
            {
                if (String.IsNullOrEmpty(question.Title)) { vModel.createQuizView.lblMessageBoard.Content = message; return true; }
                if (question.ScoreValue == 0) { vModel.createQuizView.lblMessageBoard.Content = message; return true; }
                if (question.Alternatives.Count < 1) { vModel.createQuizView.lblMessageBoard.Content = message; return true; }

                Boolean isChecked = false;
                foreach (var alternative in question.Alternatives)
                {
                    if (String.IsNullOrEmpty(alternative.Title)) { vModel.createQuizView.lblMessageBoard.Content = message; return true; }
                    if (alternative.ScoreValue == 1) { isChecked = true; }
                }
                if (question.Type != Enum.QuestionType.RankQuestion && !isChecked) { vModel.createQuizView.lblMessageBoard.Content = message; return true; }
            }
            return false;

        }

        public void Execute(object parameter)
        {
            List<Question> listQuestion = QuestionListConverter(vModel.questionList);
            if (listQuestion == null || listQuestion.Count == 0) return;



            Repository<Quiz>.GetInstance().AddData(
                new Quiz
                {
                    Title = vModel.createQuizView.txtbHeader.Text,
                    Description = vModel.createQuizView.txtbDescription.Text,
                    Questions = listQuestion,
                    UserId = vModel.activeUser.Id,
                    ShowStudentResult = (bool)vModel.createQuizView.checkBoxResultat.IsChecked,
                    
                });


         

            vModel.createQuizView.lblMessageBoard.Content = "• Provet är nu sparat.";

            //Clear
            vModel.questionList.Clear();
            vModel.createQuizView.txtbHeader.Text = "";
            vModel.createQuizView.txtbDescription.Text = "";
        }

        private List<Question> QuestionListConverter(ObservableCollection<Question_Binding> questionList)
        {
            List<Question> questionList_converted = new List<Question>();

            foreach (var question in questionList)
            {
                questionList_converted.Add(new Question
                {
                    Title = question.Title,
                    Alternatives = AlternativeCorrectScore(question),
                    Type = question.Type,
                });
            }

            return questionList_converted;
        }

        public List<Alternative> AlternativeCorrectScore(Question_Binding question)
        {
            int counter = 0;
            foreach (var alternative in question.Alternatives)
            {
                if (question.Type == Enum.QuestionType.MultiChoiceQuestion)
                {

                    if (alternative.ScoreValue == 1)
                    {
                        alternative.ScoreValue = question.ScoreValue / question.Alternatives.Count * 1;
                    }
                    else
                    {
                        alternative.ScoreValue = question.ScoreValue / question.Alternatives.Count * -1;
                    }
                }
                else if (question.Type == Enum.QuestionType.SingleChoiceQuestion)
                {
                    if (alternative.ScoreValue == 1)
                    {
                        alternative.ScoreValue = question.ScoreValue;
                    }
                }
                else if (question.Type == Enum.QuestionType.RankQuestion)
                {
                    //alternative.ScoreValue = question.ScoreValue / question.Alternatives.Count;
                    counter++;
                    alternative.ScoreValue = counter;
                }
            }

            return question.Alternatives.ToList();
        }
    }
}
