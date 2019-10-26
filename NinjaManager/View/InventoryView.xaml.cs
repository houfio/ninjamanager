using System.Windows;

namespace NinjaManager.View
{
    public partial class InventoryView : Window
    {
        public InventoryView()
        {
            InitializeComponent();

            Closed += delegate
            {
                if (DataContext is IClosable)
                {
                    ((IClosable)DataContext).Close();
                }
            };
        }
    }
}
