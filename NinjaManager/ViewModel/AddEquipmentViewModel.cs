using NinjaManager.Command;
using NinjaManager.Model;
using NinjaManager.Util;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class AddEquipmentViewModel : GenericViewModel
    {
        public ShopViewModel Shop { get; }
        public EquipmentModel Equipment { get; } = new EquipmentModel();
        public ICommand SaveCommand { get; }

        public AddEquipmentViewModel(ShopViewModel shop)
        {
            Shop = shop;
            SaveCommand = new AddEquipmentCommand(this);
        }
    }
}
