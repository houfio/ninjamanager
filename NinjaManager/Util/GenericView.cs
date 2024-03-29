﻿using System.ComponentModel;
using System.Windows;

namespace NinjaManager.Util
{
    public class GenericView : Window
    {
        public GenericView()
        {
            Closing += HandleClosing;
        }

        private void HandleClosing(object sender, CancelEventArgs args)
        {
            if (DataContext is IClosable closable)
            {
                closable.Close();
            }
        }
    }
}
