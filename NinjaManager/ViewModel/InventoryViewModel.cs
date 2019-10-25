using GalaSoft.MvvmLight;
using NinjaManager.ViewModel.NinjaList;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        public NinjaListModel List { get; }

        public InventoryViewModel(NinjaListModel list)
        {
            List = list;
        }
    }
}
