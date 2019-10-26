using NinjaManager.Util;
using NinjaManager.ViewModel;

namespace NinjaManager.Command
{
    public class BuyCommand : GenericCommand<object, ShopViewModel>
    {
        public BuyCommand(ShopViewModel view) : base(view)
        {
        }

        public override void Execute(object args, ShopViewModel view)
        {
            view.List.Selected.AddEquipment(view.Selected);
        }

        public override bool CanExecute(object args, ShopViewModel view)
        {
            var equipment = view.Selected;
            var ninja = view.List.Selected;

            if (equipment == null)
            {
                return false;
            }

            return ninja.Gold >= equipment.Price && ninja.GetEquipment(equipment.Category) == null;
        }
    }
}
