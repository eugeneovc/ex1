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
    /// Логика взаимодействия для StudentEdit.xaml
    /// </summary>
    public partial class StudentEdit : Page
    {
        private User _curentUser;
        private Student _curentStudent;
        public StudentEdit(User cStudent)
        {
            InitializeComponent();
            _curentUser = cStudent;
            LoadData();
            
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void LoadData()
        {
            var student = UUSEntities.GetContext().Students.Where(s => s.userID == _curentUser.userID).FirstOrDefault();
            _curentStudent = student;
            var groups = UUSEntities.GetContext().Groups.Where(g => g.groupID == student.groupID).FirstOrDefault(); 
            var speciality = UUSEntities.GetContext().Specialty.Where(s => s.specialtyID == groups.specialtyID).FirstOrDefault();
            SurnameTxb.Text = _curentUser.surname;
            NameTxb.Text = _curentUser.name;
            PatronymicTxb.Text = _curentUser.patronymic;
            GroupTxb.Text = groups.groupNMB.ToString();
            SpecialityTxb.Text = speciality.specialtyName;
            JournalDG.ItemsSource = UUSEntities.GetContext().SelectAllJournal().ToList().Where(s=>s.studentID == student.studentID);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            SurnameTxb.IsEnabled = true;
            NameTxb.IsEnabled = true;
            PatronymicTxb.IsEnabled = true;
            GroupTxb.IsEnabled = true;
            ApplyBtn.Visibility = Visibility.Visible;

        }
        private void ApplyEdit_Click(object sender,RoutedEventArgs e)
        {
            _curentUser.surname = SurnameTxb.Text;
            _curentUser.name = NameTxb.Text;
            _curentUser.patronymic = PatronymicTxb.Text;
            var group = UUSEntities.GetContext().Groups.Where(g => g.groupNMB.ToString() == GroupTxb.Text).FirstOrDefault();
            _curentStudent.groupID = group.groupID;
            SurnameTxb.IsEnabled = false;
            NameTxb.IsEnabled = false;
            PatronymicTxb.IsEnabled = false;
            GroupTxb.IsEnabled = false;
            SpecialityTxb.IsEnabled = false;
            UUSEntities.GetContext().SaveChanges();
            UUSEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            JournalDG.ItemsSource = UUSEntities.GetContext().SelectAllJournal().Where(j => j.studentID == _curentStudent.studentID).ToList();
            LoadData();
            ApplyBtn.Visibility = Visibility.Hidden;
            MessageBox.Show("Информация успешно изменена!");
        }
        private void OpenGroup(object sender, RoutedEventArgs e)
        {
            try
            {
                var groups = UUSEntities.GetContext().Groups.ToList().Where(g=> g.groupID == _curentStudent.groupID).FirstOrDefault();
                Manager.MainFrame.Navigate(new DekanGroupEdit(groups));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
