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
using System.Data.Entity;

namespace UUS
{
    /// <summary>
    /// Логика взаимодействия для UUSWindowPage.xaml
    /// </summary>
    public partial class DekanPage : Page
    {
        private User _curentUser;
        public DekanPage(User user)
        {
            InitializeComponent();
            LoadData(user);
            _curentUser = user;
            
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

        private void LoadData(User user)
        {
            Surname_Label.Content = user.surname; ;
            Name_Label.Content = user.name;
            Patronymic_Label.Content = user.patronymic;
            Email_Label.Content = user.email;
            Phone_Label.Content = user.phone;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
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
                Student_Data.ItemsSource = students.ToList();

                // Запрос на выборку групп в таблицу "Группы" 
                var groups = from g in UUSEntities.GetContext().Groups
                             join sp in UUSEntities.GetContext().Specialty on g.specialtyID equals sp.specialtyID
                             select new
                             {
                                 GroupNmb = g.groupNMB,
                                 SpecialityName = sp.specialtyName
                             };
                Groups_Data.ItemsSource = groups.ToList();

                // Загрузка данных в таблицу "Специальности"
                Speciality_Data.ItemsSource = UUSEntities.GetContext().Specialty.ToList();

                // Запрос на выборку курсов в таблицу "Курсы"
                var cources = from c in UUSEntities.GetContext().Course
                              join u in UUSEntities.GetContext().Users on c.userID equals u.userID
                              select new
                              {
                                  CourceName = c.courseName,
                                  Hours = c.numberOfHours,
                                  ReportForm = c.reportForm,
                                  AuthorCource = u.surname + " " + u.name + " " + u.patronymic
                              };
                Cources_Data.ItemsSource = cources.ToList();
               // Journal_Data.ItemsSource = UUSEntities.GetContext().SelectAllJournal().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        private void OpenGroup(object sender, RoutedEventArgs e)
        {
            var curentGroup = (sender as Button).DataContext;
            try
            {
                var groups = UUSEntities.GetContext().Groups.ToList();
                foreach (var group in groups)
                {
                    if (curentGroup.ToString().Contains("GroupNmb = " + group.groupNMB.ToString()))
                    {
                        Manager.MainFrame.Navigate(new DekanGroupEdit(group));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenSpecialityAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager.MainFrame.Navigate(new SpecialityAddEditPage(null));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void OpenSpecialityEdit(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager.MainFrame.Navigate(new SpecialityAddEditPage((sender as Button).DataContext as Specialty));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteSpeciality(object sender, RoutedEventArgs e)
        {
            var specialityForRemoving = Speciality_Data.SelectedItems.Cast<Specialty>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {specialityForRemoving.Count()} элементов?","Внимание",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    UUSEntities.GetContext().Specialty.RemoveRange(specialityForRemoving);
                    UUSEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    Speciality_Data.ItemsSource = UUSEntities.GetContext().Specialty.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void DeleteCources_Click(object sender, RoutedEventArgs e)
        {
            var courcesForRemoving = (sender as Button).DataContext;
            if (MessageBox.Show($"Вы точно хотите удалить следующий элемент?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var courses = UUSEntities.GetContext().Course.ToList();
                    foreach(var course in courses)
                    {
                        if (courcesForRemoving.ToString().Contains(course.courseName))
                            UUSEntities.GetContext().Course.Remove(course);
                    }
                    UUSEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    var cources = from c in UUSEntities.GetContext().Course
                                  join u in UUSEntities.GetContext().Users on c.userID equals u.userID
                                  select new
                                  {
                                      CourceName = c.courseName,
                                      Hours = c.numberOfHours,
                                      ReportForm = c.reportForm,
                                      AuthorCource = u.surname + " " + u.name + " " + u.patronymic
                                  };
                    Cources_Data.ItemsSource = cources.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void OpenCourceEdit(object sender, RoutedEventArgs e)
        {
            var selectedCource = (sender as Button).DataContext;
            try
            {
                var cources = UUSEntities.GetContext().Course.ToList();
                foreach (var cource in cources)
                {
                    if (selectedCource.ToString().Contains("CourceName = " + cource.courseName.ToString()))
                    {
                        Manager.MainFrame.Navigate(new CourceAddEdit(_curentUser, cource));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CourceAddClick(object sender, RoutedEventArgs e)
        {
            var selectedCource = (sender as Button).DataContext;
            try
            {
                 Manager.MainFrame.Navigate(new CourceAddEdit(_curentUser, null));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}
