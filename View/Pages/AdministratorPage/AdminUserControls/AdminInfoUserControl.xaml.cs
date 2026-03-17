using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.AdministratorPage.AdminUserControls
{
    public partial class AdminInfoUserControl : UserControl
    {
        public AdminInfoUserControl()
        {
            InitializeComponent();
            DataUserInfo.ItemsSource = FrameNavigate.DB.Users
                .OrderBy(u => u.FIO).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idUser = (DataUserInfo.SelectedItem as User)?.UserID ?? -1;
            if (idUser == -1) return;

            var result = MessageBox.Show("Хотите удалить пользователя?",
                "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                User user = FrameNavigate.DB.Users
                    .FirstOrDefault(u => u.UserID == idUser);
                if (user != null)
                {
                    FrameNavigate.DB.Users.Remove(user);
                    FrameNavigate.DB.SaveChanges();
                    DataUserInfo.ItemsSource = FrameNavigate.DB.Users
                        .OrderBy(u => u.FIO).ToList();
                }
            }
        }
    }
}
