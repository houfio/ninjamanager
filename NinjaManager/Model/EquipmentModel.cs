using NinjaManager.Domain;
using NinjaManager.Util;

namespace NinjaManager.Model
{
    public class EquipmentModel : GenericModel<Equipment>
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

        public int Price
        {
            get => Raw.Price;
            set
            {
                Raw.Price = value;
                RaisePropertyChanged();
            }
        }

        public int Strength
        {
            get => Raw.Strength;
            set
            {
                Raw.Strength = value;
                RaisePropertyChanged();
            }
        }

        public int Intelligence
        {
            get => Raw.Intelligence;
            set
            {
                Raw.Intelligence = value;
                RaisePropertyChanged();
            }
        }

        public int Agility
        {
            get => Raw.Agility;
            set
            {
                Raw.Agility = value;
                RaisePropertyChanged();
            }
        }

        public string Category
        {
            get => Raw.Category;
            set
            {
                Raw.Category = value;
                RaisePropertyChanged();
            }
        }

        public static EquipmentModel FromRaw(Equipment raw)
        {
            return new EquipmentModel()
            {
                Raw = raw
            };
        }
    }
}
