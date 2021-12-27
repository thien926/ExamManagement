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
        private StudentBUS studentBUS = new StudentBUS();
        public MainForm()
        {
            InitializeComponent();
            getExamList();
            getLevelList();
            getTeacherList();
            getStudentList();
            LoadComponentRegister();
        }

        #region Method LoadData Init
        private void getExamList()
        {
            dataGridViewExam.DataSource = examinationBUS.GetAll();
        }

        private void getLevelList()
        {
            dataGridViewLevel.DataSource = levelBUS.GetAll();
        }

        private void getTeacherList()
        {
            dataGridViewTeacher.DataSource = teacherBUS.GetAll();
        }

        private void getStudentList()
        {
            dataGridViewStudent.DataSource = studentBUS.GetAll();
        }

        private void LoadComponentRegister()
        {
            var comboboxExam = examinationBUS.getAllForRegister();
            var comboboxLevel = levelBUS.getAllForRegister();

            comboBoxExamRegister.Items.Clear();
            comboBoxExamRegister.Items.AddRange(comboboxExam);
            comboBoxLevelRegister.Items.Clear();
            comboBoxLevelRegister.Items.AddRange(comboboxLevel);
        }

        #endregion

        #region Event TabControl
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    getStudentList();
                    break;
                case 1:
                    LoadComponentRegister();
                    break;
                case 4:
                    getExamList();
                    break;
                case 5:
                    getLevelList();
                    break;
                case 6:
                    getTeacherList();
                    break;

                default:
                    break;
            }
            
        }
        #endregion

        #region Events Commons
        private void textBoxNotChar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        #region Events Student
        private void buttonRefreshStudent_Click(object sender, EventArgs e)
        {
            getStudentList();
        }

        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewStudent.Rows[index];

            string gender = "";

            try
            {
                textBoxIdStudent.Text = selectedRow.Cells[0].Value.ToString();
                textBoxNameStudent.Text = selectedRow.Cells[1].Value.ToString();
                gender = selectedRow.Cells[2].Value.ToString();
                if (gender.Equals("Nam"))
                {
                    radioBtnNamStudent.Checked = true;
                    radioBtnNuStudent.Checked = false;
                }
                else
                {
                    radioBtnNamStudent.Checked = false;
                    radioBtnNuStudent.Checked = true;
                }
                textBoxPhoneStudent.Text = selectedRow.Cells[3].Value.ToString();
                dateTimePickerBornDateStudent.Value = (DateTime)selectedRow.Cells[4].Value;
                textBoxCCCDStudent.Text = selectedRow.Cells[5].Value.ToString();
                dateTimePickerIssueDateStudent.Value = (DateTime)selectedRow.Cells[6].Value;
                textBoxIssuePlaceStudent.Text = selectedRow.Cells[7].Value.ToString();
                textBoxEmailStudent.Text = selectedRow.Cells[8].Value.ToString();
            }
            catch (Exception)
            {
                btnReFreshFormStudent_Click(sender, e);
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string message = "", gender = "", phone = textBoxPhoneStudent.Text, CCCD = textBoxCCCDStudent.Text, name = textBoxNameStudent.Text;
            string issuePlace = textBoxIssuePlaceStudent.Text, email = textBoxEmailStudent.Text;
            DateTime bornDate = dateTimePickerBornDateStudent.Value, issueDate = dateTimePickerIssueDateStudent.Value, now = System.DateTime.Now;
            
            if (!textBoxIdStudent.Text.Equals(""))
            {
                message += "Trường Id phải là null\n";
            }

            if (name.Equals(""))
            {
                message += "Trường tên thí sinh là bắt buộc\n";
            }

            if (phone.Equals(""))
            {
                message += "Trường số điện thoại là bắt buộc\n";
            }
            else
            {
                var temp = Regex.IsMatch(phone, @"^(09|03|07|08|05)+([0-9]{8})$");
                if(!temp)
                {
                    message += "Số điện thoại phải là kí tự số bắt đầu là (09|03|07|08|05) và có 10 kí tự\n";
                }
            }

            if(!radioBtnNamStudent.Checked && !radioBtnNuStudent.Checked)
            {
                message += "Trường giới tính là bắt buộc\n";
            }
            else
            {
                if(radioBtnNamStudent.Checked)
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
            }

            if(CCCD.Equals(""))
            {
                message += "Trường CCCD là bắt buộc\n";
            }
            else
            {
                var temp = Regex.IsMatch(CCCD, @"^([0-9]{12})$");
                if (!temp)
                {
                    message += "CCCD phải là 12 kí tự số\n";
                }
            }

            if(issuePlace.Equals(""))
            {
                message += "Trường nơi cấp là bắt buộc\n";
            }

            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var tempEmail = Regex.IsMatch(email, validEmailPattern);
            if (!tempEmail)
            {
                message += "Email không đúng định dạng\n";
            }

            if(DateTime.Compare(bornDate, now) >= 0)
            {
                message += "Ngày sinh phải trước ngày hiện tại\n";
            }

            if (DateTime.Compare(issueDate, now) >= 0)
            {
                message += "Ngày cấp phải trước ngày hiện tại\n";
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bornDate = new DateTime(bornDate.Year, bornDate.Month, bornDate.Day, 0, 0, 0);
            issueDate = new DateTime(issueDate.Year, issueDate.Month, issueDate.Day, 0, 0, 0);

            if (studentBUS.AddStudent(name, gender, bornDate, CCCD, issueDate, issuePlace, phone, email))
            {
                MessageBox.Show("Thêm thành công!", "Thêm thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReFreshFormStudent_Click(sender, e);
                getStudentList();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thêm thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            string message = "", gender = "", phone = textBoxPhoneStudent.Text, CCCD = textBoxCCCDStudent.Text, name = textBoxNameStudent.Text;
            string issuePlace = textBoxIssuePlaceStudent.Text, email = textBoxEmailStudent.Text;
            DateTime bornDate = dateTimePickerBornDateStudent.Value, issueDate = dateTimePickerIssueDateStudent.Value, now = System.DateTime.Now;
            

            if (textBoxIdStudent.Text.Equals(""))
            {
                message += "Trường Id phải là bắt buộc\n";
            }

            if (name.Equals(""))
            {
                message += "Trường tên thí sinh là bắt buộc\n";
            }

            if (phone.Equals(""))
            {
                message += "Trường số điện thoại là bắt buộc\n";
            }
            else
            {
                var temp = Regex.IsMatch(phone, @"^(09|03|07|08|05)+([0-9]{8})$");
                if (!temp)
                {
                    message += "Số điện thoại phải là kí tự số bắt đầu là (09|03|07|08|05) và có 10 kí tự\n";
                }
            }

            if (!radioBtnNamStudent.Checked && !radioBtnNuStudent.Checked)
            {
                message += "Trường giới tính là bắt buộc\n";
            }
            else
            {
                if (radioBtnNamStudent.Checked)
                {
                    gender = "Nam";
                }
                else
                {
                    gender = "Nữ";
                }
            }

            if (CCCD.Equals(""))
            {
                message += "Trường CCCD là bắt buộc\n";
            }
            else
            {
                var temp = Regex.IsMatch(CCCD, @"^([0-9]{12})$");
                if (!temp)
                {
                    message += "CCCD phải là 12 kí tự số\n";
                }
            }

            if (issuePlace.Equals(""))
            {
                message += "Trường nơi cấp là bắt buộc\n";
            }

            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var tempEmail = Regex.IsMatch(email, validEmailPattern);
            if (!tempEmail)
            {
                message += "Email không đúng định dạng\n";
            }

            if (DateTime.Compare(bornDate, now) >= 0)
            {
                message += "Ngày sinh phải trước ngày hiện tại\n";
            }

            if (DateTime.Compare(issueDate, now) >= 0)
            {
                message += "Ngày cấp phải trước ngày hiện tại\n";
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int Id = int.Parse(textBoxIdStudent.Text);
            bornDate = new DateTime(bornDate.Year, bornDate.Month, bornDate.Day, 0, 0, 0);
            issueDate = new DateTime(issueDate.Year, issueDate.Month, issueDate.Day, 0, 0, 0);

            if (studentBUS.UpdateStudent(Id, name, gender, bornDate, CCCD, issueDate, issuePlace, phone, email))
            {
                MessageBox.Show("Sửa thành công!", "Sửa thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReFreshFormStudent_Click(sender, e);
                getStudentList();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thêm thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (textBoxIdStudent.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn thí sinh cần xóa.\nXóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return;
            }

            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn có chăc muốn xóa thí sinh đã chọn?", "Xóa thí sinh", messageBoxButtons);
            if(result == DialogResult.Yes)
            {
                if(studentBUS.DeleteStudent(int.Parse(textBoxIdStudent.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Xóa thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getStudentList();
                    btnReFreshFormStudent_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Xóa thí sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReFreshFormStudent_Click(object sender, EventArgs e)
        {
            textBoxIdStudent.Text = "";
            textBoxNameStudent.Text = "";
            radioBtnNamStudent.Checked = false;
            radioBtnNuStudent.Checked = false;
            textBoxPhoneStudent.Text = "";
            dateTimePickerBornDateStudent.Value = System.DateTime.Now;
            textBoxCCCDStudent.Text = "";
            dateTimePickerIssueDateStudent.Value = System.DateTime.Now;
            textBoxIssuePlaceStudent.Text = "";
            textBoxEmailStudent.Text = "";
        }




        #endregion

        #region Events Register
        private void btnSearchCCCDRegister_Click(object sender, EventArgs e)
        {
            string CCCD = textBoxSearchCCCDRegister.Text;
            Boolean flag = true;
            if (CCCD.Equals(""))
            {
                flag = false;
            }
            else
            {
                var temp = Regex.IsMatch(CCCD, @"^([0-9]{12})$");
                if (!temp)
                {
                    flag = false;
                }
            }
            if(flag)
            {
                var student = studentBUS.getStudentWithCCCD(CCCD);
                if(student != null)
                {
                    textBoxIdRegister.Text = student.Id.ToString();
                    textBoxNameRegister.Text = student.name;
                    textBoxPhoneRegister.Text = student.phone;
                    dateTimePickerBornRegister.Value = student.bornDate;
                    textBoxCCCDRegister.Text = student.citizenCard;
                    dateTimePickerIssueRegister.Value = student.issueDate;
                    textBoxIssuePLaceRegister.Text = student.issuePlace;
                    textBoxEmailRegister.Text = student.email;
                    if (student.gender.Equals("Nam"))
                    {
                        radioBtnNamRegister.Checked = true;
                        radioBtnNuRegister.Checked = false;

                        radioBtnNamRegister.Enabled = true;
                        radioBtnNuRegister.Enabled = false;
                    }
                    else
                    {
                        radioBtnNamRegister.Checked = false;
                        radioBtnNuRegister.Checked = true;

                        radioBtnNamRegister.Enabled = false;
                        radioBtnNuRegister.Enabled = true;
                    }
                }
                else
                {
                    btnCancelRegister_Click(sender, e);
                }
            }
            else
            {
                btnCancelRegister_Click(sender, e);
            }
        }

        private void btnCancelRegister_Click(object sender, EventArgs e)
        {
            textBoxIdRegister.Text = "";
            textBoxNameRegister.Text = "";
            textBoxPhoneRegister.Text = "";
            dateTimePickerBornRegister.Value = System.DateTime.Now;
            textBoxCCCDRegister.Text = "";
            dateTimePickerIssueRegister.Value = System.DateTime.Now;
            textBoxIssuePLaceRegister.Text = "";
            textBoxEmailRegister.Text = "";
            radioBtnNamRegister.Checked = false;
            radioBtnNuRegister.Checked = false;
            radioBtnNamRegister.Enabled = true;
            radioBtnNuRegister.Enabled = true;
        }
        #endregion


    }
}
