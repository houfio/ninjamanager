using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModel.NinjaList;

namespace NinjaManager.ViewModel
{
    public class ViewModelLocator
    {
        public NinjaListModel NinjaList => ServiceLocator.Current.GetInstance<NinjaListModel>();
        public AddNinjaModel AddNinja => new AddNinjaModel(NinjaList);

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NinjaListModel>();
            SimpleIoc.Default.Register<AddNinjaModel>();
        }
    }    
}

