using GalaSoft.MvvmLight;
using System;
using System.Windows;

namespace NinjaManager
{
    public class GenericViewModel : ViewModelBase
    {
        protected void OpenWindow<T>(ref T window, Action close) where T : Window, new()
        {
            if (window != null)
            {
                return;
            }

            window = new T();
            window.Closed += delegate
            {
                close();
            };
            window.Show();
        }

        protected void CloseWindows(params Window[] windows)
        {
            foreach (var window in windows)
            {
                if (window != null)
                {
                    window.Close();
                }
            }
        }
    }
}
