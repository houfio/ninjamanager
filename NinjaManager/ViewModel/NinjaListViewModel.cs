using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
using NinjaManager.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class NinjaListModel : ViewModelBase
    {
        public ObservableCollection<NinjaModel> Ninjas { get; set; }
        public ICommand AddNinjaCommand { get; }
        public ICommand DeleteNinjaCommand { get; }
        public ICommand ShowNinjaCommand { get; }
        public NinjaModel Selected { get => Ninjas[_selected]; set => Set(ref _selected, Ninjas.IndexOf(value)); }

        private int _selected;
        private Window _inventoryView;

        public NinjaListModel()
        {
            AddNinjaCommand = new RelayCommand(AddNinja);
            DeleteNinjaCommand = new RelayCommand<NinjaModel>(DeleteNinja);
            ShowNinjaCommand = new RelayCommand<NinjaModel>(ShowNinja);

            using (var entities = new NinjaManagerEntities())
            {
                Ninjas = new ObservableCollection<NinjaModel>(entities.Ninjas.ToList().Select(NinjaModel.FromRaw));
            }
        }

        private void AddNinja()
        {
            new AddNinjaView().Show();
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
                entities.Ninjas.Attach(ninja.Raw);
                entities.Ninjas.Remove(ninja.Raw);
                entities.SaveChanges();

                Ninjas.Remove(ninja);
            }

            if (Selected != ninja || _inventoryView == null)
            {
                return;
            }

            _inventoryView.Close();
        }

        private void ShowNinja(NinjaModel ninja)
        {
            Selected = ninja;

            if (_inventoryView != null)
            {
                return;
            }

            _inventoryView = new InventoryView();
            _inventoryView.Closed += delegate
            {
                _inventoryView = null;
            };
            _inventoryView.Show();
        }
    }
}
