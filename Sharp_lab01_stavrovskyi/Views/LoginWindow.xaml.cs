using System.Windows.Controls;
using Sharp_lab01_stavrovskyi.ViewModels;

namespace Sharp_lab01_stavrovskyi
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
