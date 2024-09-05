using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheyStore
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Muốn Thoát Chương Trình ?", "Thông Báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            FrmNCC f = new FrmNCC();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnPT_Click(object sender, EventArgs e)
        {
            FrmPT f = new FrmPT();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang f = new FrmKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnTPBS_Click(object sender, EventArgs e)
        {
            FrmTPBS f = new FrmTPBS();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            FrmLop f = new FrmLop();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNhanVienLT_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnChiTieu_Click(object sender, EventArgs e)
        {
            FrmChiTieu f = new FrmChiTieu();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            FrmThanhVien f = new FrmThanhVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            FrmNhapHang f = new FrmNhapHang();
            this.Hide(); 
            f.ShowDialog();
            this.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon f = new FrmHoaDon();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
