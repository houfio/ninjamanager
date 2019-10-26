using GalaSoft.MvvmLight;
using System;

namespace NinjaManager
{
    public class GenericViewModel : ViewModelBase
    {
        protected void OpenWindow<T>(ref T view, Action close) where T : GenericView, new()
        {
            if (view != null)
            {
                view.Focus();

                return;
            }

            view = new T();
            view.Closed += delegate
            {
                close();
            };
            view.Show();
        }

        protected void CloseWindows(params GenericView[] views)
        {
            foreach (var view in views)
            {
                if (view != null)
                {
                    view.Close();
                }
            }
        }
    }
}
