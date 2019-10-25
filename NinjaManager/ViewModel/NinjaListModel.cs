using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.View.NinjaList;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
            DeleteNinjaCommand = new RelayCommand<Ninja>(DeleteNinja);
            ShowNinjaCommand = new RelayCommand<Ninja>(ShowNinja);

            using (var entities = new NinjaManagerEntities())
            {
                Ninjas = new ObservableCollection<Ninja>(entities.Ninjas.ToList());
            }
        }

        private void AddNinja()
        {
            new AddNinjaWindow().Show();
        }

        private void DeleteNinja(Ninja ninja)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {ninja.Name}?", "Ninja Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Attach(ninja);
                entities.Ninjas.Remove(ninja);
                entities.SaveChanges();

                Ninjas.Remove(ninja);
            }
        }

        private void ShowNinja(Ninja ninja)
        {
            MessageBox.Show(ninja.Name, "Ninja Manager");
        }
    }
}
