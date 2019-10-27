using NinjaManager.Domain;
using NinjaManager.Util;
using NinjaManager.ViewModel;

namespace NinjaManager.Command
{
    public class AddEquipmentCommand : GenericCommand<GenericView, AddEquipmentViewModel>
    {
        public AddEquipmentCommand(AddEquipmentViewModel view) : base(view)
        {
        }

        public override void Execute(GenericView args, AddEquipmentViewModel view)
        {
            using (var entities = new NinjaManagerEntities())
            {
                view.Equipment.Category = view.Shop.Equipment[0].Category;

                entities.Equipments.Add(view.Equipment.Raw);
                entities.SaveChanges();
            }

            view.Shop.Equipment.Add(view.Equipment);

            args.Close();
        }

        public override bool CanExecute(GenericView args, AddEquipmentViewModel view)
        {
            return view.Shop.Equipment.Count > 0 && !string.IsNullOrWhiteSpace(view.Equipment.Name) && view.Equipment.Price > 0;
        }
    }
}
