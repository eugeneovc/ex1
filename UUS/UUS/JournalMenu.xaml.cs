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
    /// Логика взаимодействия для JournalMenu.xaml
    /// </summary>
    public partial class JournalMenu : Page
    {
        private User _curentUser;
        public JournalMenu(User user)
        {
            InitializeComponent();
            _curentUser = user;
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new JournalPage(_curentUser));
        }

        private void AddBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new JournalAddScorePage(_curentUser));
        }
    }
}
