using NinjaManager.Util;
using NinjaManager.ViewModel;
using System.Linq;

namespace NinjaManager.Command
{
    public class SellCommand : GenericCommand<object, ShopViewModel>
    {
        public SellCommand(ShopViewModel view) : base(view)
        {
        }

        public override void Execute(object args, ShopViewModel view)
        {
            view.List.Selected.RemoveEquipment(view.Selected.Id);
        }

        public override bool CanExecute(object args, ShopViewModel view)
        {
            var equipment = view.Selected;
            var ninja = view.List.Selected;

            if (equipment == null)
            {
                return false;
            }

            return ninja.Equipment.Where((e) => e.Id == equipment.Id).Any();
        }
    }
}
