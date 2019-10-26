﻿using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class ShopViewModel : GenericViewModel
    {
        public NinjaListModel List { get; }
        public Collection<string> Categories { get; }
        public Visibility EquipmentVisiblity => Equipment.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        public Visibility DetailVisiblity => Selected != null ? Visibility.Visible : Visibility.Hidden;
        public Collection<EquipmentModel> Equipment { get; }
        public EquipmentModel Selected { get => _selected == -1 || _selected >= Equipment.Count ? null : Equipment[_selected]; set => Set(ref _selected, Equipment.IndexOf(value)); }
        public ICommand CategoryCommand { get; }
        public ICommand EquipmentCommand { get; }

        private int _selected;

        public ShopViewModel(NinjaListModel list)
        {
            List = list;
            Equipment = new ObservableCollection<EquipmentModel>();
            CategoryCommand = new RelayCommand<string>(SelectCategory);
            EquipmentCommand = new RelayCommand<EquipmentModel>(SelectEquipment);

            using (var entities = new NinjaManagerEntities())
            {
                Categories = new ObservableCollection<string>(entities.Categories.OrderBy((c) => c.Order).Select((c) => c.Name).ToList());
            }
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

            RaisePropertyChanged(nameof(EquipmentVisiblity));
        }

        private void SelectEquipment(EquipmentModel equipment)
        {
            Selected = equipment;
            RaisePropertyChanged(nameof(DetailVisiblity));
        }
    }
}
