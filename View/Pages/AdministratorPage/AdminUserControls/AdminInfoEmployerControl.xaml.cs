using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.AdministratorPage.AdminUserControls
{
    public partial class AdminInfoEmployerControl : UserControl
    {
        public AdminInfoEmployerControl()
        {
            InitializeComponent();
            DataEmploerInfo.ItemsSource = FrameNavigate.DB.Employers
                .OrderBy(e => e.FIO).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idEmploer = (DataEmploerInfo.SelectedItem as Employer)?.EmployerID ?? -1;
            if (idEmploer == -1) return;

            var result = MessageBox.Show("Хотите удалить компанию?",
                "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Employer employer = FrameNavigate.DB.Employers
                    .FirstOrDefault(m => m.EmployerID == idEmploer);
                if (employer != null)
                {
                    FrameNavigate.DB.Employers.Remove(employer);
                    FrameNavigate.DB.SaveChanges();
                    DataEmploerInfo.ItemsSource = FrameNavigate.DB.Employers
                        .OrderBy(m => m.FIO).ToList();
                }
            }
        }
    }
}
