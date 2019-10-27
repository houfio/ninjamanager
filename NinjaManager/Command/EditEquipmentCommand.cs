using NinjaManager.Domain;
using NinjaManager.Util;
using NinjaManager.ViewModel;
using System.Linq;

namespace NinjaManager.Command
{
    public class EditEquipmentCommand : GenericCommand<GenericView, EditEquipmentViewModel>
    {
        public EditEquipmentCommand(EditEquipmentViewModel view) : base(view)
        {
        }

        public override void Execute(GenericView args, EditEquipmentViewModel view)
        {
            using (var entities = new NinjaManagerEntities())
            {
                var equipment = entities.Equipments.First((e) => e.Id == view.Shop.Selected.Id);

                if (equipment != null)
                {
                    equipment.Agility = view.Equipment.Agility;
                    equipment.Intelligence = view.Equipment.Intelligence;
                    equipment.Name = view.Equipment.Name;
                    equipment.Price = view.Equipment.Price;
                    equipment.Strength = view.Equipment.Strength;
                    view.Shop.Selected.Copy(view.Equipment);
                    view.Shop.List.Selected.UpdateEquipment(equipment.Id, view.Equipment);

                    entities.SaveChanges();
                }
            }

            args.Close();
        }

        public override bool CanExecute(GenericView args, EditEquipmentViewModel view)
        {
            return !string.IsNullOrWhiteSpace(view.Equipment.Name) && view.Equipment.Price > 0;
        }
    }
}
