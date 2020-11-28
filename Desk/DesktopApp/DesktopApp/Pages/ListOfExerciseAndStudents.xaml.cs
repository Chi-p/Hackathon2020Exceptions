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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for ListOfExerciseAndStudents.xaml
    /// </summary>
    public partial class ListOfExerciseAndStudents : Page
    {
        public ListOfExerciseAndStudents(Group group)
        {
            InitializeComponent();
            if (group != null)
            {
                AnimLvExercise.ItemsSource = AppData.Context.ExerciseOfStudent.ToList().Where(p => group.Student.Contains(p.Student)).ToList()
                    .GroupBy(p => p.Exercise.Name);
              
            }
        }
    }
}
