using NinjaManager.Domain;
using System.Collections.ObjectModel;
using System.Linq;

namespace NinjaManager.ViewModel.NinjaList
{
    public class NinjaListModel
    {
        public ObservableCollection<Ninja> Ninjas { get; set; }

        public NinjaListModel()
        {
            using (var entities = new NinjaManagerEntities())
            {
                var ninjas = entities.Ninjas.ToList();

                Ninjas = new ObservableCollection<Ninja>(ninjas);
            }
        }
    }
}
