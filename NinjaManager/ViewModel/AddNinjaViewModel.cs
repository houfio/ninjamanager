using NinjaManager.Domain;
using NinjaManager.Model;
using NinjaManager.Util;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class AddNinjaViewModel : GenericViewModel
    {
        public NinjaModel Ninja { get; } = new NinjaModel()
        {
            Gold = 5000
        };
        public ICommand SaveCommand { get; }

        private NinjaListModel _model;

        public AddNinjaViewModel(NinjaListModel model)
        {
            _model = model;

            SaveCommand = new BlockableCommand<Window>(Save, CanSave);
        }

        private void Save(Window window)
        {
            using (var entities = new NinjaManagerEntities())
            {
                entities.Ninjas.Add(Ninja.Raw);
                entities.SaveChanges();
            }

            _model.Ninjas.Add(Ninja);
            window.Close();
        }

        private bool CanSave(Window window)
        {
            return !string.IsNullOrEmpty(Ninja.Name);
        }
    }
}
