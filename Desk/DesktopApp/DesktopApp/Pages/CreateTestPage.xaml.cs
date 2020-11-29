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
    /// Interaction logic for CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        private List<Entities.Task> _listTaskResult = new List<Entities.Task>();
        private Exercise _exercise;
        public CreateTestPage()
        {
            InitializeComponent();
            AppData.listTask.Clear();
            CbTypeExercise.ItemsSource = AppData.Context.TypeOfExercise.ToList();
            CbGroup.ItemsSource = AppData.Context.SubjectOfTeacher.ToList().Where(p => p.TeacherId == AppData.user.Id).ToList();
            IcTask.ItemsSource = null;
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskPage addTaskWindow = new AddTaskPage();
            addTaskWindow.ShowDialog();
            IcTask.ItemsSource = null;
            IcTask.ItemsSource = AppData.listTask;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            _exercise = AppData.Context.Exercise.Add(new Entities.Exercise
            {
                TypeOfExercise = CbTypeExercise.SelectedItem as TypeOfExercise,
                Name = TbName.Text,
            });
            AppData.Context.SaveChanges();
            foreach (var item in AppData.listTask)
            {
                _listTaskResult.Add(AppData.Context.Task.Add(new Entities.Task
                {
                    Id = 0,
                    Description = item.Description,
                }));
                AppData.Context.SaveChanges();
            }
            foreach (var item in _listTaskResult)
            {
                _exercise.Task.Add(item);
                AppData.Context.SaveChanges();
            }
            foreach (var student in AppData.Context.Student.ToList().Where(p => p.Group.Contains((CbGroup.SelectedItem as SubjectOfTeacher).Group)))
            {
                var a = AppData.Context.ExerciseOfStudent.Add(
                     new ExerciseOfStudent
                     {
                         Exercise = _exercise,
                         StatusId = 1,
                         SubjectOfTeacher = CbGroup.SelectedItem as SubjectOfTeacher,
                         Student = student
                     });
                AppData.Context.SaveChanges();
            }
        }

        private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IcTask.IsEnabled = true;
        }



        private void CbTypeExercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
