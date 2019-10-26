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
    public class NinjaListModel : GenericViewModel, IClosable
    {
        public Collection<NinjaModel> Ninjas { get; set; }
        public ICommand AddNinjaCommand { get; }
        public ICommand DeleteNinjaCommand { get; }
        public ICommand ShowNinjaCommand { get; }
        public NinjaModel Selected { get => Ninjas[_selected]; set => Set(ref _selected, Ninjas.IndexOf(value)); }

        private int _selected;
        private InventoryView _inventoryView;
        private AddNinjaView _addView;

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

        public void Close()
        {
            CloseWindows(_inventoryView, _addView);
        }

        private void AddNinja()
        {
            OpenWindow(ref _addView, () => _addView = null);
        }

        private void DeleteNinja(NinjaModel ninja)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {ninja.Name}?", "Ninja Manager", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            if (Selected == ninja && _inventoryView != null)
            {
                _inventoryView.Close();
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Attach(ninja.Raw);
                entities.Ninjas.Remove(ninja.Raw);
                entities.SaveChanges();

                Ninjas.Remove(ninja);
            }
        }

        private void ShowNinja(NinjaModel ninja)
        {
            Selected = ninja;

            OpenWindow(ref _inventoryView, () => _inventoryView = null);
        }
    }
}
