using GalaSoft.MvvmLight.Command;
using NinjaManager.Model;
using NinjaManager.Util;
using NinjaManager.View;
using System.Collections.Generic;
using System.Windows;
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
            ShopCommand = new RelayCommand(() => OpenWindow(ref _shopWindow, () => _shopWindow = null));
            EditCommand = new RelayCommand(() => OpenWindow(ref _editWindow, () => _editWindow = null));
            ClearCommand = new RelayCommand(Clear);
        }

        public void Close()
        {
            CloseWindows(_editWindow, _shopWindow);
        }

        private void Clear()
        {
            var result = MessageBox.Show($"Are you sure you want clear {List.Selected.Name}'s inventory?", "Ninja Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            foreach (var equipment in new List<EquipmentModel>(List.Selected.Equipment))
            {
                List.Selected.RemoveEquipment(equipment.Id);
            }
        }
    }
}
