using NinjaManager.Command;
using NinjaManager.Model;
using NinjaManager.Util;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class AddNinjaViewModel : GenericViewModel
    {
        public NinjaListModel List { get; }
        public NinjaModel Ninja { get; } = new NinjaModel()
        {
            Gold = 5000
        };
        public ICommand SaveCommand { get; }

        public AddNinjaViewModel(NinjaListModel list)
        {
            List = list;
            SaveCommand = new AddNinjaCommand(this);
        }
    }
}
