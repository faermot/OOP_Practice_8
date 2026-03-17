using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using CW.FreelanceWork.View.Pages.AdministratorPage;
using CW.FreelanceWork.View.Pages.EmployerPage;
using CW.FreelanceWork.View.Pages.UserPage;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.LoginPage
{
    public partial class MainWindowLoginPage : Page
    {
        public MainWindowLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = FrameNavigate.DB.Users
                    .FirstOrDefault(u => u.UserMail == TbLogin.Text
                                      && u.UserPhone == PsbPassword.Password);

                if (userModel == null)
                {
                    MessageBox.Show("Ошибка данных", "Системное сообщение",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                switch (userModel.RoleID)
                {
                    case 1:
                        FrameNavigate.FrameObject.Navigate(new MainAdministratorPage());
                        break;
                    case 2:
                        FrameNavigate.FrameObject.Navigate(new MainUserPage());
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль пользователя.", "Системное сообщение",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnWork_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainEmployerPage());
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowRegistrationPage());
        }
    }
}
