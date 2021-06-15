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

namespace UUS
{
    /// <summary>
    /// Логика взаимодействия для UUSWindow.xaml
    /// </summary>
    public partial class UUSWindow : Window
    {
        private int UserID;
        private void UserInfo()
        {
            var users = GetUsersEF();
            foreach (var user in users)
            {
                ID_Label.Content = UserID.ToString();
                if (UserID == user.userID)
                {
                    Surname_Label.Content = user.surname.ToString();
                    Name_Label.Content = user.name.ToString();
                    Patronymic_Label.Content = user.patronymic.ToString();
                    Email_Label.Content = user.email.ToString();
                    Phone_Label.Content = user.phone.ToString();
                    if(user.role.ToString() != string.Empty)
                    {
                        Role_Label.Visibility = Visibility.Visible;
                        Role_Content.Visibility = Visibility.Visible;
                        Role_Content.Content = user.role.ToString();
                    }
                }
            }
        }
        private void StudentData()
        {
            var students = GetStudentsEF();
            Student_Data.ItemsSource = students;
        }
        private void CourcesData()
        {
            var cource = GetStudentsEF();
            Cources_Data.ItemsSource = cource;
        }
        private void GroupsData()
        {
            var groups = GetGroupsEF();
            Groups_Data.ItemsSource = groups;
        }
        private void SpecialityData()
        {
            var speciality = GetSpecialityEF();
            Speciality_Data.ItemsSource = speciality;
        }
        private void JournalData()
        {
            var journal = GetJournalEF();
            Journal_Data.ItemsSource = journal;
        }
        public UUSWindow(int ID)
        {
            InitializeComponent();
            UserID = ID;
            UserInfo();
            StudentData();
            CourcesData();
            GroupsData();
            SpecialityData();
            JournalData();
        }
        private static List<Users> GetUsersEF()
        {
            var context = new UUSContext();
            var users = context.Users.ToList();
            return users;
        }
        private static List<SelectAllStudents_Result> GetStudentsEF()
        {
            var context = new UUSContext();
            var students = context.SelectAllStudents().ToList();
            return students;
        }
        private static List<SelectAllCource_Result> GetCourcesEF()
        {
            var context = new UUSContext();
            var cources = context.SelectAllCource().ToList();
            return cources;
        }
        private static List<SelectAllGroups_Result> GetGroupsEF()
        {
            var context = new UUSContext();
            var groups = context.SelectAllGroups().ToList();
            return groups;
        }
        private static List<SelectAllFromSpeciality_Result> GetSpecialityEF()
        {
            var context = new UUSContext();
            var speciality = context.SelectAllFromSpeciality().ToList();
            return speciality;
        }
        private static List<SelectAllJournal_Result> GetJournalEF()
        {
            var context = new UUSContext();
            var journal = context.SelectAllJournal().ToList();
            return journal;
        }
    }
}
