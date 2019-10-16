using GalaSoft.MvvmLight;
using NinjaManager.Domain;

namespace NinjaManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            using (var entities = new NinjaManagerEntities())
            {
                entities.SaveChanges();
            }
        }
    }
}
