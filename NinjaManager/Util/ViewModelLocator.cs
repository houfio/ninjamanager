using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModel;

namespace NinjaManager.Util
{
    public class ViewModelLocator
    {
        public NinjaListModel NinjaList => ServiceLocator.Current.GetInstance<NinjaListModel>();
        public AddNinjaViewModel AddNinja => new AddNinjaViewModel(NinjaList);
        public InventoryViewModel Inventory => new InventoryViewModel(NinjaList);
        public EditNinjaViewModel EditNinja => new EditNinjaViewModel(NinjaList);
        public ShopViewModel Shop => new ShopViewModel(NinjaList);

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NinjaListModel>();
            SimpleIoc.Default.Register<AddNinjaViewModel>();
            SimpleIoc.Default.Register<InventoryViewModel>();
            SimpleIoc.Default.Register<EditNinjaViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
        }
    }    
}
