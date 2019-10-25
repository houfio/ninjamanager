using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.ViewModel.NinjaList;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class AddNinjaModel
    {
        public Ninja Ninja { get; } = new Ninja()
        {
            Gold = 5000
        };
        public ICommand SaveCommand { get; }

        private NinjaListModel _model;

        public AddNinjaModel(NinjaListModel model)
        {
            _model = model;

            SaveCommand = new RelayCommand<Window>(Save);
        }

        private void Save(Window window)
        {
            if (string.IsNullOrEmpty(Ninja.Name))
            {
                MessageBox.Show("Please enter a name");

                return;
            }

            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Add(Ninja);
                entities.SaveChanges();
            }

            _model.Ninjas.Add(Ninja);
            window.Close();
        }
    }
}
