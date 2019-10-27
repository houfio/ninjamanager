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

            using (var entities = new NinjaManagerEntities())
            {
                entities.Equipments.Attach(view.Selected.Raw);
                entities.Equipments.Remove(view.Selected.Raw);

                view.List.Selected.Equipment.Remove(view.Selected);

                entities.SaveChanges();
            }
        }

        public override bool CanExecute(object args, ShopViewModel view)
        {
            return view.Selected != null && view.Equipment != null && view.Equipment.Count > 3;
        }
    }
}
