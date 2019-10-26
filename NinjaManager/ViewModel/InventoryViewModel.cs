using GalaSoft.MvvmLight.Command;
using NinjaManager.Model;
using NinjaManager.View;
using System.Collections.Generic;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : GenericViewModel, IClosable
    {
        public NinjaListModel List { get; }
        public ICommand ShopCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand ClearCommand { get; }

        private EditNinjaView _editWindow;
        private ShopView _shopWindow;

        public InventoryViewModel(NinjaListModel list)
        {
            List = list;
            EditCommand = new RelayCommand(Edit);
            ShopCommand = new RelayCommand(Shop);
            ClearCommand = new RelayCommand(Clear);
        }

        public void Close()
        {
            CloseWindows(_editWindow, _shopWindow);
        }

        private void Shop()
        {
            OpenWindow(ref _shopWindow, () => _shopWindow = null);
        }

        private void Edit()
        {
            OpenWindow(ref _editWindow, () => _editWindow = null);
        }

        private void Clear()
        {
            foreach (var equipment in new List<EquipmentModel>(List.Selected.Equipment))
            {
                List.Selected.RemoveEquipment(equipment.Id);
            }
        }
    }
}
