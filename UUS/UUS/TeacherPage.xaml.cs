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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage(User user)
        {
            InitializeComponent();
            Manager.JournalFrame = JournalFrame;
            Manager.JournalFrame.Navigate(new JournalMenu(user));
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
                               StudentID = s.studentID,
                               UserID = u.userID
                           };
            //Student_Data.ItemsSource = students.ToList();
            Surname_Label.Content = user.surname;
            Name_Label.Content = user.name;
            Patronymic_Label.Content = user.patronymic;
            Email_Label.Content = user.email;
            Phone_Label.Content = user.phone;
        }
    }
}
