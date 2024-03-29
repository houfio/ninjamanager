﻿using GalaSoft.MvvmLight.Command;
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
        public NinjaListViewModel List { get; }
        public ICommand CategoryCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EquipmentCommand { get; }
        public ICommand BuyCommand { get; }
        public ICommand SellCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public Collection<string> Categories { get; }
        public Collection<EquipmentModel> Equipment { get; }
        public EquipmentModel Selected { get => _selected == -1 || _selected >= Equipment.Count ? null : Equipment[_selected]; set => Set(ref _selected, Equipment.IndexOf(value)); }
        public Visibility EquipmentVisiblity => Equipment.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        public Visibility DetailVisiblity => Selected != null ? Visibility.Visible : Visibility.Hidden;

        private int _selected = -1;
        private AddEquipmentView _addView;
        private EditEquipmentView _editView;

        public ShopViewModel(NinjaListViewModel list)
        {
            List = list;
            CategoryCommand = new RelayCommand<string>(SelectCategory);
            AddCommand = new RelayCommand(() => OpenWindow(ref _addView, () => _addView = null));
            EquipmentCommand = new RelayCommand<EquipmentModel>(SelectEquipment);
            BuyCommand = new BuyCommand(this);
            SellCommand = new SellCommand(this);
            EditCommand = new RelayCommand(() => OpenWindow(ref _editView, () => _editView = null));
            DeleteCommand = new DeleteEquipmentCommand(this);
            Equipment = new ObservableCollection<EquipmentModel>();

            using (var entities = new NinjaManagerEntities())
            {
                Categories = new ObservableCollection<string>(entities.Categories.OrderBy((c) => c.Order).Select((c) => c.Name).ToList());
            }
        }

        public void Close()
        {
            CloseWindows(_addView, _editView);
            SelectCategory(null);
        }

        public void SelectEquipment(EquipmentModel equipment)
        {
            Selected = equipment;
            RaisePropertyChanged(nameof(DetailVisiblity));
        }

        private void SelectCategory(string category)
        {
            CloseWindows(_editView);

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
