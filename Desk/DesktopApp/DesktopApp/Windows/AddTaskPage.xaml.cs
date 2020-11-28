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
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private void CbTypeOfTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Exercise ex = new Exercise();
            //var a = AppData.Context.Question.ToList().FirstOrDefault(i => i.Task.Exercise.ToList().FirstOrDefault(i => i == ex).ExerciseOfStudent.ToList().FirstOrDefault(i => i.Exercise == ex).StudentId);

            var st = AppData.Context.ExerciseOfStudent.ToList().FirstOrDefault(i => i.Exercise == ex);
        }
    }
}
