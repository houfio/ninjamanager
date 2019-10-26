using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.View;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : ViewModelBase, IClosable
    {
        public NinjaListModel List { get; }
        public ICommand EditCommand { get; }

        private Window _editWindow;

        public InventoryViewModel(NinjaListModel list)
        {
            List = list;
            EditCommand = new RelayCommand(Edit);
        }

        public void Close()
        {
            CloseWindows(_editWindow);
        }

        private void Edit()
        {
            if (_editWindow != null)
            {
                return;
            }

            _editWindow = new EditNinjaView();
            _editWindow.Closed += delegate
            {
                _editWindow = null;
            };
            _editWindow.Show();
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
