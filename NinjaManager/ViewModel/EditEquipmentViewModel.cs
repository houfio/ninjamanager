using GalaSoft.MvvmLight.Command;
using NinjaManager.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
using NinjaManager.Util;
using NinjaManager.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditEquipmentViewModel : GenericViewModel
    {
        public ShopViewModel Shop { get; }
        public EquipmentModel Equipment { get; set; } = new EquipmentModel();
        public ICommand SaveCommand { get; }

        public EditEquipmentViewModel(ShopViewModel shop)
        {
            Shop = shop;
            SaveCommand = new RelayCommand(saveEdit);

            Shop.PropertyChanged += HandlePropertyChange;
            UpdateDefault();
        }

        private void saveEdit()
        {
            using (var entities = new NinjaManagerEntities())
            {
                var equipment = entities.Equipments.First((n) => n.Id == Shop.Selected.Id);

                if (equipment != null)
                {
                    equipment.Agility = Equipment.Agility;
                    equipment.Intelligence = Equipment.Intelligence;
                    equipment.Name = Equipment.Name;
                    equipment.Price = Equipment.Price;
                    equipment.Strength = Equipment.Strength;

                    Shop.Selected.Copy(Equipment);

                    entities.SaveChanges();
                }
            }

            //args.Close();
        }
        private void HandlePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(Shop.Selected))
            {
                UpdateDefault();
            }
        }

        public void Close()
        {
            Shop.PropertyChanged -= HandlePropertyChange;
        }

        private void UpdateDefault()
        {
            if (Shop.Selected != null)
            {
                Equipment = Shop.Selected.Clone();
            }
        }
    }


}
