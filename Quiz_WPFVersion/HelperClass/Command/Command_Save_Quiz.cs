using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz_WPFVersion.HelperClass.Command
{
    public class Command_Save_Quiz : ICommand
    {
        public event EventHandler CanExecuteChanged;
        CreateQuizViewModel vModel;

        IRepository repo;

        public Command_Save_Quiz(CreateQuizViewModel vModel)
        {
            this.vModel = vModel;

        }

        public bool CanExecute(object parameter)
        {
            

            if (CheckEmptyValues())
            {
                              
                vModel.createQuizView.lblMessageBoard.Content = "• Kan inte spara. Vissa fält är inte ifyllda";
                return false;
            }
            else
            {

                return true;
            }
        }

        private bool CheckEmptyValues()
        {



            foreach (var question in vModel.questionList)
            {
                if (String.IsNullOrEmpty(question.Title)) return true;
                if (question.Alternatives.Count < 1) return true;

                foreach (var alternative in question.Alternatives)
                {
                    if (String.IsNullOrEmpty(alternative.Title)) return true;
                }
            }
            return false;

        }

        public void Execute(object parameter)
        {

            //repo.AddQuiz(new Quiz
            //{
            //    Title = vModel.createQuizView.txtbHeader.Text,
            //    Description = vModel.createQuizView.txtbDescription.Text,
            //    Questions = vModel.questionList,
            //});

            vModel.createQuizView.lblMessageBoard.Content = "• Provet är nu sparat.";

            //Clear
            vModel.questionList.Clear();
            vModel.createQuizView.txtbHeader.Text = "";
            vModel.createQuizView.txtbDescription.Text = "";
        }

        //private void DivideRightScoreValue()
        //{

        //}
    }
}
