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
using System.Windows.Shapes;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for StudentAnswerDataGrid.xaml
    /// </summary>
    public partial class StudentAnswerDataGrid : Window
    {
        public StudentAnswerDataGrid(Entities.Task task)
        {
            InitializeComponent();
            DgAnwer.ItemsSource = AppData.Context.TaskAnswer.ToList().Where(p => p.Task == task);
        }
    }
}
