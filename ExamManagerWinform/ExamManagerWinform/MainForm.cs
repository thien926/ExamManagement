using ExamManagerWinform.BUSs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagerWinform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            getExamList();
            loadTimeExam();
        }

        #region Method
        private void getExamList()
        {
            var examBus = new ExaminationBUS();
            dataGridViewExam.DataSource = examBus.GetAll();
        }

        private void loadTimeExam()
        {
            object[] hours = new object[24];
            for(int i = 0; i < hours.Length; ++i)
            {
                hours[i] = i + " giờ";
            }

            comboBoxExamHour.Items.AddRange(hours);

            object[] minutes = new object[60];
            for (int i = 0; i < minutes.Length; ++i)
            {
                minutes[i] = i + " phút";
            }

            comboBoxExamMinute.Items.AddRange(minutes);
        }

        #endregion

        #region Events Examinations
        private void btnReLoadExam_Click(object sender, EventArgs e)
        {
            getExamList();
        }

        private void dataGridViewExam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewExam.Rows[index];

            
            try
            {
                Console.WriteLine(selectedRow.Cells[2].Value);
                textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameExam.Text = selectedRow.Cells[1].Value.ToString();
                dateTimePickerExam.Value = (DateTime)selectedRow.Cells[2].Value;

                String[] splitDate = selectedRow.Cells[2].Value.ToString().Split(' ');
                String[] time = splitDate[1].Split(':');
                comboBoxExamHour.Text = int.Parse(time[0]) + " giờ";
                comboBoxExamMinute.Text = int.Parse(time[1]) + " phút";
            }
            catch(Exception)
            {
                textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameExam.Text = selectedRow.Cells[1].Value.ToString();

                var date = System.DateTime.Now;
                dateTimePickerExam.Value = date;
                String[] splitDate = date.ToString().Split(' ');
                String[] time = splitDate[1].Split(':');
                comboBoxExamHour.Text = int.Parse(time[0]) + " giờ";
                comboBoxExamMinute.Text = int.Parse(time[1]) + " phút";
            }
            
           // textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
        }

        private void btnReloadFormExam_Click(object sender, EventArgs e)
        {
            textBoxIdExam.Text = "";
            textBoxNameExam.Text = "";
            var date = System.DateTime.Now;
            dateTimePickerExam.Value = date;
            String[] splitDate = date.ToString().Split(' ');
            String[] time = splitDate[1].Split(':');
            comboBoxExamHour.Text = int.Parse(time[0]) + " giờ";
            comboBoxExamMinute.Text = int.Parse(time[1]) + " phút";
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {

        }



        #endregion
    }
}
