﻿using GalaSoft.MvvmLight.Command;
using NinjaManager.Domain;
using NinjaManager.Model;
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
                entities.Ninjas.Add(Ninja.Raw);
                entities.SaveChanges();
            }

            _model.Ninjas.Add(Ninja);
            window.Close();
        }
    }
}
