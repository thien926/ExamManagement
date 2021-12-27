
namespace ExamManagerWinform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStudent = new System.Windows.Forms.TabPage();
            this.panelTableStudent = new System.Windows.Forms.Panel();
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelSearchWithInfo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchInfo = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelSearchWithRoom = new System.Windows.Forms.Panel();
            this.textBoxRoom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchExamRoom = new System.Windows.Forms.Button();
            this.textBoxExam = new System.Windows.Forms.TextBox();
            this.tabPageRegister = new System.Windows.Forms.TabPage();
            this.tabPageCreateRoom = new System.Windows.Forms.TabPage();
            this.tabPageMarkExam = new System.Windows.Forms.TabPage();
            this.tabPageExam = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerExam = new System.Windows.Forms.DateTimePicker();
            this.labelExamDate = new System.Windows.Forms.Label();
            this.textBoxNameExam = new System.Windows.Forms.TextBox();
            this.labelNameExam = new System.Windows.Forms.Label();
            this.textBoxIdExam = new System.Windows.Forms.TextBox();
            this.labelIdExam = new System.Windows.Forms.Label();
            this.btnReloadFormExam = new System.Windows.Forms.Button();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.btnUpdateExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLeftExam = new System.Windows.Forms.Panel();
            this.dataGridViewExam = new System.Windows.Forms.DataGridView();
            this.btnReLoadExam = new System.Windows.Forms.Button();
            this.tabPageLevel = new System.Windows.Forms.TabPage();
            this.dataGridViewLevel = new System.Windows.Forms.DataGridView();
            this.tabPageTeacher = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTeacher = new System.Windows.Forms.DataGridView();
            this.btnReloadTeacher = new System.Windows.Forms.Button();
            this.textBoxNameTeacher = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIdTeacher = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReFreshFormTeacher = new System.Windows.Forms.Button();
            this.btnAddTeacher = new System.Windows.Forms.Button();
            this.btnUpdateTeacher = new System.Windows.Forms.Button();
            this.btnDeleteTeacher = new System.Windows.Forms.Button();
            this.textBoxPhoneTeacher = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioBtnNamTeacher = new System.Windows.Forms.RadioButton();
            this.radioBtnNuTeacher = new System.Windows.Forms.RadioButton();
            this.tabControl.SuspendLayout();
            this.tabPageStudent.SuspendLayout();
            this.panelTableStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            this.panelControl.SuspendLayout();
            this.panelSearchWithInfo.SuspendLayout();
            this.panelSearchWithRoom.SuspendLayout();
            this.tabPageExam.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelLeftExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).BeginInit();
            this.tabPageLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevel)).BeginInit();
            this.tabPageTeacher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacher)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageStudent);
            this.tabControl.Controls.Add(this.tabPageRegister);
            this.tabControl.Controls.Add(this.tabPageCreateRoom);
            this.tabControl.Controls.Add(this.tabPageMarkExam);
            this.tabControl.Controls.Add(this.tabPageExam);
            this.tabControl.Controls.Add(this.tabPageLevel);
            this.tabControl.Controls.Add(this.tabPageTeacher);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(963, 534);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageStudent
            // 
            this.tabPageStudent.Controls.Add(this.panelTableStudent);
            this.tabPageStudent.Controls.Add(this.panelControl);
            this.tabPageStudent.Location = new System.Drawing.Point(4, 22);
            this.tabPageStudent.Name = "tabPageStudent";
            this.tabPageStudent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStudent.Size = new System.Drawing.Size(955, 508);
            this.tabPageStudent.TabIndex = 0;
            this.tabPageStudent.Text = "Thí sinh";
            this.tabPageStudent.UseVisualStyleBackColor = true;
            // 
            // panelTableStudent
            // 
            this.panelTableStudent.Controls.Add(this.dataGridViewStudent);
            this.panelTableStudent.Location = new System.Drawing.Point(3, 72);
            this.panelTableStudent.Name = "panelTableStudent";
            this.panelTableStudent.Size = new System.Drawing.Size(943, 433);
            this.panelTableStudent.TabIndex = 1;
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.Size = new System.Drawing.Size(946, 436);
            this.dataGridViewStudent.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl.Controls.Add(this.panelSearchWithInfo);
            this.panelControl.Controls.Add(this.panelSearchWithRoom);
            this.panelControl.Location = new System.Drawing.Point(3, 3);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(946, 66);
            this.panelControl.TabIndex = 0;
            // 
            // panelSearchWithInfo
            // 
            this.panelSearchWithInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchWithInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearchWithInfo.Controls.Add(this.label4);
            this.panelSearchWithInfo.Controls.Add(this.label3);
            this.panelSearchWithInfo.Controls.Add(this.btnSearchInfo);
            this.panelSearchWithInfo.Controls.Add(this.textBox2);
            this.panelSearchWithInfo.Controls.Add(this.textBox1);
            this.panelSearchWithInfo.Location = new System.Drawing.Point(465, 3);
            this.panelSearchWithInfo.Name = "panelSearchWithInfo";
            this.panelSearchWithInfo.Size = new System.Drawing.Size(478, 60);
            this.panelSearchWithInfo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số điện thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên:";
            // 
            // btnSearchInfo
            // 
            this.btnSearchInfo.Location = new System.Drawing.Point(398, 18);
            this.btnSearchInfo.Name = "btnSearchInfo";
            this.btnSearchInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSearchInfo.TabIndex = 3;
            this.btnSearchInfo.Text = "Tìm kiếm";
            this.btnSearchInfo.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(254, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 1;
            // 
            // panelSearchWithRoom
            // 
            this.panelSearchWithRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearchWithRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearchWithRoom.Controls.Add(this.textBoxRoom);
            this.panelSearchWithRoom.Controls.Add(this.label2);
            this.panelSearchWithRoom.Controls.Add(this.label1);
            this.panelSearchWithRoom.Controls.Add(this.btnSearchExamRoom);
            this.panelSearchWithRoom.Controls.Add(this.textBoxExam);
            this.panelSearchWithRoom.Location = new System.Drawing.Point(5, 3);
            this.panelSearchWithRoom.Name = "panelSearchWithRoom";
            this.panelSearchWithRoom.Size = new System.Drawing.Size(465, 60);
            this.panelSearchWithRoom.TabIndex = 0;
            // 
            // textBoxRoom
            // 
            this.textBoxRoom.Location = new System.Drawing.Point(237, 19);
            this.textBoxRoom.Name = "textBoxRoom";
            this.textBoxRoom.Size = new System.Drawing.Size(113, 20);
            this.textBoxRoom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phòng thi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khóa thi:";
            // 
            // btnSearchExamRoom
            // 
            this.btnSearchExamRoom.Location = new System.Drawing.Point(369, 18);
            this.btnSearchExamRoom.Name = "btnSearchExamRoom";
            this.btnSearchExamRoom.Size = new System.Drawing.Size(75, 23);
            this.btnSearchExamRoom.TabIndex = 2;
            this.btnSearchExamRoom.Text = "Tìm kiếm";
            this.btnSearchExamRoom.UseVisualStyleBackColor = true;
            // 
            // textBoxExam
            // 
            this.textBoxExam.Location = new System.Drawing.Point(54, 20);
            this.textBoxExam.Name = "textBoxExam";
            this.textBoxExam.Size = new System.Drawing.Size(113, 20);
            this.textBoxExam.TabIndex = 0;
            // 
            // tabPageRegister
            // 
            this.tabPageRegister.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegister.Name = "tabPageRegister";
            this.tabPageRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegister.Size = new System.Drawing.Size(955, 508);
            this.tabPageRegister.TabIndex = 1;
            this.tabPageRegister.Text = "Đăng ký";
            this.tabPageRegister.UseVisualStyleBackColor = true;
            // 
            // tabPageCreateRoom
            // 
            this.tabPageCreateRoom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreateRoom.Name = "tabPageCreateRoom";
            this.tabPageCreateRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreateRoom.Size = new System.Drawing.Size(955, 508);
            this.tabPageCreateRoom.TabIndex = 2;
            this.tabPageCreateRoom.Text = "Tạo phòng thi";
            this.tabPageCreateRoom.UseVisualStyleBackColor = true;
            // 
            // tabPageMarkExam
            // 
            this.tabPageMarkExam.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarkExam.Name = "tabPageMarkExam";
            this.tabPageMarkExam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarkExam.Size = new System.Drawing.Size(955, 508);
            this.tabPageMarkExam.TabIndex = 3;
            this.tabPageMarkExam.Text = "Nhập điểm";
            this.tabPageMarkExam.UseVisualStyleBackColor = true;
            // 
            // tabPageExam
            // 
            this.tabPageExam.Controls.Add(this.panel2);
            this.tabPageExam.Controls.Add(this.panel1);
            this.tabPageExam.Location = new System.Drawing.Point(4, 22);
            this.tabPageExam.Name = "tabPageExam";
            this.tabPageExam.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExam.Size = new System.Drawing.Size(955, 508);
            this.tabPageExam.TabIndex = 4;
            this.tabPageExam.Text = "Khóa thi";
            this.tabPageExam.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerExam);
            this.panel2.Controls.Add(this.labelExamDate);
            this.panel2.Controls.Add(this.textBoxNameExam);
            this.panel2.Controls.Add(this.labelNameExam);
            this.panel2.Controls.Add(this.textBoxIdExam);
            this.panel2.Controls.Add(this.labelIdExam);
            this.panel2.Controls.Add(this.btnReloadFormExam);
            this.panel2.Controls.Add(this.btnAddExam);
            this.panel2.Controls.Add(this.btnUpdateExam);
            this.panel2.Controls.Add(this.btnDeleteExam);
            this.panel2.Location = new System.Drawing.Point(538, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 508);
            this.panel2.TabIndex = 2;
            // 
            // dateTimePickerExam
            // 
            this.dateTimePickerExam.CustomFormat = "MMMMdd, yyyy  |  HH:mm";
            this.dateTimePickerExam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerExam.Location = new System.Drawing.Point(158, 151);
            this.dateTimePickerExam.Name = "dateTimePickerExam";
            this.dateTimePickerExam.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerExam.TabIndex = 10;
            // 
            // labelExamDate
            // 
            this.labelExamDate.AutoSize = true;
            this.labelExamDate.Location = new System.Drawing.Point(76, 157);
            this.labelExamDate.Name = "labelExamDate";
            this.labelExamDate.Size = new System.Drawing.Size(46, 13);
            this.labelExamDate.TabIndex = 9;
            this.labelExamDate.Text = "Ngày thi";
            // 
            // textBoxNameExam
            // 
            this.textBoxNameExam.Location = new System.Drawing.Point(158, 95);
            this.textBoxNameExam.Name = "textBoxNameExam";
            this.textBoxNameExam.Size = new System.Drawing.Size(200, 20);
            this.textBoxNameExam.TabIndex = 8;
            // 
            // labelNameExam
            // 
            this.labelNameExam.AutoSize = true;
            this.labelNameExam.Location = new System.Drawing.Point(76, 98);
            this.labelNameExam.Name = "labelNameExam";
            this.labelNameExam.Size = new System.Drawing.Size(67, 13);
            this.labelNameExam.TabIndex = 7;
            this.labelNameExam.Text = "Tên khóa thi";
            // 
            // textBoxIdExam
            // 
            this.textBoxIdExam.Enabled = false;
            this.textBoxIdExam.Location = new System.Drawing.Point(158, 39);
            this.textBoxIdExam.Name = "textBoxIdExam";
            this.textBoxIdExam.Size = new System.Drawing.Size(200, 20);
            this.textBoxIdExam.TabIndex = 6;
            // 
            // labelIdExam
            // 
            this.labelIdExam.AutoSize = true;
            this.labelIdExam.Location = new System.Drawing.Point(76, 42);
            this.labelIdExam.Name = "labelIdExam";
            this.labelIdExam.Size = new System.Drawing.Size(16, 13);
            this.labelIdExam.TabIndex = 5;
            this.labelIdExam.Text = "Id";
            // 
            // btnReloadFormExam
            // 
            this.btnReloadFormExam.Location = new System.Drawing.Point(169, 260);
            this.btnReloadFormExam.Name = "btnReloadFormExam";
            this.btnReloadFormExam.Size = new System.Drawing.Size(111, 38);
            this.btnReloadFormExam.TabIndex = 4;
            this.btnReloadFormExam.Text = "LÀM MỚI FORM";
            this.btnReloadFormExam.UseVisualStyleBackColor = true;
            this.btnReloadFormExam.Click += new System.EventHandler(this.btnReloadFormExam_Click);
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(101, 215);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(75, 38);
            this.btnAddExam.TabIndex = 0;
            this.btnAddExam.Text = "THÊM";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // btnUpdateExam
            // 
            this.btnUpdateExam.Location = new System.Drawing.Point(182, 215);
            this.btnUpdateExam.Name = "btnUpdateExam";
            this.btnUpdateExam.Size = new System.Drawing.Size(75, 38);
            this.btnUpdateExam.TabIndex = 2;
            this.btnUpdateExam.Text = "SỬA";
            this.btnUpdateExam.UseVisualStyleBackColor = true;
            this.btnUpdateExam.Click += new System.EventHandler(this.btnUpdateExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.Location = new System.Drawing.Point(263, 215);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(75, 38);
            this.btnDeleteExam.TabIndex = 1;
            this.btnDeleteExam.Text = "XÓA";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelLeftExam);
            this.panel1.Controls.Add(this.btnReLoadExam);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 508);
            this.panel1.TabIndex = 1;
            // 
            // panelLeftExam
            // 
            this.panelLeftExam.Controls.Add(this.dataGridViewExam);
            this.panelLeftExam.Location = new System.Drawing.Point(5, 6);
            this.panelLeftExam.Name = "panelLeftExam";
            this.panelLeftExam.Size = new System.Drawing.Size(523, 452);
            this.panelLeftExam.TabIndex = 0;
            // 
            // dataGridViewExam
            // 
            this.dataGridViewExam.AllowUserToAddRows = false;
            this.dataGridViewExam.AllowUserToDeleteRows = false;
            this.dataGridViewExam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExam.Location = new System.Drawing.Point(0, 3);
            this.dataGridViewExam.Name = "dataGridViewExam";
            this.dataGridViewExam.Size = new System.Drawing.Size(520, 446);
            this.dataGridViewExam.TabIndex = 0;
            this.dataGridViewExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExam_CellClick);
            // 
            // btnReLoadExam
            // 
            this.btnReLoadExam.Location = new System.Drawing.Point(183, 464);
            this.btnReLoadExam.Name = "btnReLoadExam";
            this.btnReLoadExam.Size = new System.Drawing.Size(138, 38);
            this.btnReLoadExam.TabIndex = 3;
            this.btnReLoadExam.Text = "LÀM MỚI DANH SÁCH";
            this.btnReLoadExam.UseVisualStyleBackColor = true;
            this.btnReLoadExam.Click += new System.EventHandler(this.btnReLoadExam_Click);
            // 
            // tabPageLevel
            // 
            this.tabPageLevel.Controls.Add(this.dataGridViewLevel);
            this.tabPageLevel.Location = new System.Drawing.Point(4, 22);
            this.tabPageLevel.Name = "tabPageLevel";
            this.tabPageLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLevel.Size = new System.Drawing.Size(955, 508);
            this.tabPageLevel.TabIndex = 5;
            this.tabPageLevel.Text = "Trình độ";
            this.tabPageLevel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLevel
            // 
            this.dataGridViewLevel.AllowUserToAddRows = false;
            this.dataGridViewLevel.AllowUserToDeleteRows = false;
            this.dataGridViewLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLevel.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLevel.Name = "dataGridViewLevel";
            this.dataGridViewLevel.Size = new System.Drawing.Size(949, 505);
            this.dataGridViewLevel.TabIndex = 0;
            // 
            // tabPageTeacher
            // 
            this.tabPageTeacher.Controls.Add(this.radioBtnNuTeacher);
            this.tabPageTeacher.Controls.Add(this.radioBtnNamTeacher);
            this.tabPageTeacher.Controls.Add(this.label8);
            this.tabPageTeacher.Controls.Add(this.textBoxPhoneTeacher);
            this.tabPageTeacher.Controls.Add(this.label7);
            this.tabPageTeacher.Controls.Add(this.textBoxNameTeacher);
            this.tabPageTeacher.Controls.Add(this.label5);
            this.tabPageTeacher.Controls.Add(this.textBoxIdTeacher);
            this.tabPageTeacher.Controls.Add(this.label6);
            this.tabPageTeacher.Controls.Add(this.btnReFreshFormTeacher);
            this.tabPageTeacher.Controls.Add(this.btnAddTeacher);
            this.tabPageTeacher.Controls.Add(this.btnUpdateTeacher);
            this.tabPageTeacher.Controls.Add(this.btnDeleteTeacher);
            this.tabPageTeacher.Controls.Add(this.btnReloadTeacher);
            this.tabPageTeacher.Controls.Add(this.dataGridViewTeacher);
            this.tabPageTeacher.Location = new System.Drawing.Point(4, 22);
            this.tabPageTeacher.Name = "tabPageTeacher";
            this.tabPageTeacher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTeacher.Size = new System.Drawing.Size(955, 508);
            this.tabPageTeacher.TabIndex = 6;
            this.tabPageTeacher.Text = "Giáo viên";
            this.tabPageTeacher.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTeacher
            // 
            this.dataGridViewTeacher.AllowUserToAddRows = false;
            this.dataGridViewTeacher.AllowUserToDeleteRows = false;
            this.dataGridViewTeacher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeacher.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTeacher.Name = "dataGridViewTeacher";
            this.dataGridViewTeacher.Size = new System.Drawing.Size(502, 442);
            this.dataGridViewTeacher.TabIndex = 0;
            this.dataGridViewTeacher.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTeacher_CellClick);
            // 
            // btnReloadTeacher
            // 
            this.btnReloadTeacher.Location = new System.Drawing.Point(169, 459);
            this.btnReloadTeacher.Name = "btnReloadTeacher";
            this.btnReloadTeacher.Size = new System.Drawing.Size(138, 38);
            this.btnReloadTeacher.TabIndex = 4;
            this.btnReloadTeacher.Text = "LÀM MỚI DANH SÁCH";
            this.btnReloadTeacher.UseVisualStyleBackColor = true;
            this.btnReloadTeacher.Click += new System.EventHandler(this.btnReloadTeacher_Click);
            // 
            // textBoxNameTeacher
            // 
            this.textBoxNameTeacher.Location = new System.Drawing.Point(659, 102);
            this.textBoxNameTeacher.Name = "textBoxNameTeacher";
            this.textBoxNameTeacher.Size = new System.Drawing.Size(200, 20);
            this.textBoxNameTeacher.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tên giáo viên";
            // 
            // textBoxIdTeacher
            // 
            this.textBoxIdTeacher.Enabled = false;
            this.textBoxIdTeacher.Location = new System.Drawing.Point(659, 46);
            this.textBoxIdTeacher.Name = "textBoxIdTeacher";
            this.textBoxIdTeacher.Size = new System.Drawing.Size(200, 20);
            this.textBoxIdTeacher.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Id";
            // 
            // btnReFreshFormTeacher
            // 
            this.btnReFreshFormTeacher.Location = new System.Drawing.Point(670, 319);
            this.btnReFreshFormTeacher.Name = "btnReFreshFormTeacher";
            this.btnReFreshFormTeacher.Size = new System.Drawing.Size(111, 38);
            this.btnReFreshFormTeacher.TabIndex = 12;
            this.btnReFreshFormTeacher.Text = "LÀM MỚI FORM";
            this.btnReFreshFormTeacher.UseVisualStyleBackColor = true;
            this.btnReFreshFormTeacher.Click += new System.EventHandler(this.btnReFreshFormTeacher_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Location = new System.Drawing.Point(602, 274);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(75, 38);
            this.btnAddTeacher.TabIndex = 9;
            this.btnAddTeacher.Text = "THÊM";
            this.btnAddTeacher.UseVisualStyleBackColor = true;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // btnUpdateTeacher
            // 
            this.btnUpdateTeacher.Location = new System.Drawing.Point(683, 274);
            this.btnUpdateTeacher.Name = "btnUpdateTeacher";
            this.btnUpdateTeacher.Size = new System.Drawing.Size(75, 38);
            this.btnUpdateTeacher.TabIndex = 11;
            this.btnUpdateTeacher.Text = "SỬA";
            this.btnUpdateTeacher.UseVisualStyleBackColor = true;
            this.btnUpdateTeacher.Click += new System.EventHandler(this.btnUpdateTeacher_Click);
            // 
            // btnDeleteTeacher
            // 
            this.btnDeleteTeacher.Location = new System.Drawing.Point(764, 274);
            this.btnDeleteTeacher.Name = "btnDeleteTeacher";
            this.btnDeleteTeacher.Size = new System.Drawing.Size(75, 38);
            this.btnDeleteTeacher.TabIndex = 10;
            this.btnDeleteTeacher.Text = "XÓA";
            this.btnDeleteTeacher.UseVisualStyleBackColor = true;
            this.btnDeleteTeacher.Click += new System.EventHandler(this.btnDeleteTeacher_Click);
            // 
            // textBoxPhoneTeacher
            // 
            this.textBoxPhoneTeacher.Location = new System.Drawing.Point(659, 156);
            this.textBoxPhoneTeacher.Name = "textBoxPhoneTeacher";
            this.textBoxPhoneTeacher.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhoneTeacher.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Giới tính";
            // 
            // radioBtnNamTeacher
            // 
            this.radioBtnNamTeacher.AutoSize = true;
            this.radioBtnNamTeacher.Location = new System.Drawing.Point(659, 212);
            this.radioBtnNamTeacher.Name = "radioBtnNamTeacher";
            this.radioBtnNamTeacher.Size = new System.Drawing.Size(47, 17);
            this.radioBtnNamTeacher.TabIndex = 20;
            this.radioBtnNamTeacher.TabStop = true;
            this.radioBtnNamTeacher.Text = "Nam";
            this.radioBtnNamTeacher.UseVisualStyleBackColor = true;
            this.radioBtnNamTeacher.Click += new System.EventHandler(this.radioBtnNamTeacher_Click);
            // 
            // radioBtnNuTeacher
            // 
            this.radioBtnNuTeacher.AutoSize = true;
            this.radioBtnNuTeacher.Location = new System.Drawing.Point(774, 212);
            this.radioBtnNuTeacher.Name = "radioBtnNuTeacher";
            this.radioBtnNuTeacher.Size = new System.Drawing.Size(39, 17);
            this.radioBtnNuTeacher.TabIndex = 21;
            this.radioBtnNuTeacher.TabStop = true;
            this.radioBtnNuTeacher.Text = "Nữ";
            this.radioBtnNuTeacher.UseVisualStyleBackColor = true;
            this.radioBtnNuTeacher.Click += new System.EventHandler(this.radioBtnNuTeacher_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(956, 531);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl.ResumeLayout(false);
            this.tabPageStudent.ResumeLayout(false);
            this.panelTableStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelSearchWithInfo.ResumeLayout(false);
            this.panelSearchWithInfo.PerformLayout();
            this.panelSearchWithRoom.ResumeLayout(false);
            this.panelSearchWithRoom.PerformLayout();
            this.tabPageExam.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelLeftExam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).EndInit();
            this.tabPageLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLevel)).EndInit();
            this.tabPageTeacher.ResumeLayout(false);
            this.tabPageTeacher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeacher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStudent;
        private System.Windows.Forms.TabPage tabPageRegister;
        private System.Windows.Forms.TabPage tabPageCreateRoom;
        private System.Windows.Forms.TabPage tabPageMarkExam;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPageExam;
        private System.Windows.Forms.TabPage tabPageLevel;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelSearchWithInfo;
        private System.Windows.Forms.Panel panelSearchWithRoom;
        private System.Windows.Forms.TextBox textBoxExam;
        private System.Windows.Forms.Button btnSearchExamRoom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearchInfo;
        private System.Windows.Forms.Panel panelTableStudent;
        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRoom;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReloadFormExam;
        private System.Windows.Forms.Button btnReLoadExam;
        private System.Windows.Forms.Button btnUpdateExam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxIdExam;
        private System.Windows.Forms.Label labelIdExam;
        private System.Windows.Forms.Panel panelLeftExam;
        private System.Windows.Forms.DataGridView dataGridViewExam;
        private System.Windows.Forms.TextBox textBoxNameExam;
        private System.Windows.Forms.Label labelNameExam;
        private System.Windows.Forms.DateTimePicker dateTimePickerExam;
        private System.Windows.Forms.Label labelExamDate;
        private System.Windows.Forms.DataGridView dataGridViewLevel;
        private System.Windows.Forms.TabPage tabPageTeacher;
        private System.Windows.Forms.DataGridView dataGridViewTeacher;
        private System.Windows.Forms.TextBox textBoxNameTeacher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIdTeacher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReFreshFormTeacher;
        private System.Windows.Forms.Button btnAddTeacher;
        private System.Windows.Forms.Button btnUpdateTeacher;
        private System.Windows.Forms.Button btnDeleteTeacher;
        private System.Windows.Forms.Button btnReloadTeacher;
        private System.Windows.Forms.TextBox textBoxPhoneTeacher;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioBtnNuTeacher;
        private System.Windows.Forms.RadioButton radioBtnNamTeacher;
        private System.Windows.Forms.Label label8;
    }
}