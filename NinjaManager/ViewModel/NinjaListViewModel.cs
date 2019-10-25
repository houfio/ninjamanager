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
        public ICommand AddNinjaCommand { get; }
        public ICommand DeleteNinjaCommand { get; }
        public ICommand ShowNinjaCommand { get; }
        public NinjaModel Selected { get => _selected; private set => Set(ref _selected, value); }

        private NinjaModel _selected;
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
                var raw = ninja.ToRaw();

                entities.Ninjas.Attach(raw);
                entities.Ninjas.Remove(raw);
                entities.SaveChanges();

                Ninjas.Remove(ninja);
            }

            if (Selected != ninja)
            {
                return;
            }

            CloseWindows(_inventoryView);
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

        private void CloseWindows(params Window[] windows)
        {
            foreach (var window in windows)
            {
                if (window != null)
                {
                    window.Close();
                }
            }
        }
    }
}
