using System.Windows;

namespace NinjaManager.View
{
    public partial class EditNinjaView : Window 
    {
        public EditNinjaView()
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
