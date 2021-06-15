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
    /// Логика взаимодействия для AddStudentToGroup.xaml
    /// </summary>
    public partial class AddStudentToGroup : Page
    {
        private Group _curentGroup;
        public AddStudentToGroup(Group group)
        {
            InitializeComponent();
            _curentGroup = group;
            var students = from u in UUSEntities.GetContext().Users.Where(s => s.role == "student")
                           select new
                           {
                               Fio = u.surname + " " + u.name + " " + u.patronymic
                           };
            FIOStudentsList.ItemsSource = students.ToList();
            GroupsList.Text = _curentGroup.groupNMB.ToString();
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.userID = 125;
            student.groupID = 122;
        }
    }
}
