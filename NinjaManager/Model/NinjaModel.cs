using NinjaManager.Domain;
using NinjaManager.Util;
using System.Collections.ObjectModel;
using System.Linq;

namespace NinjaManager.Model
{
    public class NinjaModel : GenericModel<Ninja, NinjaModel>
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

            foreach (var equipment in raw.Equipments)
            {
                model.Equipment.Add(EquipmentModel.FromRaw(equipment));
            }

            return model;
        }

        public override NinjaModel Clone()
        {
            return new NinjaModel
            {
                Raw = new Ninja()
                {
                    Name = Name,
                    Gold = Gold
                }
            };
        }

        public override void Copy(NinjaModel from)
        {
            Name = from.Name;
            Gold = from.Gold;
        }

        public void AddEquipment(EquipmentModel equipment)
        {
            if (Id == 0 || GetEquipment(equipment.Category) != null || Gold < equipment.Price)
            {
                return;
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Attach(Raw);
                entities.Equipments.Attach(equipment.Raw);

                Gold -= equipment.Price;
                Raw.Equipments.Add(equipment.Raw);

                entities.SaveChanges();
            }

            Equipment.Add(equipment);
            RaiseEquipmentChanged();
        }

        public void RemoveEquipment(int id)
        {
            var equipment = Equipment.Where((e) => e.Id == id).FirstOrDefault();

            if (Id == 0 || equipment == null)
            {
                return;
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Attach(Raw);

                Gold += equipment.Price;
                Raw.Equipments.Remove(equipment.Raw);

                entities.SaveChanges();
            }

            Equipment.Remove(equipment);
            RaiseEquipmentChanged();
        }

        public EquipmentModel GetEquipment(string category)
        {
            return Equipment.Where((e) => e.Category == category).FirstOrDefault();
        }

        private void RaiseEquipmentChanged()
        {
            RaisePropertiesChanged(nameof(Strength), nameof(Intelligence), nameof(Agility), nameof(Value), nameof(Head), nameof(Shoulders), nameof(Chest), nameof(Belt), nameof(Legs), nameof(Boots));
        }
    }
}
