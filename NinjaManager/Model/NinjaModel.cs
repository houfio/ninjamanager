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
            if (HasEquipment(equipment))
            {
                return;
            }

            Equipment.Add(equipment);
            RaisePropertiesChanged(nameof(Strength), nameof(Intelligence), nameof(Agility));
        }

        public void RemoveEquipment(int id)
        {
            var equipment = Equipment.Where((e) => e.Id == id).FirstOrDefault();

            if (equipment == null)
            {
                return;
            }

            Equipment.Remove(equipment);
            RaisePropertiesChanged(nameof(Strength), nameof(Intelligence), nameof(Agility));
        }

        private bool HasEquipment(EquipmentModel equipment)
        {
            return Equipment.Where((e) => e.Category == equipment.Category).Any();
        }
    }
}
