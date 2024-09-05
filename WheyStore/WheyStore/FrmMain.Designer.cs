namespace WheyStore
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTPBS = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnThanhVien = new System.Windows.Forms.Button();
            this.btnPT = new System.Windows.Forms.Button();
            this.btnNhanVienLT = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.btnChiTieu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.pbExit);
            this.panel1.Controls.Add(this.pbMinimize);
            this.panel1.Location = new System.Drawing.Point(0, -59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 109);
            this.panel1.TabIndex = 2;
            // 
            // btnTPBS
            // 
            this.btnTPBS.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnTPBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTPBS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTPBS.Location = new System.Drawing.Point(824, 70);
            this.btnTPBS.Name = "btnTPBS";
            this.btnTPBS.Size = new System.Drawing.Size(299, 78);
            this.btnTPBS.TabIndex = 5;
            this.btnTPBS.Text = "Thực Phẩm Bổ Sung";
            this.btnTPBS.UseVisualStyleBackColor = false;
            this.btnTPBS.Click += new System.EventHandler(this.btnTPBS_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKhachHang.Location = new System.Drawing.Point(881, 279);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(196, 78);
            this.btnKhachHang.TabIndex = 5;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnThanhVien
            // 
            this.btnThanhVien.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhVien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThanhVien.Location = new System.Drawing.Point(881, 170);
            this.btnThanhVien.Name = "btnThanhVien";
            this.btnThanhVien.Size = new System.Drawing.Size(196, 78);
            this.btnThanhVien.TabIndex = 5;
            this.btnThanhVien.Text = "Thành Viên";
            this.btnThanhVien.UseVisualStyleBackColor = false;
            this.btnThanhVien.Click += new System.EventHandler(this.btnThanhVien_Click);
            // 
            // btnPT
            // 
            this.btnPT.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPT.Location = new System.Drawing.Point(824, 477);
            this.btnPT.Name = "btnPT";
            this.btnPT.Size = new System.Drawing.Size(299, 78);
            this.btnPT.TabIndex = 5;
            this.btnPT.Text = "PersonalTrainer";
            this.btnPT.UseVisualStyleBackColor = false;
            this.btnPT.Click += new System.EventHandler(this.btnPT_Click);
            // 
            // btnNhanVienLT
            // 
            this.btnNhanVienLT.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnNhanVienLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVienLT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNhanVienLT.Location = new System.Drawing.Point(12, 70);
            this.btnNhanVienLT.Name = "btnNhanVienLT";
            this.btnNhanVienLT.Size = new System.Drawing.Size(308, 78);
            this.btnNhanVienLT.TabIndex = 5;
            this.btnNhanVienLT.Text = "Nhân Viên Lễ Tân";
            this.btnNhanVienLT.UseVisualStyleBackColor = false;
            this.btnNhanVienLT.Click += new System.EventHandler(this.btnNhanVienLT_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHoaDon.Location = new System.Drawing.Point(49, 279);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(205, 78);
            this.btnHoaDon.TabIndex = 5;
            this.btnHoaDon.Text = "Hóa Đơn Thanh Toán";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNhapHang.Location = new System.Drawing.Point(12, 477);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(308, 78);
            this.btnNhapHang.TabIndex = 5;
            this.btnNhapHang.Text = "Nhập Hàng";
            this.btnNhapHang.UseVisualStyleBackColor = false;
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNCC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNCC.Location = new System.Drawing.Point(49, 384);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(205, 78);
            this.btnNCC.TabIndex = 5;
            this.btnNCC.Text = "Nhà Cung Cấp";
            this.btnNCC.UseVisualStyleBackColor = false;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // btnLop
            // 
            this.btnLop.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLop.Location = new System.Drawing.Point(881, 384);
            this.btnLop.Name = "btnLop";
            this.btnLop.Size = new System.Drawing.Size(196, 78);
            this.btnLop.TabIndex = 5;
            this.btnLop.Text = "Lớp";
            this.btnLop.UseVisualStyleBackColor = false;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // btnChiTieu
            // 
            this.btnChiTieu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnChiTieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTieu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChiTieu.Location = new System.Drawing.Point(49, 170);
            this.btnChiTieu.Name = "btnChiTieu";
            this.btnChiTieu.Size = new System.Drawing.Size(205, 78);
            this.btnChiTieu.TabIndex = 5;
            this.btnChiTieu.Text = "Chi Tiêu";
            this.btnChiTieu.UseVisualStyleBackColor = false;
            this.btnChiTieu.Click += new System.EventHandler(this.btnChiTieu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 559);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Pain No Gain";
            // 
            // pbExit
            // 
            this.pbExit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Image = global::WheyStore.Properties.Resources.zyro_image__1_;
            this.pbExit.Location = new System.Drawing.Point(1094, 63);
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
            this.pbMinimize.Location = new System.Drawing.Point(1048, 63);
            this.pbMinimize.Margin = new System.Windows.Forms.Padding(4);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(38, 38);
            this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMinimize.TabIndex = 0;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::WheyStore.Properties.Resources.zyro_image;
            this.pictureBox1.Location = new System.Drawing.Point(277, 70);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(585, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1136, 618);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChiTieu);
            this.Controls.Add(this.btnNCC);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnNhanVienLT);
            this.Controls.Add(this.btnPT);
            this.Controls.Add(this.btnLop);
            this.Controls.Add(this.btnThanhVien);
            this.Controls.Add(this.btnTPBS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WheyStore";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbMinimize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTPBS;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnThanhVien;
        private System.Windows.Forms.Button btnPT;
        private System.Windows.Forms.Button btnNhanVienLT;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnLop;
        private System.Windows.Forms.Button btnChiTieu;
        private System.Windows.Forms.Label label1;
    }
}

