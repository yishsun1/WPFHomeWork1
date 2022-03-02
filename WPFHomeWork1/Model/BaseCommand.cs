﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFHomeWork1
{
    public class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _execute;

        public BaseCommand(Action<object> execute = null)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute.Invoke(parameter);
        }
    }
}
