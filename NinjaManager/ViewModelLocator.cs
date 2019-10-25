using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModel.NinjaList;

namespace NinjaManager.ViewModel
{
    public class ViewModelLocator
    {
        public NinjaListModel NinjaList => ServiceLocator.Current.GetInstance<NinjaListModel>();
        public AddNinjaViewModel AddNinja => new AddNinjaViewModel(NinjaList);
        public InventoryViewModel Inventory => new InventoryViewModel(NinjaList);

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NinjaListModel>();
            SimpleIoc.Default.Register<AddNinjaViewModel>();
            SimpleIoc.Default.Register<InventoryViewModel>();
        }
    }    
}
