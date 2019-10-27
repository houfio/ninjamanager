using NinjaManager.Domain;
using NinjaManager.Util;
using NinjaManager.ViewModel;

namespace NinjaManager.Command
{
    public class AddNinjaCommand : GenericCommand<GenericView, AddNinjaViewModel>
    {
        public AddNinjaCommand(AddNinjaViewModel view) : base(view)
        {
        }

        public override void Execute(GenericView args, AddNinjaViewModel view)
        {
            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Add(view.Ninja.Raw);
                entities.SaveChanges();
            }

            view.List.Ninjas.Add(view.Ninja);
            args.Close();
        }

        public override bool CanExecute(GenericView args, AddNinjaViewModel view)
        {
            return !string.IsNullOrWhiteSpace(view.Ninja.Name);
        }
    }
}
