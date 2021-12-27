using ExamManagerWinform.BUSs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagerWinform
{
    public partial class MainForm : Form
    {
        private ExaminationBUS examinationBUS = new ExaminationBUS();
        private LevelBUS levelBUS = new LevelBUS();
        private TeacherBUS teacherBUS = new TeacherBUS();
        public MainForm()
        {
            InitializeComponent();
            getExamList();
            getLevelList();
            getTeacherList();
        }

        #region Method LoadData Init
        private void getExamList()
        {
            var examBus = new ExaminationBUS();
            dataGridViewExam.DataSource = examBus.GetAll();
        }

        private void getLevelList()
        {
            var levelBUS = new LevelBUS();
            dataGridViewLevel.DataSource = levelBUS.GetAll();
        }

        private void getTeacherList()
        {
            var teacherBUS = new TeacherBUS();
            dataGridViewTeacher.DataSource = teacherBUS.GetAll();
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
                // Console.WriteLine(selectedRow.Cells[2].Value);
                textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameExam.Text = selectedRow.Cells[1].Value.ToString();
                dateTimePickerExam.Value = (DateTime)selectedRow.Cells[2].Value;
            }
            catch(Exception)
            {
                textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameExam.Text = selectedRow.Cells[1].Value.ToString();
                dateTimePickerExam.Value = System.DateTime.Now;
            }
            
           // textBoxIdExam.Text = selectedRow.Cells[0].Value.ToString();
        }

        private void btnReloadFormExam_Click(object sender, EventArgs e)
        {
            textBoxIdExam.Text = "";
            textBoxNameExam.Text = "";
            dateTimePickerExam.Value = System.DateTime.Now ;
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            string message = "";
            if (textBoxIdExam.Text.Equals(""))
            {
                message += "Trường Id phải khác null\n";
            }

            if (textBoxNameExam.Text.Equals(""))
            {
                message += "Trường tên khóa thi phải là khác null\n";
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (examinationBUS.UpdateExamination(int.Parse(textBoxIdExam.Text), textBoxNameExam.Text, dateTimePickerExam.Value))
            {
                MessageBox.Show("Sửa thành công!", "Sửa khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getExamList();
                btnReloadFormExam_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Sửa khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            string message = "";
            if(!textBoxIdExam.Text.Equals(""))
            {
                message += "Trường Id phải là null\n";
            }

            if (textBoxNameExam.Text.Equals(""))
            {
                message += "Trường tên khóa thi phải là khác null\n";
            }

            if(!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(examinationBUS.AddExamination(textBoxNameExam.Text, dateTimePickerExam.Value))
            {
                MessageBox.Show("Thêm thành công!", "Thêm khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getExamList();
                btnReloadFormExam_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thêm khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (textBoxIdExam.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn khóa thi cần xóa.\nXóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            }

            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chăc muốn xóa khóa thi đã chọn?", "Xóa khóa thi", messageBoxButtons);
            if(result == DialogResult.Yes)
            {
                if(examinationBUS.DeleteExamination(int.Parse(textBoxIdExam.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Xóa khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getExamList();
                    btnReloadFormExam_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Xóa khóa thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Events Teachers
        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            string message = "", gender = "", phone = textBoxPhoneTeacher.Text;
            if (!textBoxIdTeacher.Text.Equals(""))
            {
                message += "Trường Id phải là null\n";
            }

            if (textBoxNameTeacher.Text.Equals(""))
            {
                message += "Trường tên giáo viên phải là khác null\n";
            }

            if (phone.Equals(""))
            {
                message += "Trường số điện thoại phải là khác null\n";
            }
            else
            {
                var temp = Regex.IsMatch(phone, @"^(09|03|07|08|05)+([0-9]{8})$");
                if(!temp)
                {
                    message += "Số điện thoại phải là kí tự số bắt đầu là (09|03|07|08|05) và có 10 kí tự\n";
                }
            }

            if(!radioBtnNamTeacher.Checked && !radioBtnNuTeacher.Checked)
            {
                message += "Trường giới tính là bắt buộc\n";
            }
            else
            {
                if(radioBtnNamTeacher.Checked)
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (teacherBUS.AddTeacher(textBoxNameTeacher.Text, gender, phone))
            {
                MessageBox.Show("Thêm thành công!", "Thêm giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReFreshFormTeacher_Click(sender, e);
                getTeacherList();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thêm giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            string message = "", gender = "", phone = textBoxPhoneTeacher.Text;
            if (textBoxIdTeacher.Text.Equals(""))
            {
                message += "Trường Id phải khác null\n";
            }

            if (textBoxNameTeacher.Text.Equals(""))
            {
                message += "Trường tên giáo viên phải là khác null\n";
            }

            if (phone.Equals(""))
            {
                message += "Trường số điện thoại phải là khác null\n";
            }
            else
            {
                var temp = Regex.IsMatch(phone, @"^(09|03|07|08|05)+([0-9]{8})$");
                if (!temp)
                {
                    message += "Số điện thoại phải là kí tự số bắt đầu là (09|03|07|08|05) và có 10 kí tự\n";
                }
            }

            if (!radioBtnNamTeacher.Checked && !radioBtnNuTeacher.Checked)
            {
                message += "Trường giới tính là bắt buộc\n";
            }
            else
            {
                if (radioBtnNamTeacher.Checked)
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (teacherBUS.UpdateTeacher(int.Parse(textBoxIdTeacher.Text) ,textBoxNameTeacher.Text, gender, phone))
            {
                MessageBox.Show("Sửa thành công!", "Sửa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReFreshFormTeacher_Click(sender, e);
                getTeacherList();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Sửa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (textBoxIdTeacher.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn giáo viên cần xóa.\nXóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chăc muốn xóa giáo viên đã chọn?", "Xóa giáo viên", messageBoxButtons);
            if(result == DialogResult.Yes)
            {
                if(teacherBUS.DeleteTeacher(int.Parse(textBoxIdTeacher.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Xóa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReFreshFormTeacher_Click(sender, e);
                    getTeacherList();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Xóa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioBtnNamTeacher_Click(object sender, EventArgs e)
        {
            radioBtnNamTeacher.Checked = true;
            radioBtnNuTeacher.Checked = false;
        }

        private void radioBtnNuTeacher_Click(object sender, EventArgs e)
        {
            radioBtnNamTeacher.Checked = false;
            radioBtnNuTeacher.Checked = true;
        }

        private void dataGridViewTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewTeacher.Rows[index];

            string gender = "";

            try
            {
                textBoxIdTeacher.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameTeacher.Text = selectedRow.Cells[1].Value.ToString();
                gender = selectedRow.Cells[2].Value.ToString();
                if(gender.Equals("Nam"))
                {
                    radioBtnNamTeacher.Checked = true;
                    radioBtnNuTeacher.Checked = false;
                }
                else
                {
                    radioBtnNamTeacher.Checked = false;
                    radioBtnNuTeacher.Checked = true;
                }
                textBoxPhoneTeacher.Text = selectedRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                textBoxIdTeacher.Text = "";
                textBoxNameTeacher.Text = "";
                radioBtnNamTeacher.Checked = false;
                radioBtnNuTeacher.Checked = false;
                textBoxPhoneTeacher.Text = "";
            }
        }

        private void btnReFreshFormTeacher_Click(object sender, EventArgs e)
        {
            textBoxIdTeacher.Text = "";
            textBoxNameTeacher.Text = "";
            radioBtnNamTeacher.Checked = false;
            radioBtnNuTeacher.Checked = false;
            textBoxPhoneTeacher.Text = "";
        }

        private void btnReloadTeacher_Click(object sender, EventArgs e)
        {
            getTeacherList();
        }

        #endregion


    }
}
