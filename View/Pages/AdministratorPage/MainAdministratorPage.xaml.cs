using CW.FreelanceWork.Core;
using CW.FreelanceWork.View.Pages.AdministratorPage.AdminUserControls;
using CW.FreelanceWork.View.Pages.LoginPage;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.AdministratorPage
{
    public partial class MainAdministratorPage : Page
    {
        public MainAdministratorPage()
        {
            InitializeComponent();
            // Load users section by default
            GridContenLoad.Children.Clear();
            GridContenLoad.Children.Add(new AdminInfoUserControl());
        }

        private void MenuItemUser_Click(object sender, RoutedEventArgs e)
        {
            GridContenLoad.Children.Clear();
            GridContenLoad.Children.Add(new AdminInfoUserControl());
        }

        private void MenuEmployer_Click(object sender, RoutedEventArgs e)
        {
            GridContenLoad.Children.Clear();
            GridContenLoad.Children.Add(new AdminInfoEmployerControl());
        }

        private void MenuItemOrder_Click(object sender, RoutedEventArgs e)
        {
            GridContenLoad.Children.Clear();
            GridContenLoad.Children.Add(new AdminInfoOrderControl());
        }

        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }
    }
}
