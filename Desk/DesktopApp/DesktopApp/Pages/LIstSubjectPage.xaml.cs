using DesktopApp.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DesktopApp.Pages
{
    /// <summary>
    /// Interaction logic for LIstSubjectPage.xaml
    /// </summary>
    public partial class LIstSubjectPage : Page
    {
        public LIstSubjectPage()
        {
            InitializeComponent();
            AnimLvSubject.ItemsSource = AppData.Context.SubjectOfTeacher.ToList().Where(p => p.TeacherId == AppData.user.Id).ToList()
                .GroupBy(p => p.Subject.Name);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppData.MainFrame.Navigate(new ListOfExerciseAndStudents(((sender as Grid).DataContext as Entities.SubjectOfTeacher)));
        }

        private void BtnCreateTest_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CreateTestPage());
        }
    }
}
