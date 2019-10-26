using GalaSoft.MvvmLight;

namespace NinjaManager.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        public NinjaListModel List { get; }

        public ShopViewModel(NinjaListModel list)
        {
            List = list;
        }
    }
}
