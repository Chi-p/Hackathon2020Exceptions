using DesktopApp.Classes;
using DesktopApp.Entities;
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
    /// Interaction logic for ListOfExerciseAndStudents.xaml
    /// </summary>
    public partial class ListOfExerciseAndStudents : Page
    {
        public ListOfExerciseAndStudents(SubjectOfTeacher subjectOfTeacher)
        {
            InitializeComponent();
            if (subjectOfTeacher != null)
            {
                AnimLvExercise.ItemsSource = AppData.Context.ExerciseOfStudent.ToList().Where(p => p.SubjectOfTeacher == subjectOfTeacher)
                    .GroupBy(p => p.Exercise.Name).ToList();
                if (AnimLvExercise.ItemsSource == null)
                    BorderNull.Visibility = Visibility.Visible;
                else
                    BorderNull.Visibility = Visibility.Collapsed;

            }
        }
        private void BtnCreateTest_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CreateTestPage());
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StudentAnswerDataGrid studentAnswer = new StudentAnswerDataGrid((sender as Grid).DataContext as Entities.Task);
            studentAnswer.ShowDialog();
        }
    }
}
