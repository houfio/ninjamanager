using NinjaManager.Domain;
using NinjaManager.Util;
using NinjaManager.ViewModel;
using System.Linq;

namespace NinjaManager.Command
{
    public class EditNinjaCommand : GenericCommand<GenericView, EditNinjaViewModel>
    {
        public EditNinjaCommand(EditNinjaViewModel view) : base(view)
        {
        }

        public override void Execute(GenericView args, EditNinjaViewModel view)
        {
            using (var entities = new NinjaManagerEntities())
            {
                var ninja = entities.Ninjas.First((n) => n.Id == view.List.Selected.Id);

                if (ninja != null)
                {
                    ninja.Name = view.Ninja.Name;
                    ninja.Gold = view.Ninja.Gold;
                    view.List.Selected.Copy(view.Ninja);

                    entities.SaveChanges();
                }
            }

            args.Close();
        }

        public override bool CanExecute(GenericView args, EditNinjaViewModel view)
        {
            return !string.IsNullOrEmpty(view.Ninja.Name);
        }
    }
}
