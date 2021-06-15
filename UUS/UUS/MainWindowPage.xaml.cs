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
    /// Логика взаимодействия для MainWindowPage.xaml
    /// </summary>
    public partial class MainWindowPage : Page
    {
        public MainWindowPage()
        {
            InitializeComponent();
        }
        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            string login, password; // Логин и пароль
            login = LoginTxt.Text;
            password = PassBox.Password;
            var users = UUSEntities.GetContext().Users.ToList();
            bool flag = false;
            foreach (var user in users)
            {
                if (login == user.login && password == user.password)
                {
                    // Если у пользователя роль "Декан" 
                    if (user.role == "dekan")
                    {
                        Manager.MainFrame.Navigate(new DekanPage(user));
                        flag = true;
                    }
                    if (user.role == "teacher")
                    {
                        Manager.MainFrame.Navigate(new TeacherPage(user));
                        flag = true;
                    }
                    if (user.role == "student")
                    {
                        Manager.MainFrame.Navigate(new StudentPage(user));
                        flag = true;
                    }
                }
            }
            if (flag == false) MessageBox.Show("Вход не разрешен! Неправильный логин или пароль", "Ошибка авторизации");
        }
    }
}
