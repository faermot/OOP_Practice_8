using CW.FreelanceWork.Core;
using CW.FreelanceWork.Model;
using CW.FreelanceWork.View.Pages.LoginPage;
using System.Windows;
using System.Windows.Input;

namespace CW.FreelanceWork.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameNavigate.FrameObject = MainWindowFrame;
            FrameNavigate.DB = new FreelanceWorkDBEntities();
            MainWindowFrame.Navigate(new MainWindowLoginPage());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
