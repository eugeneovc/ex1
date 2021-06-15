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
    /// Логика взаимодействия для CourceAddEdit.xaml
    /// </summary>
    public partial class CourceAddEdit : Page
    {
        Course _curentCource = new Course();
        User _curentUser;
        public CourceAddEdit(User user, Course course)
        {
            InitializeComponent();
            if (course != null)
            {
                _curentCource = course;
                if (course.reportForm == "Экзамен")
                    FormReportBox.SelectedIndex = 1;
                if (course.reportForm == "Зачет")
                    FormReportBox.SelectedIndex = 2;
            }
            _curentUser = user;
            DataContext = _curentCource;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CourceNameTxb.Text.Length > 0 && NmbOfHourTxb.Text.Length > 0)
            {
                if (_curentCource.courseID == 0)
                {
                    try
                    {
                        if (FormReportBox.SelectedIndex == 1)
                            _curentCource.reportForm = "Экзамен";
                        if (FormReportBox.SelectedIndex == 2)
                            _curentCource.reportForm = "Зачет";
                        _curentCource.userID = _curentUser.userID;
                        UUSEntities.GetContext().Course.Add(_curentCource);
                        UUSEntities.GetContext().SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
                {
                    try
                    {
                        if (FormReportBox.SelectedIndex == 1)
                            _curentCource.reportForm = "Экзамен";
                        if (FormReportBox.SelectedIndex == 2)
                            _curentCource.reportForm = "Зачет";
                        UUSEntities.GetContext().SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show("Запись успешно сохранена!");
                Manager.MainFrame.GoBack();
            }
            else
                MessageBox.Show("Заполните обязательное поле!");
        }
    }
}
