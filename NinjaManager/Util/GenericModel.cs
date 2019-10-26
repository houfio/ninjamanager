using GalaSoft.MvvmLight;

namespace NinjaManager.Util
{
    public class GenericModel<T> : ViewModelBase where T : new()
    {
        public T Raw { get; protected set; }

        public GenericModel() : this(new T())
        {
        }

        public GenericModel(T model)
        {
            Raw = model;
        }

        public void RaisePropertiesChanged(params string[] properties)
        {
            foreach (var property in properties)
            {
                RaisePropertyChanged(property);
            }
        }
    }
}
