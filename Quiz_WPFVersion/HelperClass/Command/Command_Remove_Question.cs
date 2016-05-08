using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.ViewModels.Teacher;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Quiz_WPFVersion.HelperClass.Command
{
    public class Command_Remove_Question : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CreateQuizViewModel vModel;


        public Command_Remove_Question(CreateQuizViewModel vModel)
        {
            this.vModel = vModel;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var selObj = parameter as Question_Binding;
            //if (vModel.questionList.Count == 1)
            //{

            //    //System.Threading.Timer timer = null;
            //    //timer = new System.Threading.Timer((obj) =>
            //    //{
            //    //    vModel.questionList.Remove(selObj);
            //    //    timer.Dispose();
            //    //},
            //    //            null, 1000, System.Threading.Timeout.Infinite);

            //    //BackgroundWorker barInvoker = new BackgroundWorker();
            //    //barInvoker.DoWork += delegate
            //    //{
            //    //    Thread.Sleep(TimeSpan.FromSeconds(1));
            //    //    vModel.questionList.Remove(selObj);
            //    //};
            //    //barInvoker.RunWorkerAsync();

               
            //}
            //else
            //{

            //}
                vModel.questionList.Remove(selObj);

        }

    }
}
