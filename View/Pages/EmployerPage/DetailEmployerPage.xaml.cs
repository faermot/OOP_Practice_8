using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using CW.FreelanceWork.View.Pages.LoginPage;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.EmployerPage
{
    public partial class DetailEmployerPage : Page
    {
        public DetailEmployerPage()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbTitle.Text) ||
                string.IsNullOrEmpty(TbTime.Text)  ||
                string.IsNullOrEmpty(TbOrder.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int newId = FrameNavigate.DB.NextOrderID();

            // Add order for demo (no real employer tied — first employer used as placeholder)
            FrameNavigate.DB.OrderBoards.Add(new OrderBoard
            {
                OrderBoardID = newId,
                Order        = TbTitle.Text + " — " + TbOrder.Text,
                EmployerID   = 1,
                UserID       = null
            });
            FrameNavigate.DB.SaveChanges();

            MessageBox.Show($"Заказ № {newId} отправлен на модерирование",
                "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

            ClearTextBox();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new LoginEmploerPage());
        }

        private void ClearTextBox()
        {
            TbTitle.Text = string.Empty;
            TbTime.Text  = string.Empty;
            TbOrder.Text = string.Empty;
        }
    }
}
