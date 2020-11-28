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
        private List<VariableValue> _variableValueList = new List<VariableValue>();
        private List<Variable> _variableList = new List<Variable>();
        private VariableValue _variableValue;
        private int _varCount = 0;
        public AddTaskPage()
        {
            InitializeComponent();

        }
        private void MIAddValue_Click(object sender, RoutedEventArgs e)
        {
            TbDescruption.Text += $" -var{_varCount}";
            _variableList.Add(new Variable
            {
                Id = _varCount,
                Name = $" -var{_varCount}",
            });
            _variableValueList.Add(new VariableValue
            {
                Value = "",
                Variable = _variableList.FirstOrDefault(predicate => predicate.Id == _varCount),
            });
            _variableValueList.Add(new VariableValue
            {
                Value = "",
                Variable = _variableList.FirstOrDefault(predicate => predicate.Id == _varCount),
            });
            IcValues.ItemsSource = _variableValueList.GroupBy(p => p.Variable.Name).ToList();
            _varCount++;
            TbDescruption.SelectionStart = TbDescruption.Text.Length;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddValue_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext;
            _variableValueList.Add(new VariableValue
            {
                Value = "",
                Variable = _variableList.FirstOrDefault(predicate => predicate.Name == ((sender as Button).DataContext as IGrouping<string, VariableValue>).Key)
            });
            IcValues.ItemsSource = null;
            IcValues.ItemsSource = _variableValueList.GroupBy(p => p.Variable.Name).ToList();
        }
    }
}
