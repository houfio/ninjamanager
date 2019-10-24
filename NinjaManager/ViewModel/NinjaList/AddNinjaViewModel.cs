using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.View.NinjaList;


namespace NinjaManager.ViewModel.NinjaList
{
    public class AddNinjaViewModel
    {
        public NinjaViewModel NewNinja { get; set; }
        public NinjaListModel _ninjaListModel { get; set; }
        public ICommand SaveCommand { get; set; }

        public AddNinjaViewModel(NinjaListModel ninjaListVM)
        {
            _ninjaListModel = ninjaListVM;
            NewNinja = new NinjaViewModel();
            SaveCommand = new RelayCommand<AddNinjaWindow>(Save);
        }

        private void Save(AddNinjaWindow obj)
        {
            if (String.IsNullOrEmpty(NewNinja.Name))
            {
                MessageBox.Show("Please enter a name");
            }
            else
            {
                using (var entities = new NinjaManagerEntities())
                {
                    Ninja ninja = new Ninja();
                    ninja.Gold = 1000;
                    ninja.Name = NewNinja.Name;
                    entities.Ninjas.Add(ninja);
                    entities.SaveChanges();
                }
            }
        }


    }
}
