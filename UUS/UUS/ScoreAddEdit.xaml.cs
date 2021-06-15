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
    /// Логика взаимодействия для ScoreAddEdit.xaml
    /// </summary>
    public partial class ScoreAddEdit : Page
    {
        private User _teacher,_student;
        private Journal _studentScore;
        public ScoreAddEdit(Journal journal,User teacher, User student)
        {
            InitializeComponent();
            _teacher = teacher;
            _student = student;
            if (journal != null)
            {
                _studentScore = journal;
            }
            DataContext = _studentScore;
            LoadData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void LoadData()
        {
            SurnameTxb.Text = _student.surname;
            NameTxb.Text = _student.name;
            PatronymicTxb.Text = _student.patronymic;
            DateTxb.Text = DateTime.Today.ToString("dd,MM,yyyy");
        }


        private void ApplyEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_studentScore.journalID == 0)
            {

            }
            else
            {
                _studentScore.score = Convert.ToInt32(ScoreTxb.Text);
                _studentScore.dateScore = Convert.ToDateTime(DateTime.Today.ToString("dd,MM,yyyy"));
            }
            UUSEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно сохранены!");
        }
    }
}
