using NinjaManager.Command;
using NinjaManager.Model;
using NinjaManager.Util;
using System.ComponentModel;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditEquipmentViewModel : GenericViewModel, IClosable
    {
        public ShopViewModel Shop { get; }
        public ICommand SaveCommand { get; }
        public EquipmentModel Equipment { get => _equipment; set => Set(ref _equipment, value); }

        private EquipmentModel _equipment;

        public EditEquipmentViewModel(ShopViewModel shop)
        {
            Shop = shop;
            SaveCommand = new EditEquipmentCommand(this);

            Shop.PropertyChanged += HandlePropertyChange;
            UpdateDefault();
        }

        public void Close()
        {
            Shop.PropertyChanged -= HandlePropertyChange;
        }

        private void HandlePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(Shop.Selected))
            {
                UpdateDefault();
            }
        }

        private void UpdateDefault()
        {
            Equipment = Shop.Selected.Clone();
        }
    }
}
