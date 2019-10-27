using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModel;

namespace NinjaManager.Util
{
    public class ViewModelLocator
    {
        public NinjaListViewModel NinjaList => ServiceLocator.Current.GetInstance<NinjaListViewModel>();
        public AddNinjaViewModel AddNinja => new AddNinjaViewModel(NinjaList);
        public InventoryViewModel Inventory => ServiceLocator.Current.GetInstance<InventoryViewModel>();
        public EditNinjaViewModel EditNinja => new EditNinjaViewModel(NinjaList);
        public ShopViewModel Shop => ServiceLocator.Current.GetInstance<ShopViewModel>();
        public AddEquipmentViewModel AddEquipment => new AddEquipmentViewModel(Shop);
        public EditEquipmentViewModel EditEquipment => new EditEquipmentViewModel(Shop);

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NinjaListViewModel>();
            SimpleIoc.Default.Register<InventoryViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
        }
    }    
}
