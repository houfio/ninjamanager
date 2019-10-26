using System;
using System.Windows.Input;

namespace NinjaManager.Util
{
    public abstract class GenericCommand<T, V> : ICommand where V : GenericViewModel
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly V _view;

        public GenericCommand(V view)
        {
            _view = view;
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter, _view);
        }

        public abstract void Execute(T args, V view);

        public bool CanExecute(object parameter)
        {
            return CanExecute((T)parameter, _view);
        }

        public abstract bool CanExecute(T args, V view);
    }
}
