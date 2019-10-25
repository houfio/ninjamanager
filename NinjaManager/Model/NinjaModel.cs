using NinjaManager.Domain;

namespace NinjaManager.Model
{
    public class NinjaModel
    {
        private Ninja _ninja;

        public int Id => _ninja.Id;

        public string Name
        {
            get => _ninja.Name;
            set => _ninja.Name = value;
        }

        public int Gold
        {
            get => _ninja.Gold;
            set => _ninja.Gold = value;
        }

        public NinjaModel()
        {
            _ninja = new Ninja();
        }

        public static NinjaModel FromRaw(Ninja ninja)
        {
            return new NinjaModel
            {
                _ninja = ninja
            };
        }

        public Ninja ToRaw()
        {
            return _ninja;
        }
    }
}
