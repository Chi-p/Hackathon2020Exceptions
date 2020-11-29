using DesktopApp.Classes;
using DesktopApp.Pages;
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
using System.Windows.Threading;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = AppData.Context.Variable.ToList();
            AppData.MainFrame = MainFrame;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }

        private static void Logout()
        {
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();
            AppData.user = null;
            AppData.MainFrame.Navigate(new AutorizationPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var page = AppData.MainFrame.Content as Page;
            if (AppData.user != null)
                TblName.Text = AppData.user.FIO;
            if (page.Title == "Авторизация")
            {
                BtnBack.Visibility = Visibility.Collapsed;
                GridWithTopThings.Visibility = Visibility.Collapsed;
            }
            else
            {
                GridWithTopThings.Visibility = Visibility.Visible;
                BtnBack.Visibility = Visibility.Visible;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var page = AppData.MainFrame.Content as Page;
            if (page.Title == "Главное меню")
            {
                Logout();
            }
            if (AppData.MainFrame.CanGoBack)
                AppData.MainFrame.GoBack();

        }

        public bool IsPressed { get; set; }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsPressed = true;
            this.DataContext = this;
            DispatcherTimer dtCountDown = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 250),
            };
            dtCountDown.Tick += DtCountDown_Tick;
            dtCountDown.Start();
        }

        double _countToNavigate = 0;
        private void DtCountDown_Tick(object sender, EventArgs e)
        {
            if (_countToNavigate == 0.25)
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Login) && !string.IsNullOrWhiteSpace(Properties.Settings.Default.Password))
                {

                    //await Task.Run(() =>
                    // {
                    AppData.user = AppData.Context.User.ToList().FirstOrDefault(p => p.Password == Properties.Settings.Default.Password && p.Login == Properties.Settings.Default.Login);
                    //});
                    if (AppData.user != null)
                    {
                        AppData.MainFrame.Navigate(new MainMenuTeacherPage());
                    }
                    else
                    {
                        AppData.MainFrame.Navigate(new AutorizationPage());
                    }
                }
                else
                {
                    AppData.MainFrame.Navigate(new AutorizationPage());
                }
                GridForAnimations.Visibility = Visibility.Collapsed;
                (sender as DispatcherTimer).Stop();
            }
            _countToNavigate += 0.25;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Image_MouseLeftButtonDown(null, null);
            }
        }
    }
}
