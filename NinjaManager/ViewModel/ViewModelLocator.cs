using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using NinjaManager.ViewModel.NinjaList;

namespace NinjaManager.ViewModel
{
    public class ViewModelLocator
    {
        public NinjaListModel NinjaList => ServiceLocator.Current.GetInstance<NinjaListModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NinjaListModel>();
            SimpleIoc.Default.Register<AddNinjaViewModel>();

        }


        public NinjaListModel ShowNinjas {
            get {
                return ServiceLocator.Current.GetInstance<NinjaListModel>();
            }
        }

        public AddNinjaViewModel AddNinja
        {
            get
            {
                return new AddNinjaViewModel(ShowNinjas);
            }
        }
    }    
}

