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
        public ICommand AddNinjaCommand { get; }
        public ICommand DeleteNinjaCommand { get; }
        public ICommand ShowNinjaCommand { get; }

        public NinjaListModel()
        {
            AddNinjaCommand = new RelayCommand(AddNinja);
            DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            ShowNinjaCommand = new RelayCommand(ShowNinja);

            using (var entities = new NinjaManagerEntities())
            {
                Ninjas = new ObservableCollection<Ninja>(entities.Ninjas.ToList());
            }
        }

        private void AddNinja()
        {
            new AddNinjaWindow().Show();
        }

        private void DeleteNinja()
        {
        }

        private void ShowNinja()
        {
        }
    }
}
