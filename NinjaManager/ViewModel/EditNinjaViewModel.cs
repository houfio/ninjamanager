﻿using NinjaManager.Command;
using NinjaManager.Model;
using NinjaManager.Util;
using System.ComponentModel;
using System.Windows.Input;

namespace NinjaManager.ViewModel
{
    public class EditNinjaViewModel : GenericViewModel, IClosable
    {
        public NinjaListViewModel List { get; }
        public ICommand SaveCommand { get; }
        public NinjaModel Ninja { get => _ninja; set => Set(ref _ninja, value); }

        private NinjaModel _ninja;

        public EditNinjaViewModel(NinjaListViewModel list)
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
            if (args.PropertyName == nameof(List.Selected))
            {
                UpdateDefault();
            }
        }

        private void UpdateDefault()
        {
            Ninja = List.Selected.Clone();
        }
    }
}
