using GalaSoft.MvvmLight.Command;
using NinjaManager.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
using NinjaManager.Util;
using NinjaManager.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class ShopViewModel : GenericViewModel, IClosable
    {
        public NinjaListModel List { get; }
        public ICommand CategoryCommand { get; }
        public ICommand AddEquipmentCommand { get; }
        public ICommand EquipmentCommand { get; }
        public ICommand BuyCommand { get; }
        public ICommand SellCommand { get; }
        public ICommand DeleteCommand { get; }
        public Collection<string> Categories { get; }
        public Collection<EquipmentModel> Equipment { get; }
        public EquipmentModel Selected { get => _selected == -1 || _selected >= Equipment.Count ? null : Equipment[_selected]; set => Set(ref _selected, Equipment.IndexOf(value)); }
        public Visibility EquipmentVisiblity => Equipment.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        public Visibility DetailVisiblity => Selected != null ? Visibility.Visible : Visibility.Hidden;

        private int _selected = -1;
        private AddEquipmentView _addView;

        public ShopViewModel(NinjaListModel list)
        {
            List = list;
            CategoryCommand = new RelayCommand<string>(SelectCategory);
            AddEquipmentCommand = new RelayCommand(() => OpenWindow(ref _addView, () => _addView = null));
            EquipmentCommand = new RelayCommand<EquipmentModel>(SelectEquipment);
            BuyCommand = new BuyCommand(this);
            SellCommand = new SellCommand(this);
            DeleteCommand = new DeleteEquipmentCommand(this);
            Equipment = new ObservableCollection<EquipmentModel>();

            using (var entities = new NinjaManagerEntities())
            {
                Categories = new ObservableCollection<string>(entities.Categories.OrderBy((c) => c.Order).Select((c) => c.Name).ToList());
            }
        }

        public void Close()
        {
            CloseWindows(_addView);
        }

        public void SelectEquipment(EquipmentModel equipment)
        {
            Selected = equipment;
            RaisePropertyChanged(nameof(DetailVisiblity));
        }

        private void SelectCategory(string category)
        {
            using (var entities = new NinjaManagerEntities())
            {
                var list = entities.Equipments.Where((e) => e.Category == category).ToList();

                Equipment.Clear();

                foreach (var equipment in list)
                {
                    Equipment.Add(EquipmentModel.FromRaw(equipment));
                }
            }

            SelectEquipment(null);
            RaisePropertyChanged(nameof(EquipmentVisiblity));
        }
    }
}
