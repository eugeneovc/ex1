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
    /// Логика взаимодействия для StudentScoreAddEdit.xaml
    /// </summary>
    public partial class StudentScoreAddEdit : Window
    {
        private User _teacher, _student;
        private Journal _studentScore;
        public StudentScoreAddEdit(Journal journal, User teacher, User student)
        {
            InitializeComponent();
            _teacher = teacher;
            _student = student;
            if (journal != null)
                _studentScore = journal;
            Journal journalScore = UUSEntities.GetContext().Journal.Where(j => j.studentID == _studentScore.studentID && j.courceID == _studentScore.courceID && j.semestr == _studentScore.semestr).FirstOrDefault();
            if (journalScore != null)
            {
                _studentScore = journalScore;
            }  
            DataContext = _studentScore;
            LoadData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
            if(_studentScore.journalID == 0)
            {
                try
                {
                    _studentScore.userID = _teacher.userID;
                    _studentScore.dateScore = Convert.ToDateTime(DateTime.Today.ToString("dd,MM,yyyy"));
                    UUSEntities.GetContext().Journal.Add(_studentScore);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            UUSEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно сохранены!");
            this.Close();
        }
    }
}
