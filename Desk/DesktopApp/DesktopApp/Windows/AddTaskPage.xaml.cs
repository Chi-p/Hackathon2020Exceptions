using DesktopApp.Classes;
using DesktopApp.Entities;
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
using System.Windows.Shapes;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Window
    {
        private Entities.Task _task;
        public AddTaskPage()
        {
            InitializeComponent();
            _task = new Entities.Task
            {
                
            }
        }
        private void MIAddValue_Click(object sender, RoutedEventArgs e)
        {
            AddValueWindow addValueWindow = new AddValueWindow(TbDescruption.Text, TbDescruption.Text, _task);
            addValueWindow.ShowDialog();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
