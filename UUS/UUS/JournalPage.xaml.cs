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
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        private User _curentUser;
        private Journal score;
        private User cStudent;
        public JournalPage(User user)
        {
            InitializeComponent();
            _curentUser = user;
            var journalGroup = UUSEntities.GetContext().SelectAllJournal().Where(j => j.userID == _curentUser.userID).ToList();
            var group = UUSEntities.GetContext().Groups.ToList();
            var cource = from c in UUSEntities.GetContext().Course
                         join j in UUSEntities.GetContext().Journal on c.courseID equals j.courceID
                         group c by c.courseName into g
                         select new
                         {
                             CourceName = g.Key
                         };
            
            GroupBox.ItemsSource = group;
            CourceBox.ItemsSource = cource.ToList();
            SemestrBox.ItemsSource = journalGroup.GroupBy(j=> j.Semestr);
        }
        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void SelectedGroup(object sender, RoutedEventArgs e)
        {
            if(GroupBox.Text.Length != 0 && CourceBox.Text.Length  != 0 && SemestrBox.Text.Length != 0)
            {
                var jour = from j in UUSEntities.GetContext().Journal
                           join st in UUSEntities.GetContext().Students on j.studentID equals st.studentID
                           join teach in UUSEntities.GetContext().Users on j.userID equals teach.userID
                           join gr in UUSEntities.GetContext().Groups on j.groupID equals gr.groupID
                           join c in UUSEntities.GetContext().Course on j.courceID equals c.courseID
                           join stUsers in UUSEntities.GetContext().Users on st.userID equals stUsers.userID
                           select new
                           {
                               JournalID = j.journalID,
                               StudentID = st.studentID,
                               TeachID = teach.userID,
                               StudentUserID = stUsers.userID,
                               GroupNmb = gr.groupNMB,
                               CourceName = c.courseName,
                               Semestr = j.semestr,
                               Date = j.dateScore,
                               Score = j.score,
                               StudentName = stUsers.surname + " " + stUsers.name + " " + stUsers.patronymic,
                               TeachName = teach.surname + " " + teach.name + " " + teach.patronymic
                           };
                Journal_Data.ItemsSource = jour.Where(j=> j.TeachID == _curentUser.userID && j.GroupNmb.ToString() == GroupBox.Text && j.CourceName == CourceBox.Text).ToList();
                if (Journal_Data.Items.Count == 0)
                    MessageBox.Show("Данные по этому запросу отсутствуют!", "Ошибка");
            }
            else
            {
                MessageBox.Show("Выберите все данные из списка!", "Ошибка!");
            }
            
        }

        private void EditScoreBtnClick(object sender, RoutedEventArgs e)
        {
            var selectedData = (sender as Button).DataContext;
            try
            {
                var journal = UUSEntities.GetContext().Journal.ToList();
                foreach (var journalScore in journal)
                {
                    if (selectedData.ToString().Contains("JournalID = " + journalScore.journalID.ToString()))
                    {
                        score = journalScore;
                    }
                }
                var students = UUSEntities.GetContext().Users.ToList();
                foreach (var student in students)
                {
                    if (selectedData.ToString().Contains("StudentUserID = " + student.userID))
                    {
                        cStudent = student;
                    }
                }
                StudentScoreAddEdit studentScoreAddEdit = new StudentScoreAddEdit(score,_curentUser,cStudent);
                studentScoreAddEdit.ShowDialog();
                UUSEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var jour = from j in UUSEntities.GetContext().Journal
                           join st in UUSEntities.GetContext().Students on j.studentID equals st.studentID
                           join teach in UUSEntities.GetContext().Users on j.userID equals teach.userID
                           join gr in UUSEntities.GetContext().Groups on j.groupID equals gr.groupID
                           join c in UUSEntities.GetContext().Course on j.courceID equals c.courseID
                           join stUsers in UUSEntities.GetContext().Users on st.userID equals stUsers.userID
                           select new
                           {
                               JournalID = j.journalID,
                               StudentID = st.studentID,
                               TeachID = teach.userID,
                               StudentUserID = stUsers.userID,
                               GroupNmb = gr.groupNMB,
                               CourceName = c.courseName,
                               Semestr = j.semestr,
                               Date = j.dateScore,
                               Score = j.score,
                               StudentName = stUsers.surname + " " + stUsers.name + " " + stUsers.patronymic,
                               TeachName = teach.surname + " " + teach.name + " " + teach.patronymic
                           };
                Journal_Data.ItemsSource = jour.Where(j => j.TeachID == _curentUser.userID && j.GroupNmb.ToString() == GroupBox.Text && j.CourceName == CourceBox.Text).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            Word.Application winword = new Word.Application();
            winword.Visible = true;
            Word.Document document = winword.Documents.Add();
            Word.Paragraph par = document.Content.Paragraphs.Add();
            par.Range.Text = "Экзаменационный лист группы "+ GroupBox.Text;
            par.Range.Words[4].Bold = 1;
            par.Range.Font.Name = "Times New Roman";
            par.Range.Font.Size = 16;
            par.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par.Range.InsertParagraphAfter();

            par.Range.Text = "По предмету: " + CourceBox.Text;
            par.Range.Font.Name = "Times New Roman";
            par.Range.Font.Size = 16;
            par.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            par.Range.InsertParagraphAfter();

            par.Range.Text = "Покупатель: " + customerTxt.Text;
            for (int i = 3; i < par.Range.Words.Count; i++)
            {
                par.Range.Words[i].Underline = Word.WdUnderline.wdUnderlineSingle;
                par.Range.Words[i].Bold = 1;
            }
            par.Range.Font.Name = "Times New Roman";
            par.Range.Font.Size = 14;
            par.Range.InsertParagraphAfter();



            Word.Table myTable = document.Tables.Add(par.Range, _ordersData.Count + 1, 5);
            myTable.Borders.Enable = 1;
            int iterat = 0;
            foreach (Word.Row row in myTable.Rows)
            {
                foreach (Word.Cell cell in row.Cells)
                {
                    cell.Range.Font.Size = 14;
                    cell.Range.Font.Name = "Times New Roman";
                    cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    if (cell.RowIndex == 1)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = "№";
                            cell.Range.Font.Bold = 1;
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = "Товар";
                            cell.Range.Font.Bold = 1;
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
                        }
                        else if (cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = "Количество";
                            cell.Range.Font.Bold = 1;
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
                        }
                        else if (cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = "Цена";
                            cell.Range.Font.Bold = 1;
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
                        }
                        else if (cell.ColumnIndex == 5)
                        {
                            cell.Range.Text = "Сумма";
                            cell.Range.Font.Bold = 1;
                            cell.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
                        }
                    }
                    else
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.Text = _ordersData[iterat].OrderNmb.ToString();
                        }
                        else if (cell.ColumnIndex == 2)
                        {
                            cell.Range.Text = _ordersData[iterat].Product.ToString();
                        }
                        else if (cell.ColumnIndex == 3)
                        {
                            cell.Range.Text = _ordersData[iterat].Value.ToString();
                        }
                        else if (cell.ColumnIndex == 4)
                        {
                            cell.Range.Text = _ordersData[iterat].Price.ToString() + " руб.";
                        }
                        else if (cell.ColumnIndex == 5)
                        {
                            cell.Range.Text = _ordersData[iterat].Sum.ToString() + " руб.";
                            iterat++;
                        }
                    }
                }
            }
            par.Range.InsertParagraphAfter();

            par.Range.Text = "Итого \t " + sum.Content;
            par.Range.Font.Size = 14;
            par.Range.Font.Name = "Times New Roman";
            par.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

        }
    }
}
