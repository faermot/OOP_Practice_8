using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.AdministratorPage.AdminUserControls
{
    public partial class AdminInfoOrderControl : UserControl
    {
        public AdminInfoOrderControl()
        {
            InitializeComponent();
            DataOrderInfo.ItemsSource = FrameNavigate.DB.OrderBoards
                .OrderBy(w => w.Order).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idOrder = (DataOrderInfo.SelectedItem as OrderBoard)?.OrderBoardID ?? -1;
            if (idOrder == -1) return;

            var result = MessageBox.Show("Хотите удалить заказ?",
                "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                OrderBoard orderBoard = FrameNavigate.DB.OrderBoards
                    .FirstOrDefault(b => b.OrderBoardID == idOrder);
                if (orderBoard != null)
                {
                    FrameNavigate.DB.OrderBoards.Remove(orderBoard);
                    FrameNavigate.DB.SaveChanges();
                    DataOrderInfo.ItemsSource = FrameNavigate.DB.OrderBoards
                        .OrderBy(w => w.Order).ToList();
                }
            }
        }
    }
}
