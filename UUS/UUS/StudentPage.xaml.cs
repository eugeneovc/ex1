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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage(User user)
        {
            InitializeComponent();
            Journal_Data.ItemsSource = UUSEntities.GetContext().Journal.ToList();
            Surname_Label.Content = user.surname;
            Name_Label.Content = user.name;
            Patronymic_Label.Content = user.patronymic;
            Email_Label.Content = user.email;
            Phone_Label.Content = user.phone;
        }
    }
}
