using NinjaManager.Domain;
using System.Collections.ObjectModel;
using System.Linq;

namespace NinjaManager.Model
{
    public class NinjaModel : GenericModel<Ninja>
    {
        public int Id => Raw.Id;

        public string Name
        {
            get => Raw.Name;
            set
            {
                Raw.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Gold
        {
            get => Raw.Gold;
            set
            {
                Raw.Gold = value;
                RaisePropertyChanged();
            }
        }

        public int Strength => Equipment.Aggregate(0, (previous, next) => previous + next.Strength);

        public int Intelligence => Equipment.Aggregate(0, (previous, next) => previous + next.Intelligence);

        public int Agility => Equipment.Aggregate(0, (previous, next) => previous + next.Agility);

        public int Value => Equipment.Aggregate(0, (previous, next) => previous + next.Price);

        public EquipmentModel Head => GetEquipment(nameof(Head));

        public EquipmentModel Shoulders => GetEquipment(nameof(Shoulders));

        public EquipmentModel Chest => GetEquipment(nameof(Chest));

        public EquipmentModel Belt => GetEquipment(nameof(Belt));

        public EquipmentModel Legs => GetEquipment(nameof(Legs));

        public EquipmentModel Boots => GetEquipment(nameof(Boots));

        public Collection<EquipmentModel> Equipment { get; } = new ObservableCollection<EquipmentModel>();

        public static NinjaModel FromRaw(Ninja raw)
        {
            var model = new NinjaModel
            {
                Raw = raw
            };

            foreach (var inventory in raw.Inventories)
            {
                model.AddEquipment(EquipmentModel.FromRaw(inventory.Equipment));
            }

            return model;
        }

        public void AddEquipment(EquipmentModel equipment)
        {
            if (GetEquipment(equipment.Category) != null)
            {
                return;
            }

            Equipment.Add(equipment);
            RaiseEquipmentChanged();
        }

        public void RemoveEquipment(int id)
        {
            var equipment = Equipment.Where((e) => e.Id == id).FirstOrDefault();

            if (equipment == null)
            {
                return;
            }

            Equipment.Remove(equipment);
            RaiseEquipmentChanged();
        }

        private void RaiseEquipmentChanged()
        {
            RaisePropertiesChanged(nameof(Strength), nameof(Intelligence), nameof(Agility), nameof(Value), nameof(Head));
        }

        private EquipmentModel GetEquipment(string category)
        {
            return Equipment.Where((e) => e.Category == category).FirstOrDefault();
        }
    }
}
