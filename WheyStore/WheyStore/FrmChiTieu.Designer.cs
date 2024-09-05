namespace WheyStore
{
    partial class FrmChiTieu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChiTieu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.gYMCLUBDataSet = new WheyStore.GYMCLUBDataSet();
            this.cHITIEUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cHITIEUTableAdapter = new WheyStore.GYMCLUBDataSetTableAdapters.CHITIEUTableAdapter();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReload2 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpThoiGianCT1 = new System.Windows.Forms.DateTimePicker();
            this.txtTien1 = new System.Windows.Forms.TextBox();
            this.txtMucDich1 = new System.Windows.Forms.TextBox();
            this.txtMaCT1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvTimKiemChiTieu = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave1 = new System.Windows.Forms.Button();
            this.btnChange1 = new System.Windows.Forms.Button();
            this.btnDelete1 = new System.Windows.Forms.Button();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnReload1 = new System.Windows.Forms.Button();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpThoiGianCT = new System.Windows.Forms.DateTimePicker();
            this.txtTien = new System.Windows.Forms.TextBox();
            this.txtMucDich = new System.Windows.Forms.TextBox();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChiTieu = new System.Windows.Forms.DataGridView();
            this.maCTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mucDichDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGianChiTraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gYMCLUBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIEUBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemChiTieu)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.pbExit);
            this.panel1.Controls.Add(this.pbMinimize);
            this.panel1.Location = new System.Drawing.Point(-179, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 48);
            this.panel1.TabIndex = 6;
            // 
            // pbExit
            // 
            this.pbExit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = global::WheyStore.Properties.Resources.zyro_image__1_;
            this.pbExit.Location = new System.Drawing.Point(1229, 4);
            this.pbExit.Margin = new System.Windows.Forms.Padding(4);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(38, 38);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 0;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbMinimize
            // 
            this.pbMinimize.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pbMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimize.Image = global::WheyStore.Properties.Resources.minimize_icon_31;
            this.pbMinimize.Location = new System.Drawing.Point(1174, 4);
            this.pbMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(38, 38);
            this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimize.TabIndex = 0;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            // 
            // gYMCLUBDataSet
            // 
            this.gYMCLUBDataSet.DataSetName = "GYMCLUBDataSet";
            this.gYMCLUBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cHITIEUBindingSource
            // 
            this.cHITIEUBindingSource.DataMember = "CHITIEU";
            this.cHITIEUBindingSource.DataSource = this.gYMCLUBDataSet;
            // 
            // cHITIEUTableAdapter
            // 
            this.cHITIEUTableAdapter.ClearBeforeFill = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Old English Text MT", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(328, 616);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(404, 56);
            this.label14.TabIndex = 8;
            this.label14.Text = "No Pain No Gain";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Controls.Add(this.btnReload2);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.dgvTimKiemChiTieu);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1072, 530);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tìm Kiếm Chi Tiêu";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::WheyStore.Properties.Resources.zyro_image;
            this.pictureBox2.Location = new System.Drawing.Point(7, 355);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(292, 168);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 104;
            this.pictureBox2.TabStop = false;
            // 
            // btnReload2
            // 
            this.btnReload2.BackColor = System.Drawing.Color.Transparent;
            this.btnReload2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload2.Location = new System.Drawing.Point(5, 280);
            this.btnReload2.Name = "btnReload2";
            this.btnReload2.Size = new System.Drawing.Size(295, 68);
            this.btnReload2.TabIndex = 92;
            this.btnReload2.Text = "Tải Lại";
            this.btnReload2.UseVisualStyleBackColor = false;
            this.btnReload2.Click += new System.EventHandler(this.btnReload2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(5, 202);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(295, 72);
            this.btnSearch.TabIndex = 91;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dtpThoiGianCT1);
            this.panel4.Controls.Add(this.txtTien1);
            this.panel4.Controls.Add(this.txtMucDich1);
            this.panel4.Controls.Add(this.txtMaCT1);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(3, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 190);
            this.panel4.TabIndex = 90;
            // 
            // dtpThoiGianCT1
            // 
            this.dtpThoiGianCT1.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtpThoiGianCT1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianCT1.Location = new System.Drawing.Point(131, 148);
            this.dtpThoiGianCT1.Name = "dtpThoiGianCT1";
            this.dtpThoiGianCT1.Size = new System.Drawing.Size(159, 22);
            this.dtpThoiGianCT1.TabIndex = 80;
            // 
            // txtTien1
            // 
            this.txtTien1.Location = new System.Drawing.Point(131, 100);
            this.txtTien1.Name = "txtTien1";
            this.txtTien1.Size = new System.Drawing.Size(159, 22);
            this.txtTien1.TabIndex = 4;
            // 
            // txtMucDich1
            // 
            this.txtMucDich1.Location = new System.Drawing.Point(131, 49);
            this.txtMucDich1.Name = "txtMucDich1";
            this.txtMucDich1.Size = new System.Drawing.Size(159, 22);
            this.txtMucDich1.TabIndex = 4;
            // 
            // txtMaCT1
            // 
            this.txtMaCT1.Location = new System.Drawing.Point(131, 3);
            this.txtMaCT1.Name = "txtMaCT1";
            this.txtMaCT1.Size = new System.Drawing.Size(159, 22);
            this.txtMaCT1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Thời Gian Chi Trả";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Số Tiền Chi Trả ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Mục Đích";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Mã Chi Tiêu";
            // 
            // dgvTimKiemChiTieu
            // 
            this.dgvTimKiemChiTieu.AutoGenerateColumns = false;
            this.dgvTimKiemChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemChiTieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvTimKiemChiTieu.DataSource = this.cHITIEUBindingSource;
            this.dgvTimKiemChiTieu.Location = new System.Drawing.Point(306, 6);
            this.dgvTimKiemChiTieu.Name = "dgvTimKiemChiTieu";
            this.dgvTimKiemChiTieu.RowHeadersWidth = 51;
            this.dgvTimKiemChiTieu.RowTemplate.Height = 24;
            this.dgvTimKiemChiTieu.Size = new System.Drawing.Size(760, 518);
            this.dgvTimKiemChiTieu.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaCT";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã Chi Tiêu";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MucDich";
            this.dataGridViewTextBoxColumn2.HeaderText = "Mục Đích";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tien";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tiền";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ThoiGianChiTra";
            this.dataGridViewTextBoxColumn4.HeaderText = "Thời Gian Chi Trả";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btnSave1);
            this.tabPage2.Controls.Add(this.btnChange1);
            this.tabPage2.Controls.Add(this.btnDelete1);
            this.tabPage2.Controls.Add(this.btnAdd1);
            this.tabPage2.Controls.Add(this.btnExit1);
            this.tabPage2.Controls.Add(this.btnReload1);
            this.tabPage2.Controls.Add(this.btnCancel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dgvChiTieu);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1072, 530);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chi Tiêu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WheyStore.Properties.Resources.zyro_image;
            this.pictureBox1.Location = new System.Drawing.Point(7, 448);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave1
            // 
            this.btnSave1.BackColor = System.Drawing.Color.White;
            this.btnSave1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.ForeColor = System.Drawing.Color.Red;
            this.btnSave1.Location = new System.Drawing.Point(3, 323);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Size = new System.Drawing.Size(143, 56);
            this.btnSave1.TabIndex = 102;
            this.btnSave1.Text = "Lưu";
            this.btnSave1.UseVisualStyleBackColor = false;
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // btnChange1
            // 
            this.btnChange1.BackColor = System.Drawing.Color.White;
            this.btnChange1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange1.Location = new System.Drawing.Point(152, 199);
            this.btnChange1.Name = "btnChange1";
            this.btnChange1.Size = new System.Drawing.Size(148, 58);
            this.btnChange1.TabIndex = 99;
            this.btnChange1.Text = "Sửa";
            this.btnChange1.UseVisualStyleBackColor = false;
            this.btnChange1.Click += new System.EventHandler(this.btnChange1_Click);
            // 
            // btnDelete1
            // 
            this.btnDelete1.BackColor = System.Drawing.Color.White;
            this.btnDelete1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete1.Location = new System.Drawing.Point(3, 263);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(143, 54);
            this.btnDelete1.TabIndex = 100;
            this.btnDelete1.Text = "Xóa";
            this.btnDelete1.UseVisualStyleBackColor = false;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.BackColor = System.Drawing.Color.White;
            this.btnAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd1.Location = new System.Drawing.Point(3, 199);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(143, 58);
            this.btnAdd1.TabIndex = 96;
            this.btnAdd1.Text = "Thêm";
            this.btnAdd1.UseVisualStyleBackColor = false;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnExit1
            // 
            this.btnExit1.BackColor = System.Drawing.Color.White;
            this.btnExit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit1.Location = new System.Drawing.Point(58, 385);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(183, 56);
            this.btnExit1.TabIndex = 97;
            this.btnExit1.Text = "Thoát";
            this.btnExit1.UseVisualStyleBackColor = false;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnReload1
            // 
            this.btnReload1.BackColor = System.Drawing.Color.Transparent;
            this.btnReload1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload1.Location = new System.Drawing.Point(152, 263);
            this.btnReload1.Name = "btnReload1";
            this.btnReload1.Size = new System.Drawing.Size(148, 54);
            this.btnReload1.TabIndex = 98;
            this.btnReload1.Text = "Tải Lại";
            this.btnReload1.UseVisualStyleBackColor = false;
            this.btnReload1.Click += new System.EventHandler(this.btnReload1_Click);
            // 
            // btnCancel1
            // 
            this.btnCancel1.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel1.ForeColor = System.Drawing.Color.Red;
            this.btnCancel1.Location = new System.Drawing.Point(152, 323);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(148, 56);
            this.btnCancel1.TabIndex = 101;
            this.btnCancel1.Text = "Hủy Bỏ";
            this.btnCancel1.UseVisualStyleBackColor = false;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dtpThoiGianCT);
            this.panel2.Controls.Add(this.txtTien);
            this.panel2.Controls.Add(this.txtMucDich);
            this.panel2.Controls.Add(this.txtMaCT);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 190);
            this.panel2.TabIndex = 89;
            // 
            // dtpThoiGianCT
            // 
            this.dtpThoiGianCT.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dtpThoiGianCT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGianCT.Location = new System.Drawing.Point(121, 148);
            this.dtpThoiGianCT.Name = "dtpThoiGianCT";
            this.dtpThoiGianCT.Size = new System.Drawing.Size(169, 22);
            this.dtpThoiGianCT.TabIndex = 80;
            // 
            // txtTien
            // 
            this.txtTien.Location = new System.Drawing.Point(131, 100);
            this.txtTien.Name = "txtTien";
            this.txtTien.Size = new System.Drawing.Size(159, 22);
            this.txtTien.TabIndex = 4;
            // 
            // txtMucDich
            // 
            this.txtMucDich.Location = new System.Drawing.Point(131, 49);
            this.txtMucDich.Name = "txtMucDich";
            this.txtMucDich.Size = new System.Drawing.Size(159, 22);
            this.txtMucDich.TabIndex = 4;
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(131, 3);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Size = new System.Drawing.Size(159, 22);
            this.txtMaCT.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Thời Gian Chi Trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số Tiền Chi Trả ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mục Đích";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Chi Tiêu";
            // 
            // dgvChiTieu
            // 
            this.dgvChiTieu.AutoGenerateColumns = false;
            this.dgvChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maCTDataGridViewTextBoxColumn,
            this.mucDichDataGridViewTextBoxColumn,
            this.tienDataGridViewTextBoxColumn,
            this.thoiGianChiTraDataGridViewTextBoxColumn});
            this.dgvChiTieu.DataSource = this.cHITIEUBindingSource;
            this.dgvChiTieu.Location = new System.Drawing.Point(306, 3);
            this.dgvChiTieu.Name = "dgvChiTieu";
            this.dgvChiTieu.RowHeadersWidth = 51;
            this.dgvChiTieu.RowTemplate.Height = 24;
            this.dgvChiTieu.Size = new System.Drawing.Size(763, 520);
            this.dgvChiTieu.TabIndex = 0;
            this.dgvChiTieu.SelectionChanged += new System.EventHandler(this.dgvChiTieu_SelectionChanged);
            // 
            // maCTDataGridViewTextBoxColumn
            // 
            this.maCTDataGridViewTextBoxColumn.DataPropertyName = "MaCT";
            this.maCTDataGridViewTextBoxColumn.HeaderText = "Mã Chi Tiêu";
            this.maCTDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maCTDataGridViewTextBoxColumn.Name = "maCTDataGridViewTextBoxColumn";
            this.maCTDataGridViewTextBoxColumn.Width = 125;
            // 
            // mucDichDataGridViewTextBoxColumn
            // 
            this.mucDichDataGridViewTextBoxColumn.DataPropertyName = "MucDich";
            this.mucDichDataGridViewTextBoxColumn.HeaderText = "Mục Đích";
            this.mucDichDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mucDichDataGridViewTextBoxColumn.Name = "mucDichDataGridViewTextBoxColumn";
            this.mucDichDataGridViewTextBoxColumn.Width = 125;
            // 
            // tienDataGridViewTextBoxColumn
            // 
            this.tienDataGridViewTextBoxColumn.DataPropertyName = "Tien";
            this.tienDataGridViewTextBoxColumn.HeaderText = "Tiền";
            this.tienDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tienDataGridViewTextBoxColumn.Name = "tienDataGridViewTextBoxColumn";
            this.tienDataGridViewTextBoxColumn.Width = 125;
            // 
            // thoiGianChiTraDataGridViewTextBoxColumn
            // 
            this.thoiGianChiTraDataGridViewTextBoxColumn.DataPropertyName = "ThoiGianChiTra";
            this.thoiGianChiTraDataGridViewTextBoxColumn.HeaderText = "Thời Gian Chi Trả";
            this.thoiGianChiTraDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.thoiGianChiTraDataGridViewTextBoxColumn.Name = "thoiGianChiTraDataGridViewTextBoxColumn";
            this.thoiGianChiTraDataGridViewTextBoxColumn.Width = 125;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 559);
            this.tabControl1.TabIndex = 7;
            // 
            // FrmChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 676);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChiTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNhapHang";
            this.Load += new System.EventHandler(this.FrmNhapHang_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gYMCLUBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIEUBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemChiTieu)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbMinimize;
        private GYMCLUBDataSet gYMCLUBDataSet;
        private System.Windows.Forms.BindingSource cHITIEUBindingSource;
        private GYMCLUBDataSetTableAdapters.CHITIEUTableAdapter cHITIEUTableAdapter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReload2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpThoiGianCT1;
        private System.Windows.Forms.TextBox txtTien1;
        private System.Windows.Forms.TextBox txtMucDich1;
        private System.Windows.Forms.TextBox txtMaCT1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvTimKiemChiTieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave1;
        private System.Windows.Forms.Button btnChange1;
        private System.Windows.Forms.Button btnDelete1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.Button btnReload1;
        private System.Windows.Forms.Button btnCancel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpThoiGianCT;
        private System.Windows.Forms.TextBox txtTien;
        private System.Windows.Forms.TextBox txtMucDich;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mucDichDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGianChiTraDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl1;
    }
}