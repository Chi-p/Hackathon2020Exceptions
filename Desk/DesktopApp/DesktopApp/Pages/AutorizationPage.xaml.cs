using DesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbLogin.Text) && String.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Введите данные для входа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var user = AppData.Context.User.ToList().FirstOrDefault(p => p.Login == TbLogin.Text && p.Password == PbPassword.Password);
            if (user != null)
            {
                switch (user.RoleId)
                {
                    case 1:
                        if (CbIsRemember.IsChecked == true)
                        {
                            Properties.Settings.Default.Login = user.Login;
                            Properties.Settings.Default.Password = user.Password;
                            Properties.Settings.Default.Save();
                        }
                        AppData.user = user;
                        AppData.MainFrame.Navigate(new LIstSubjectPage());
                        break;
                    case 2:
                        MessageBox.Show("Десктопная версия для студентов пока не доступна!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
