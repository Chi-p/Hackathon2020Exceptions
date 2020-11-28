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
            AppData.MainFrame = MainFrame;
            //MainFrame.Navigate(new AutorizationPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
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

        public bool IsPressed { get; set; }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsPressed = true;
            this.DataContext = this;
            DispatcherTimer dtCountDown = new DispatcherTimer()
            {
                Interval = new TimeSpan(0,0,0,0,250),
            };
            dtCountDown.Tick += DtCountDown_Tick;
            dtCountDown.Start();
        }

        double _countToNavigate = 0;
        private void DtCountDown_Tick(object sender, EventArgs e)
        {
            if (_countToNavigate == 0.25)
            { 
                MainFrame.Navigate(new AutorizationPage());
                (sender as DispatcherTimer).Stop();
            }
            _countToNavigate+=0.25;
        }
    }
}
