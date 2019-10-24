using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.View.NinjaList;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace NinjaManager.ViewModel.NinjaList
{
    public class NinjaListModel
    {
        public ObservableCollection<Ninja> Ninjas { get; set; }


        private AddNinjaWindow _addNinjaWindow;

        public ICommand AddNinjaCommand { get; set; }

        public NinjaListModel()
        {
            AddNinjaCommand = new RelayCommand(AddNinja);

            using (var entities = new NinjaManagerEntities())
            {
                var ninjas = entities.Ninjas.ToList();

                Ninjas = new ObservableCollection<Ninja>(ninjas);
            }
        }

        private void AddNinja()
        {
            _addNinjaWindow = new AddNinjaWindow();
            _addNinjaWindow.Show();
        }
    }
}
