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

namespace UUS
{
    /// <summary>
    /// Логика взаимодействия для DekanGroupEdit.xaml
    /// </summary>
    public partial class DekanGroupEdit : Page
    {
        private Group _curentGroup;
        public DekanGroupEdit(Group group)
        {
            InitializeComponent();
            _curentGroup = group;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UUSEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            // Запрос на выборку студентов в таблицу "Студенты"
            var students = from u in UUSEntities.GetContext().Users
                           join s in UUSEntities.GetContext().Students on u.userID equals s.userID
                           join g in UUSEntities.GetContext().Groups on s.groupID equals g.groupID
                           join sp in UUSEntities.GetContext().Specialty on g.specialtyID equals sp.specialtyID
                           select new
                           {
                               StudentSurname = u.surname,
                               StudentName = u.name,
                               StudentPatronymic = u.patronymic,
                               StudentGroupNmb = g.groupNMB,
                               StudentSpeciality = sp.specialtyName,
                               UserID = u.userID
                           };
            Student_Data.ItemsSource = students.ToList().Where(s=> s.StudentGroupNmb == _curentGroup.groupNMB);
            
            GroupNmbLabel.Content = _curentGroup.groupNMB;

            var speciality = UUSEntities.GetContext().Specialty.Where(s => s.specialtyID == _curentGroup.specialtyID).FirstOrDefault();

            SpecialityNameLabel.Content = speciality.specialtyName;
        }
        private void OpenStudentDataBtn(object sender, RoutedEventArgs e)
        {
            var curentStudent = (sender as Button).DataContext;
            try
            {
                var users = UUSEntities.GetContext().Users.ToList();
                foreach (var user in users)
                {
                    if (curentStudent.ToString().Contains("UserID = " + user.userID.ToString()))
                    {
                        Manager.MainFrame.Navigate(new StudentEdit(user));
                    }
                }
                //Manager.MainFrame.Navigate(new StudentEdit(null));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void AddStudentBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddStudentToGroup(_curentGroup));
        }
    }
}
