using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : ViewModelBase, IClosable
    {
        public NinjaListModel List { get; }
        public ICommand EditCommand { get; }
        public ICommand ShopCommand { get; }

        private EditNinjaView _editWindow;
        private ShopView _shopWindow;

        public InventoryViewModel(NinjaListModel list)
        {
            List = list;
            EditCommand = new RelayCommand(Edit);
            ShopCommand = new RelayCommand(Shop);
        }

        public void Close()
        {
            CloseWindows(_editWindow, _shopWindow);
        }

        private void Edit()
        {
            OpenWindow(ref _editWindow, () => _editWindow = null);
        }

        private void Shop()
        {
            OpenWindow(ref _shopWindow, () => _shopWindow = null);
        }

        private void OpenWindow<T>(ref T window, Action close) where T : Window, new()
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

        private void CloseWindows(params Window[] windows)
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
