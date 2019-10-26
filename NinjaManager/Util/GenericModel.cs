using GalaSoft.MvvmLight;

namespace NinjaManager.Util
{
    public abstract class GenericModel<T, V> : ViewModelBase where T : new() where V : GenericModel<T, V>
    {
        public T Raw { get; protected set; }

        public GenericModel() : this(new T())
        {
        }

        public GenericModel(T model)
        {
            Raw = model;
        }

        public abstract V Clone();

        public abstract void Copy(V from);

        public void RaisePropertiesChanged(params string[] properties)
        {
            foreach (var property in properties)
            {
                RaisePropertyChanged(property);
            }
        }
    }
}
