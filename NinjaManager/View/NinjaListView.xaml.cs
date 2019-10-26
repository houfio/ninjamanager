using System.Windows;

namespace NinjaManager.View
{
    public partial class NinjaListView : Window
    {
        public NinjaListView()
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
