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
                ((IClosable)DataContext).Close();
            };
        }
    }
}
