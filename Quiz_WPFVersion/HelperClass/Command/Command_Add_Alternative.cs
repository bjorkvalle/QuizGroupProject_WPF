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
    public class Command_Add_Alternative : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private CreateQuizViewModel vModel;

        public Command_Add_Alternative(CreateQuizViewModel vModel)
        {
            this.vModel = vModel;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var x = parameter as Question;
            x.Alternatives.Add(new Alternative());
        }
    }
}
