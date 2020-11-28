using DesktopApp.Windows;
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
    /// Interaction logic for CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        public CreateTestPage()
        {
            InitializeComponent();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskPage addTaskWindow = new AddTaskPage();
            addTaskWindow.ShowDialog();
        }
    }
}
