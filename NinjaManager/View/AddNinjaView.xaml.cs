using System.Windows;

namespace NinjaManager.View
{
    public partial class AddNinjaView : Window 
    {
        public AddNinjaView()
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
