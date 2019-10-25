using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
using NinjaManager.View;
using NinjaManager.View.NinjaList;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel.NinjaList
{
    public class NinjaListModel : ViewModelBase
    {
        public ObservableCollection<NinjaModel> Ninjas { get; set; }
        public NinjaModel Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }
        public ICommand AddNinjaCommand { get; }
        public ICommand DeleteNinjaCommand { get; }
        public ICommand ShowNinjaCommand { get; }

        private NinjaModel _selected;

        public NinjaListModel()
        {
            AddNinjaCommand = new RelayCommand(AddNinja);
            DeleteNinjaCommand = new RelayCommand<NinjaModel>(DeleteNinja);
            ShowNinjaCommand = new RelayCommand(ShowNinja);

            using (var entities = new NinjaManagerEntities())
            {
                Ninjas = new ObservableCollection<NinjaModel>(entities.Ninjas.ToList().Select(NinjaModel.FromRaw));
            }
        }

        private void AddNinja()
        {
            new AddNinjaWindow().Show();
        }

        private void DeleteNinja(NinjaModel ninja)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {ninja.Name}?", "Ninja Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            using (var entities = new NinjaManagerEntities())
            {
                var raw = ninja.GetRaw();

                entities.Ninjas.Attach(raw);
                entities.Ninjas.Remove(raw);
                entities.SaveChanges();

                Ninjas.Remove(ninja);
            }
        }

        private void ShowNinja()
        {
            new InventoryView().Show();
        }
    }
}
