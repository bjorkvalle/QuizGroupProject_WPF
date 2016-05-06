using Quiz_WPFVersion.View._Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz_WPFVersion.ViewModels.Command
{
    public class TestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public NavigationWindowViewModel ViewModelBase { get; set; }

        public TestCommand(NavigationWindowViewModel viewModel)
        {
            this.ViewModelBase = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            //this.ViewModelBase.Simple();
           

        }
    }
}
