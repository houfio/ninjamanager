using NinjaManager.Domain;
using NinjaManager.Util;
using NinjaManager.ViewModel;
using System.Windows;

namespace NinjaManager.Command
{
    public class DeleteEquipmentCommand : GenericCommand<object, ShopViewModel>
    {
        public DeleteEquipmentCommand(ShopViewModel view) : base(view)
        {
        }

        public override void Execute(object args, ShopViewModel view)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {view.Selected.Name}?", "Ninja Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            var equipment = view.Selected;

            foreach (var ninja in view.List.Ninjas)
            {
                ninja.RemoveEquipment(equipment.Id);
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Equipments.Attach(equipment.Raw);
                entities.Equipments.Remove(equipment.Raw);

                entities.SaveChanges();
            }

            view.SelectEquipment(null);
            view.Equipment.Remove(equipment);
        }

        public override bool CanExecute(object args, ShopViewModel view)
        {
            return view.Selected != null && view.Equipment != null && view.Equipment.Count > 3;
        }
    }
}
