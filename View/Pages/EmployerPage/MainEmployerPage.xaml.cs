using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using CW.FreelanceWork.View.Pages.LoginPage;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.EmployerPage
{
    public partial class MainEmployerPage : Page
    {
        public MainEmployerPage()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employer employerModel = FrameNavigate.DB.Employers
                    .FirstOrDefault(m => m.FIO == TbCompanyName.Text);

                if (employerModel == null)
                {
                    MessageBox.Show("Ошибка данных", "Системное сообщение",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Данные проверены, доступ разрешен", "Системное сообщение",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    BtnCheck.IsEnabled = false;
                    BtnLoginEmploer.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLoginEmploer_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new LoginEmploerPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }
    }
}
