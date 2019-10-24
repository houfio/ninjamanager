using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.View.NinjaList;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace NinjaManager.ViewModel.NinjaList
{
    public class NinjaListModel
    {
        public ObservableCollection<Ninja> Ninjas { get; set; }
        private AddNinjaWindow _addNinjaWindow;

        //TODO:
        //- VIEW NINJA
        //- EDIT NINJA
        //- DELETE NINJA

        public ICommand AddNinjaCommand { get; set; }
        public ICommand DeleteNinjaCommand { get; set; }

        private Ninja _selectedNinja;

        public NinjaListModel()
        {
            AddNinjaCommand = new RelayCommand(AddNinja);
            AddNinjaCommand = new RelayCommand(DeleteNinja);

            using (var entities = new NinjaManagerEntities())
            {
                var ninjas = entities.Ninjas.ToList();

                Ninjas = new ObservableCollection<Ninja>(ninjas);
            }
        }

        private void AddNinja()
        {
            _addNinjaWindow = new AddNinjaWindow();
            _addNinjaWindow.Show();
        }

        private void DeleteNinja()
        {
            using (var entities = new NinjaManagerEntities())
            {
                //var removeElement = SelectedNinja;
                //Ninjas.Remove(removeElement);
                
            }
        }
    }
}
