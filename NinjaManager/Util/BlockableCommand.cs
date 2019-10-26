using System;
using System.Windows.Input;

namespace NinjaManager.Util
{
    public class BlockableCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private Action<T> _execute;
        private Predicate<T> _canExecute;

        public BlockableCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }
    }
}
