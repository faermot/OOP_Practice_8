using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CW.FreelanceWork.View.Pages.LoginPage
{
    public partial class MainWindowRegistrationPage : Page
    {
        public MainWindowRegistrationPage()
        {
            InitializeComponent();
        }

        private async void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbFullName.Text) ||
                string.IsNullOrEmpty(TbPhone.Text)    ||
                string.IsNullOrEmpty(TbEmail.Text)    ||
                string.IsNullOrEmpty(TbSkills.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Системное сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (FrameNavigate.DB.Users.Count(u => u.FIO == TbFullName.Text) > 0)
            {
                MessageBox.Show("Пользователь с такими инициалами уже зарегистрирован!",
                    "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                FrameNavigate.DB.Users.Add(new User
                {
                    UserID     = FrameNavigate.DB.NextUserID(),
                    FIO        = TbFullName.Text,
                    UserPhone  = TbPhone.Text,
                    UserMail   = TbEmail.Text,
                    UserSkills = TbSkills.Text,
                    RoleID     = 2
                });

                await FrameNavigate.DB.SaveChangesAsync();

                MessageBox.Show("Учетная запись создана!\n\nЛогин: " + TbEmail.Text +
                                "\nПароль: " + TbPhone.Text,
                    "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                FrameNavigate.FrameObject.Navigate(new MainWindowLoginPage());
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
