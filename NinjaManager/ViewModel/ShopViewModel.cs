using NinjaManager.Domain;
using System.Collections.ObjectModel;
using System.Linq;

namespace NinjaManager.ViewModel
{
    public class ShopViewModel : GenericViewModel
    {
        public NinjaListModel List { get; }
        public Collection<string> Categories { get; }

        public ShopViewModel(NinjaListModel list)
        {
            List = list;

            using (var entities = new NinjaManagerEntities())
            {
                Categories = new ObservableCollection<string>(entities.Equipments.Select((e) => e.Category).Distinct().OrderBy((c) => c).ToList());
            }
        }
    }
}
