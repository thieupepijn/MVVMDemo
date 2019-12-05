using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo
{
    public class RelayCommand : ICommand
    {
        Action _execute;
        Func<bool> _canExecute;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canexecute)
        {
            _execute = execute;
            _canExecute = canexecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            else
            {
                return _canExecute.Invoke();
            }
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public void Update()
        {
            CanExecuteChanged(this, new EventArgs());
        }
        

    }
}
