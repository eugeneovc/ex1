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
    /// Логика взаимодействия для JournalAddScorePage.xaml
    /// </summary>
    public partial class JournalAddScorePage : Page
    {
        private User _curentUser;
        private User cStudent;
        public JournalAddScorePage(User user)
        {
            InitializeComponent();
            _curentUser = user;
            var journalGroup = UUSEntities.GetContext().SelectAllJournal().Where(j => j.userID == _curentUser.userID).ToList();
            var group = UUSEntities.GetContext().Groups.ToList();
            var cource = UUSEntities.GetContext().Course.ToList();

            GroupBox.ItemsSource = group;
            CourceBox.ItemsSource = cource;
        }
        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void SelectedGroup(object sender, RoutedEventArgs e)
        {
            if (GroupBox.Text.Length != 0 && CourceBox.Text.Length != 0 && SemestrTxb.Text.Length != 0)
            {
                var jour = from st in UUSEntities.GetContext().Students
                           join us in UUSEntities.GetContext().Users on st.userID equals us.userID 
                           select new
                           {
                               StudentID = st.studentID,
                               TeachID = _curentUser.userID,
                               GroupNmb = GroupBox.Text,
                               StudentUserID = us.userID,
                               CourceName = CourceBox.Text,
                               Semestr = SemestrTxb.Text,
                               StudentName = us.surname + " " + us.name + " " + us.patronymic
                           };
                Journal_Data.ItemsSource = jour.Where(j => j.GroupNmb.ToString() == GroupBox.Text).ToList();
                if (Journal_Data.Items.Count == 0)
                    MessageBox.Show("Данные по этому запросу отсутствуют!", "Ошибка");
            }
            else
            {
                MessageBox.Show("Выберите все данные из списка!", "Ошибка!");
            }
        }
        private void AddScoreBtnClick(object sender, RoutedEventArgs e)
        {
            Journal score = new Journal();
            var selectedData = (sender as Button).DataContext;
            Course _course = null;
            Student _student = null;
            try
            {
                var courses = UUSEntities.GetContext().Course.ToList();
                foreach (var course in courses)
                {
                    if (selectedData.ToString().Contains("CourceName = " + course.courseName.ToString()))
                    {
                        _course = course;
                    }
                }
                var allStudents = UUSEntities.GetContext().Students.ToList();
                foreach (var student in allStudents)
                {
                    if (selectedData.ToString().Contains("StudentID = " + student.studentID.ToString()))
                    {
                        _student = student;
                    }
                }
                var students = UUSEntities.GetContext().Users.ToList();
                foreach (var student in students)
                {
                    if (selectedData.ToString().Contains("StudentUserID = " + student.userID))
                    {
                        cStudent = student;
                    }
                }
                Group group = UUSEntities.GetContext().Groups.Where(g => g.groupNMB.ToString() == GroupBox.Text).FirstOrDefault();
                score.courceID = _course.courseID;
                score.studentID = _student.studentID;
                score.semestr = Convert.ToInt32(SemestrTxb.Text);
                score.groupID = group.groupID;
                score.userID = _curentUser.userID;
                score.dateScore = Convert.ToDateTime(DateTime.Today.ToString("dd,MM,yyyy"));
                StudentScoreAddEdit studentScoreAddEdit = new StudentScoreAddEdit(score, _curentUser, cStudent);
                studentScoreAddEdit.ShowDialog();
                UUSEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var jour = from j in UUSEntities.GetContext().Users
                           join st in UUSEntities.GetContext().Students on j.userID equals st.userID
                           select new
                           {
                               StudentID = st.studentID,
                               TeachID = _curentUser.userID,
                               StudentUserID = st.userID,
                               GroupNmb = GroupBox.Text,
                               CourceName = CourceBox.Text,
                               Semestr = SemestrTxb.Text,
                               StudentName = j.surname + " " + j.name + " " + j.patronymic
                           };
                Journal_Data.ItemsSource = jour.Where(j => j.GroupNmb.ToString() == GroupBox.Text).ToList();
                var scoreStudents = UUSEntities.GetContext().Journal.ToList();
                if (Journal_Data.Items.Count == 0)
                    MessageBox.Show("Данные по этому запросу отсутствуют!", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}