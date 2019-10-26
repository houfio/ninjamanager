using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NinjaManager.View;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        public NinjaListModel List { get; }
        public ICommand EditCommand { get; }

        public InventoryViewModel(NinjaListModel list)
        {
            List = list;
            EditCommand = new RelayCommand(Edit);
        }

        private void Edit()
        {
            new EditNinjaView().Show();
        }
    }
}
