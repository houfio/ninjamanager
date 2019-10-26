using System.ComponentModel;
using System.Windows;

namespace NinjaManager
{
    public class GenericView : Window
    {
        public GenericView()
        {
            Closing += HandleClosing;
        }

        private void HandleClosing(object sender, CancelEventArgs args)
        {
            if (DataContext is IClosable)
            {
                ((IClosable)DataContext).Close();
            }
        }
    }
}
