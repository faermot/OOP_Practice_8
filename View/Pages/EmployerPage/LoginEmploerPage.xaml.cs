using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using CW.FreelanceWork.View.Pages.LoginPage;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.EmployerPage
{
    public partial class LoginEmploerPage : Page
    {
        public LoginEmploerPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employer userModel = FrameNavigate.DB.Employers
                    .FirstOrDefault(u => u.EmployerMail == TbLogin.Text
                                      && u.EmployerPhone == PsbPassword.Password);

                if (userModel == null)
                {
                    MessageBox.Show("Ошибка данных", "Системное сообщение",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    FrameNavigate.FrameObject.Navigate(new DetailEmployerPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
        }
    }
}
