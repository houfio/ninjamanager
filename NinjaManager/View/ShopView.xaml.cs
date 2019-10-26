using System.Windows;

namespace NinjaManager.View
{
    public partial class ShopView : Window
    {
        public ShopView()
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
