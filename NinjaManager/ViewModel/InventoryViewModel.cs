using GalaSoft.MvvmLight;
using NinjaManager.Model;
using NinjaManager.ViewModel.NinjaList;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        public NinjaModel Ninja { get; }

        public InventoryViewModel(NinjaListModel model)
        {
            Ninja = model.Selected;
        }
    }
}
