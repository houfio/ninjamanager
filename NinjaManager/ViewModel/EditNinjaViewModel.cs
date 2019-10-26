using NinjaManager.Command;
using NinjaManager.Util;
using System.ComponentModel;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditNinjaViewModel : GenericViewModel, IClosable
    {
        public NinjaListModel List { get; }
        public ICommand SaveCommand { get; }
        public string Name { get => _name; set => Set(ref _name, value); }
        public int Gold { get => _gold; set => Set(ref _gold, value); }

        private string _name;
        private int _gold;

        public EditNinjaViewModel(NinjaListModel list)
        {
            List = list;
            SaveCommand = new EditNinjaCommand(this);

            List.PropertyChanged += HandlePropertyChange;
            UpdateDefault();
        }

        public void Close()
        {
            List.PropertyChanged -= HandlePropertyChange;
        }

        private void HandlePropertyChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Selected")
            {
                UpdateDefault();
            }
        }

        private void UpdateDefault()
        {
            Name = List.Selected.Name;
            Gold = List.Selected.Gold;
        }
    }
}
