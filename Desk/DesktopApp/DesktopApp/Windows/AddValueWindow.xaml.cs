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
using Task = DesktopApp.Entities.Task;

namespace DesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for AddValueWindow.xaml
    /// </summary>
    public partial class AddValueWindow : Window
    {
        private List<VariableValue> _variableValueList;
        private VariableValue _variableValue;
        private Variable _variable;
        public AddValueWindow(string TastDescription, string varibleName, Task task)
        {
            InitializeComponent();
        }

        private void TbNewValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            _variableValue = new VariableValue
            {
                Value = (sender as TextBox).Text,
            };
        }

        private void TbNewValue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                _variableValueList.Add(_variableValue);
            }
        }

        private void TbNewValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                (sender as TextBox).Focusable = false;
            }
        }
    }
}
