using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.Util;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditNinjaViewModel : GenericViewModel
    {
        public string Name { get => _name; set => Set(ref _name, value); }
        public int Gold { get => _gold; set => Set(ref _gold, value); }
        public ICommand SaveCommand { get; }

        private string _name;
        private int _gold;
        private NinjaListModel _model;

        public EditNinjaViewModel(NinjaListModel model)
        {
            _model = model;
            _model.PropertyChanged += (obj, args) =>
            {
                if (args.PropertyName == "Selected")
                {
                    UpdateDefault();
                }
            };

            SaveCommand = new RelayCommand<Window>(Save);

            UpdateDefault();
        }

        private void UpdateDefault()
        {
            Name = _model.Selected.Name;
            Gold = _model.Selected.Gold;
        }

        private void Save(Window window)
        {
            using (var entities = new NinjaManagerEntities())
            {
                var ninja = entities.Ninjas.First((n) => n.Id == _model.Selected.Id);

                if (ninja != null)
                {
                    _model.Selected.Name = ninja.Name = Name;
                    _model.Selected.Gold = ninja.Gold = Gold;

                    entities.SaveChanges();
                }
            }

            window.Close();
        }
    }
}
