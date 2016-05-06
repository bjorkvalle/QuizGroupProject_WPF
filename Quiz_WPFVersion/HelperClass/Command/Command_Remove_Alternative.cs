using Quiz_WPFVersion.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz_WPFVersion.HelperClass.Command
{
    public class Command_Remove_Alternative : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CreateQuizViewModel vModel;

        public Command_Remove_Alternative(CreateQuizViewModel vModel)
        {
            this.vModel = vModel;
        }

        //public Command_Remove_Alternative()
        //{

        //}

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
        }
    }
}
