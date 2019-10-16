using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace NinjaManager.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}
