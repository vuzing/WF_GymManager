using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheyStore
{
    public partial class FrmKhachHang : Form
    {
        DataTable dtKhachHang = null;
        DataTable dtTimKiemKhachHang = null;
        bool Them;
        DBKhachHang dbKH;
        public FrmKhachHang()
        {
            InitializeComponent();
            dbKH = new DBKhachHang();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.gYMCLUBDataSet.KHACHHANG);
            LoadData();

        }
        void LoadData()
        {
            dtKhachHang = new DataTable();
            dtKhachHang.Clear();
            dtKhachHang = dbKH.LayKhachHang().Tables[0];

            dgvKhachHang.DataSource = dtKhachHang;
            dgvKhachHang.AutoResizeColumns();

            dgvTimKiemKhachHang.DataSource = dtKhachHang;
            dgvTimKiemKhachHang.AutoResizeColumns();
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();            
            this.txtDiaChi.ResetText();
           
           
            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            // Cho thao tác trên các nút ReLoad, thêm, sửa, xóa, thoát
            btnReload1.Enabled = true;
            btnAdd1.Enabled = true;
            btnChange1.Enabled = true;
            btnExit1.Enabled = true;
            btnDelete1.Enabled = true;
            //
            panel2.Enabled = false;
            dgvKhachHang_CellContentClick(null,null);
            dgvKhachHang_CellClick(null, null);
        }


        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaKH.Text =
            dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text =
            dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text =
            dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text =
            dgvKhachHang.Rows[r].Cells[4].Value.ToString();           
            this.txtDiaChi.Text =
            dgvKhachHang.Rows[r].Cells[5].Value.ToString();
        }

        private void btnAdd1_Click_1(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();

            // Không cho thao tác trên các nút thêm, sửa, xóa, thoát
            btnAdd1.Enabled = false;
            btnChange1.Enabled = false;
            btnDelete1.Enabled = false;
            btnExit1.Enabled = false;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave1.Enabled = true;
            btnCancel1.Enabled = true;
            btnReload1.Enabled = true;
            panel2.Enabled = true;
            this.txtMaKH.Focus();
        }

        private void btnChange1_Click_1(object sender, EventArgs e)
        {
            Them = false;
            //
            txtMaKH.Enabled = true;
            // Không cho thao tác trên các nút thêm, sửa, xóa, thoát
            btnAdd1.Enabled = false;
            btnChange1.Enabled = false;
            btnDelete1.Enabled = false;
            btnExit1.Enabled = false;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave1.Enabled = true;
            btnCancel1.Enabled = true;
            btnReload1.Enabled = true;
            panel2.Enabled = true;
            // 
            this.txtTenKH.Focus();
            dgvKhachHang_CellContentClick(null, null);
        }

        private void btnDelete1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int r = dgvKhachHang.CurrentCell.RowIndex;
                string strKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa khách hàng này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbKH.XoaKhachHang(ref err, strKH);
                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không xóa được. Lỗi :" + ex.Message);
            }
        }

        private void btnReload1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave1_Click_1(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbKH.ThemKhachHang(ref err, txtMaKH.Text, txtTenKH.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtDiaChi.Text);
                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Đã thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không thêm được. Lỗi :" + ex.Message);
                }
            }
            else
            {
                string err = "";
                try
                {
                    f = dbKH.SuaKhachHang(ref err, txtMaKH.Text, txtTenKH.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtDiaChi.Text);
                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không cập nhật được.  Lỗi :" + ex.Message);
                }
            }
        }

        private void btnCancel1_Click_1(object sender, EventArgs e)
        {
            this.txtMaKH.ResetText();
            this.txtTenKH.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();

            btnAdd1.Enabled = true;
            btnChange1.Enabled = true;
            btnDelete1.Enabled = true;
            btnExit1.Enabled = true;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnExit1_Click_1(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int r = dgvKhachHang.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaKH.Text =
            dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text =
            dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text =
            dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text =
            dgvKhachHang.Rows[r].Cells[4].Value.ToString();
            this.txtDiaChi.Text =
            dgvKhachHang.Rows[r].Cells[5].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaKH = null;
            if (txtMaKH1.Text != "")
                MaKH = txtMaKH1.Text;
            string TenKH = null;
            if (txtTenKH1.Text != "")
                TenKH = txtTenKH1.Text;
            string GioiTinh = null;
            if(txtGioiTinh1.Text != "")
                GioiTinh = txtGioiTinh1.Text;
            int? SoDT = null;
            if (txtSDT1.Text != "")
            {
                try { SoDT = Convert.ToInt32(txtSDT1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số DT phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string Email = null;
            if (txtEmail1.Text != "")
                Email = txtEmail1.Text;
            string DiaChi = null;
            if (txtDiaChi1.Text != "")
                DiaChi = txtDiaChi1.Text;

            string errorMessage;
            DataSet ds = dbKH.TimKiemKhachHang(MaKH, TenKH,GioiTinh, SoDT, Email, DiaChi, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi : " + errorMessage);
            }
            else
            {
                dtTimKiemKhachHang = ds.Tables[0];
                dgvTimKiemKhachHang.DataSource = dtTimKiemKhachHang;
                txtMaKH1.ResetText();
                txtTenKH1.ResetText();
                txtGioiTinh1.ResetText();
                txtSDT1.ResetText();
                txtEmail1.ResetText();  
                txtDiaChi1.ResetText();
            }
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
