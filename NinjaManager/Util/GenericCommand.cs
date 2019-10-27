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
            if (!ValidPaarameter(parameter))
            {
                return;
            }

            Execute((T)parameter, _view);
        }

        public abstract void Execute(T args, V view);

        public bool CanExecute(object parameter)
        {
            if (!ValidPaarameter(parameter))
            {
                return false;
            }

            return CanExecute((T)parameter, _view);
        }

        public abstract bool CanExecute(T args, V view);

        private bool ValidPaarameter(object parameter)
        {
            return parameter == null || parameter is T;
        }
    }
}
