using ExamManagerWinform.BUSs;
using ExamManagerWinform.DTOs;
using ExamManagerWinform.Views;
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
        private StudentBUS studentBUS = new StudentBUS();
        private RegistionFormBUS registionFormBUS = new RegistionFormBUS();
        private RoomBUS roomBUS = new RoomBUS();
        private ResultBUS resultBUS = new ResultBUS();

        private int IdExaminationCreateRoom = -1, IdLevelCreateRoom = -1;
        public MainForm()
        {
            InitializeComponent();
            LoadStudent();
            
        }

        #region Method LoadData Init
        private void LoadStudent()
        {
            getStudentList();
            var comboboxExam = examinationBUS.getAllForRegister();
            comboBoxListExamStudent.Items.Clear();
            comboBoxListExamStudent.Items.AddRange(comboboxExam);
        }
        private void getExamList()
        {
            dataGridViewExam.DataSource = examinationBUS.GetAll();
        }

        private void getLevelList()
        {
            dataGridViewLevel.DataSource = levelBUS.GetAll();
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

        private void LoadComponentCreateRoom()
        {
            var comboboxExam = examinationBUS.getAllForRegister();
            var comboboxLevel = levelBUS.getAllForRegister();

            comboBoxExamCreateRoom.Items.Clear();
            comboBoxExamCreateRoom.Items.AddRange(comboboxExam);
            comboBoxLevelCreateRoom.Items.Clear();
            comboBoxLevelCreateRoom.Items.AddRange(comboboxLevel);
        }

        private void LoadComponentRegisterList()
        {
            var comboboxExam = examinationBUS.getAllForRegister();
            var comboboxLevel = levelBUS.getAllForRegister();

            comboBoxSearchExamRegisterList.Items.Clear();
            comboBoxSearchExamRegisterList.Items.AddRange(comboboxExam);
            comboBoxSearchLevelRegisterList.Items.Clear();
            comboBoxSearchLevelRegisterList.Items.AddRange(comboboxLevel);
        }

        private void LoadComponentSortRoom()
        {
            var comboboxExam = examinationBUS.getAllForRegister();
            var comboboxLevel = levelBUS.getAllForRegister();

            comboBoxExamIdSortRoom.Items.Clear();
            comboBoxExamIdSortRoom.Items.AddRange(comboboxExam);
            comboBoxLevelSortRoom.Items.Clear();
            comboBoxLevelSortRoom.Items.AddRange(comboboxLevel);
        }

        #endregion

        #region Event TabControl
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadStudent();
                    break;
                case 1:
                    LoadComponentRegister();
                    break;
                case 2:
                    LoadComponentCreateRoom();
                    break;
                case 3:
                    break;
                case 4:
                    getExamList();
                    break;
                case 5:
                    getLevelList();
                    break;
                case 6:
                    LoadComponentRegisterList();
                    break;
                case 7:
                    LoadComponentSortRoom();
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

        private void textBoxNotNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) == false)
            {
                e.Handled = true;
            }
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

        private void comboBoxListExamStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] examinationIdArray = comboBoxListExamStudent.Text.Split('-');
            int examinationId = int.Parse(examinationIdArray[0]);

            var comboboxRoom = roomBUS.getAllForStudent(examinationId);
            comboBoxListRoomStudent.Items.Clear();
            comboBoxListRoomStudent.Items.AddRange(comboboxRoom);
        }

        private void btnSearchExamRoom_Click(object sender, EventArgs e)
        {
            string message = "";
            if (comboBoxListRoomStudent.Text.Equals(""))
            {
                message += "Chưa chọn phòng thi\n";
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int examinationId = -1;
            string[] examinationIdArray = comboBoxListExamStudent.Text.Split('-');
            examinationId = int.Parse(examinationIdArray[0]);

            dataGridViewStudent.DataSource = resultBUS.GetWithNameRoomAndExaminationId(comboBoxListRoomStudent.Text, examinationId);
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
            comboBoxExamRegister.Text = "";
            comboBoxLevelRegister.Text = "";
        }

        private void btnSubmitRegister_Click(object sender, EventArgs e)
        {
            string message = "", examinationIdString = comboBoxExamRegister.Text;
            string levelIdString = comboBoxLevelRegister.Text, studentIdString = textBoxIdRegister.Text;

            if(studentIdString.Equals(""))
            {
                message += "Chưa chọn thí sinh cần đăng ký\n";
            }

            if (examinationIdString.Equals(""))
            {
                message += "Chưa chọn khóa thi cần đăng ký\n";
            }

            if (levelIdString.Equals(""))
            {
                message += "Chưa chọn trình độ cần đăng ký\n";
            }

            if(!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = int.Parse(studentIdString);

            string[] examinationIdArray = examinationIdString.Split('-');
            int examinationId = int.Parse(examinationIdArray[0]);

            string[] levelIdArray = levelIdString.Split('-');
            int levelId = int.Parse(levelIdArray[0]);

            if(registionFormBUS.AddRegistionForm(examinationId, levelId, studentId, true))
            {
                MessageBox.Show("Đăng ký thành công!", "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getExamList();
                btnReloadFormExam_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events RegisterList
        private void btnSearchRegisterList_Click(object sender, EventArgs e)
        {
            string CCCD = textBoxSearchCCCDRegisterList.Text;
            if (!CCCD.Equals(""))
            {
                var temp = Regex.IsMatch(CCCD, @"^([0-9]{12})$");
                if (!temp)
                {
                    dataGridViewRegisterList.DataSource = null;
                    return;
                }
            }

            string examinationId = comboBoxSearchExamRegisterList.Text;
            if(examinationId.Equals(""))
            {
                dataGridViewRegisterList.DataSource = null;
                return;
            }
            string[] exams = examinationId.Split('-');
            examinationId = exams[0];

            string levelId = comboBoxSearchLevelRegisterList.Text;
            if (levelId.Equals(""))
            {
                dataGridViewRegisterList.DataSource = null;
                return;
            }
            string[] level = levelId.Split('-');
            levelId = level[0];

            dataGridViewRegisterList.DataSource = registionFormBUS.GetWithExamLevel(int.Parse(examinationId), int.Parse(levelId), CCCD);
        }

        private void dataGridViewRegisterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            DataGridViewRow selectedRow = dataGridViewRegisterList.Rows[index];


            try
            {
                textBoxIdRegisterList.Text = selectedRow.Cells[0].Value.ToString();
                textBoxStudentIdRegisterList.Text = selectedRow.Cells[1].Value.ToString();
                textBoxExamIdRegisterList.Text = selectedRow.Cells[4].Value.ToString();
                textBoxLevelIdRegisterList.Text = selectedRow.Cells[5].Value.ToString();
                if (int.Parse(selectedRow.Cells[6].Value.ToString()) == 1)
                {
                    comboBoxStatusRegisterList.Text = "Đã đóng lệ phí";
                }
                else
                {
                    comboBoxStatusRegisterList.Text = "Chưa đóng lệ phí";
                }
            }
            catch (Exception)
            {
                textBoxIdRegisterList.Text = "";
                textBoxStudentIdRegisterList.Text = "";
                textBoxExamIdRegisterList.Text = "";
                textBoxLevelIdRegisterList.Text = "";
                comboBoxStatusRegisterList.Text = "";
            }
        }

        private void btnUpdateRegisterList_Click(object sender, EventArgs e)
        {
            string message = "";
            string statusStr = comboBoxStatusRegisterList.Text;

            if(statusStr.Equals("")) {
                message += "Trạng thái không được rỗng\n";
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Id = int.Parse(textBoxIdRegisterList.Text);
            Boolean status = false;
            switch (statusStr)
            {
                case "Chưa đóng lệ phí":
                    status = false;
                    break;
                case "Đã đóng lệ phí":
                    status = true;
                    break;
                default:
                    break;
            }
            
            if (registionFormBUS.UpdateStatusRegistionForm(Id, status))
            {
                MessageBox.Show("Sửa thành công!", "Sửa phiếu đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReFreshFormStudent_Click(sender, e);
                getStudentList();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thêm phiếu đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Event CreateRoom
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            flowLayoutPanelListRoom.Controls.Clear();

            string message = "";
            int examinationId = -1, levelId = -1;
            string nameLevel = "";
            if (comboBoxExamCreateRoom.Text.Equals(""))
            {
                message += "Chưa chọn khóa thi\n";
            }
            else
            {
                string[] examinationIdArray = comboBoxExamCreateRoom.Text.Split('-');
                examinationId = int.Parse(examinationIdArray[0]);
            }

            if (comboBoxLevelCreateRoom.Text.Equals(""))
            {
                message += "Chưa chọn trình độ thi\n";
            }
            else
            {
                string[] levelIdArray = comboBoxLevelCreateRoom.Text.Split('-');
                levelId = int.Parse(levelIdArray[0]);
                nameLevel = levelIdArray[1];
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool temp = roomBUS.isCreateRoom(examinationId, levelId);
            Console.WriteLine(temp);

            if(temp)
            {
                MessageBox.Show("Đã tạo danh sách phòng cho khóa thi và trình độ đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdExaminationCreateRoom = examinationId;
            IdLevelCreateRoom = levelId;

            int total = registionFormBUS.getCountByExamAndLevelStatusTrue(IdExaminationCreateRoom, IdLevelCreateRoom);
            
            if(total == 0) {
                MessageBox.Show("Không có thí sinh nào đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            lblTotalRegisFormCreateRoom.Text = "Tổng số thí sinh: "+ total +" thí sinh";
            int numberRoom = (int)Math.Ceiling((float)(total * 1.0/ 35));
            /*Console.WriteLine(total + " " + numberRoom);*/

            for (int index = 1; index <= numberRoom; ++index)
            {
                ViewRoom room = new ViewRoom();
                room.examinationId = IdExaminationCreateRoom;
                room.levelId = IdLevelCreateRoom;

                if (index == numberRoom)
                {
                    room.amount = total - (numberRoom - 1) * 35;
                }
                else
                {
                    room.amount = 35;
                }

                if (index < 10)
                {
                    room.initial(nameLevel + "P0" + index);
                }
                else
                {
                    room.initial(nameLevel + "P" + index);
                }

                room.Click += new System.EventHandler(this.btnRoomCreated_Click);

                flowLayoutPanelListRoom.Controls.Add(room);
            }
            lblNumberRoomCreateRoom.Text = "Đã tạo " + flowLayoutPanelListRoom.Controls.Count + " phòng";
        }

        private void btnUpdateRoomCreateRoom_Click(object sender, EventArgs e)
        {
            string txtAmount = textBoxIdRoomCreateRoom.Text, nameRoom = textBoxIdRoomCreateRoom.Text;

            if(nameRoom.Equals(""))
            {
                MessageBox.Show("Mã phòng là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if(txtAmount.Trim().Equals(""))
            {
                MessageBox.Show("Số lượng thí sinh phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int amount = int.Parse(textBoxAmountCreateRoom.Text);

            if (amount <= 0)
            {
                MessageBox.Show("Số lượng thí sinh phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (amount >= 70)
            {
                MessageBox.Show("Số lượng thí sinh phải nhỏ hơn 70!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Boolean temp = false;
            foreach (ViewRoom s in flowLayoutPanelListRoom.Controls)
            {
                if(s.name.Equals(nameRoom))
                {
                    s.amount = amount;
                    s.apterUpdateNameOrAmount();
                    temp = true;
                    break;
                }
            }

            if(!temp)
            {
                MessageBox.Show("Sửa thất bại!", "Sửa phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Sửa thành công!", "Sửa phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveRoomCreateRoom_Click(object sender, EventArgs e)
        {
            string nameRoom = textBoxIdRoomCreateRoom.Text;

            if (nameRoom.Equals(""))
            {
                MessageBox.Show("Mã phòng là bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Boolean temp = false;
            foreach (ViewRoom s in flowLayoutPanelListRoom.Controls)
            {
                if (s.name.Equals(nameRoom))
                {
                    flowLayoutPanelListRoom.Controls.Remove(s);
                    temp = true;
                    break;
                }
            }

            if (!temp)
            {
                MessageBox.Show("Xóa thất bại!", "Xóa phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblNumberRoomCreateRoom.Text = "Đã tạo " + flowLayoutPanelListRoom.Controls.Count + " phòng";
                MessageBox.Show("Xóa thành công!", "Xóa phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveCreateRoom_Click(object sender, EventArgs e)
        {
            if(IdExaminationCreateRoom < 0 || IdLevelCreateRoom < 0)
            {
                MessageBox.Show("Chưa tạo danh sách phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Boolean temp = roomBUS.isCreateRoom(IdExaminationCreateRoom, IdLevelCreateRoom);

            if (temp)
            {
                MessageBox.Show("Danh sách phòng cho khóa thi có Id = "+ IdExaminationCreateRoom + " và trình độ có Id = "+ IdLevelCreateRoom + " đã có trong Database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalRegis = registionFormBUS.getCountByExamAndLevelStatusTrue(IdExaminationCreateRoom, IdLevelCreateRoom);
            int total = 0;
            foreach (ViewRoom s in flowLayoutPanelListRoom.Controls)
            {
                total += s.amount;
            }

            if(total < totalRegis)
            {
                MessageBox.Show("Danh sách phòng đã tạo có số lượng thí sinh thấp hơn danh sách đã đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            temp = true;
            foreach (ViewRoom s in flowLayoutPanelListRoom.Controls)
            {
                temp = roomBUS.AddRoom(s.name, s.examinationId, s.levelId, s.amount);
                if(!temp)
                {
                    break;
                }
            }

            if(temp)
            {
                MessageBox.Show("Lưu thành công!", "Lưu danh sách phòng với khóa thi có Id = " + IdExaminationCreateRoom + " và trình độ có Id = " + IdLevelCreateRoom, MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdExaminationCreateRoom = -1;
                IdLevelCreateRoom = -1;
                lblTotalRegisFormCreateRoom.Text = "Tổng số thí sinh: 0 thí sinh";
                lblNumberRoomCreateRoom.Text = "Đã tạo 0 phòng";
                flowLayoutPanelListRoom.Controls.Clear();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!", "Lưu danh sách phòng với khóa thi có Id = " + IdExaminationCreateRoom + " và trình độ có Id = " + IdLevelCreateRoom, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeeListRoomInDatabase_Click(object sender, EventArgs e)
        {
            flowLayoutPanelListRoom.Controls.Clear();

            string message = "";
            int examinationId = -1, levelId = -1;
            if (comboBoxExamCreateRoom.Text.Equals(""))
            {
                message += "Chưa chọn khóa thi\n";
            }
            else
            {
                string[] examinationIdArray = comboBoxExamCreateRoom.Text.Split('-');
                examinationId = int.Parse(examinationIdArray[0]);
            }

            if (comboBoxLevelCreateRoom.Text.Equals(""))
            {
                message += "Chưa chọn trình độ thi\n";
            }
            else
            {
                string[] levelIdArray = comboBoxLevelCreateRoom.Text.Split('-');
                levelId = int.Parse(levelIdArray[0]);
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<RoomDTO> list = roomBUS.getByExamAndLevel(examinationId, levelId);
            if(list.Count() > 0)
            {
                int numberTotal = 0;
                foreach(RoomDTO item in list)
                {
                    ViewRoom room = new ViewRoom();
                    room.examinationId = item.examinationId;
                    room.levelId = item.levelId;
                    room.amount = item.amount;

                    room.initial(item.name);
                    flowLayoutPanelListRoom.Controls.Add(room);
                    numberTotal += item.amount;
                }
                lblNumberRoomCreateRoom.Text = "Đã tạo " + flowLayoutPanelListRoom.Controls.Count + " phòng";
                lblTotalRegisFormCreateRoom.Text = "Tổng số thí sinh: "+ numberTotal +" thí sinh";
            }
            else
            {
                lblNumberRoomCreateRoom.Text = "Đã tạo 0 phòng";
                lblTotalRegisFormCreateRoom.Text = "Tổng số thí sinh: 0 thí sinh";
            }
        }

        private void btnRoomCreated_Click(object sender, EventArgs e)
        {
            ViewRoom edit = sender as ViewRoom;
            textBoxIdRoomCreateRoom.Text = edit.name;
            textBoxAmountCreateRoom.Text = edit.amount.ToString();
        }

        #endregion

        #region Event SortRoom
        private void btnSortRoom_Click(object sender, EventArgs e)
        {
            string message = "";
            int examinationId = -1, levelId = -1;
            string nameLevel = "";
            if (comboBoxExamIdSortRoom.Text.Equals(""))
            {
                message += "Chưa chọn khóa thi\n";
            }
            else
            {
                string[] examinationIdArray = comboBoxExamIdSortRoom.Text.Split('-');
                examinationId = int.Parse(examinationIdArray[0]);
            }

            if (comboBoxLevelSortRoom.Text.Equals(""))
            {
                message += "Chưa chọn trình độ thi\n";
            }
            else
            {
                string[] levelIdArray = comboBoxLevelSortRoom.Text.Split('-');
                levelId = int.Parse(levelIdArray[0]);
                nameLevel = levelIdArray[1];
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool temp = resultBUS.CheckSortInResult(examinationId, levelId);
            if(temp)
            {
                MessageBox.Show("Đã sắp xếp thí sinh vào phòng thi cho khóa thi có Id = " + examinationId + ", trình độ có Id = " + levelId, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var listRegis = registionFormBUS.getByExamAndLevelStatusTrue(examinationId, levelId);
            var listRoom = roomBUS.getByExamAndLevel(examinationId, levelId);
            int index = 1;
            temp = true;
            string SBD = "";
            foreach (RoomDTO room in listRoom)
            {
                int amount = room.amount;
                for(int i = index; i <= listRegis.Count(); ++i)
                {
                    if(i < 10)
                    {
                        SBD = nameLevel + "00" + i;
                    }
                    else if(i < 100)
                    {
                        SBD = nameLevel + "0" + i;
                    }
                    else
                    {
                        SBD = nameLevel + i;
                    }
                    temp = resultBUS.AddResult(room.name, SBD, 0, 0, 0, 0, room.Id, listRegis.ElementAt(i-1).studentId, listRegis.ElementAt(i - 1).Id);
                    if(!temp)
                    {
                        break;
                    }
                    ++index;
                    --amount;

                    if(amount <= 0)
                    {
                        break;
                    }
                }
                if(!temp)
                {
                    break;
                }
            }

            if(temp)
            {
                MessageBox.Show("Xếp thành công!", "Xếp thí sinh vào phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xếp thất bại!", "Xếp thí sinh vào phòng thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeeListRoomSortRoom_Click(object sender, EventArgs e)
        {
            flowLayoutPanelListRoomSortRoom.Controls.Clear();

            string message = "";
            int examinationId = -1, levelId = -1;
            if (comboBoxExamIdSortRoom.Text.Equals(""))
            {
                message += "Chưa chọn khóa thi\n";
            }
            else
            {
                string[] examinationIdArray = comboBoxExamIdSortRoom.Text.Split('-');
                examinationId = int.Parse(examinationIdArray[0]);
            }

            if (comboBoxLevelSortRoom.Text.Equals(""))
            {
                message += "Chưa chọn trình độ thi\n";
            }
            else
            {
                string[] levelIdArray = comboBoxLevelSortRoom.Text.Split('-');
                levelId = int.Parse(levelIdArray[0]);
            }

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<RoomDTO> list = roomBUS.getByExamAndLevel(examinationId, levelId);
            if (list.Count() > 0)
            {
                foreach (RoomDTO item in list)
                {
                    ViewRoom room = new ViewRoom();
                    room.Id = item.Id;
                    room.examinationId = item.examinationId;
                    room.levelId = item.levelId;
                    room.amount = item.amount;

                    room.initial(item.name);
                    room.Click += new System.EventHandler(this.btnGetListStudentWithRoom_Click);
                    flowLayoutPanelListRoomSortRoom.Controls.Add(room);
                }
            }
        }

        private void btnGetListStudentWithRoom_Click(object sender, EventArgs e)
        {
            ViewRoom edit = sender as ViewRoom;
            dataGridViewListStudentSortRoom.DataSource = resultBUS.GetWithRoomId(edit.Id);
        }

        #endregion
    }
}
