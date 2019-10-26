using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.View;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : GenericViewModel, IClosable
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
    }
}
