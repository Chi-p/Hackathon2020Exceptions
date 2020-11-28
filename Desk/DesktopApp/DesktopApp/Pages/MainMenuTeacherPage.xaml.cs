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
    /// Interaction logic for MainWindowTeacherPage.xaml
    /// </summary>
    public partial class MainMenuTeacherPage : Page
    {
        public MainMenuTeacherPage()
        {
            InitializeComponent();
        }

        private void BtnCreateTest_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CreateTestPage());
        }

        private void BtnListSubject_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new LIstSubjectPage());
        }
    }
}
