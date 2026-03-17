using CW.FreelanceWork.Core;
using CW.FreelanceWork.View.Pages.LoginPage;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CW.FreelanceWork.View.Pages.UserPage
{
    public partial class MainUserPage : Page
    {
        public MainUserPage()
        {
            InitializeComponent();
            DataOrderInfo.ItemsSource = FrameNavigate.DB.OrderBoards
                .OrderBy(f => f.Order).ToList();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заявка отправлена на рассмотрение модерации",
                "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
