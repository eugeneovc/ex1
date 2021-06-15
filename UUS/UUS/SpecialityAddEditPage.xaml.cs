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
    /// Логика взаимодействия для SpecialityAddEditPage.xaml
    /// </summary>
    public partial class SpecialityAddEditPage : Page
    {
        private Specialty _curentSpeciality = new Specialty();
        public SpecialityAddEditPage(Specialty specialty)
        {
            InitializeComponent();
            if (specialty != null)
            {
                _curentSpeciality = specialty;
            }
            DataContext = _curentSpeciality;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialityNameTxb.Text.Length > 0)
            {
                if (_curentSpeciality.specialtyID == 0)
                {
                    try
                    {
                        UUSEntities.GetContext().Specialty.Add(_curentSpeciality);
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
