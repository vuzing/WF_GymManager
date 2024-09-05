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
    public partial class FrmNhanVien : Form
    {
        DataTable dtNV = null;
        DataTable dtTimKiemNV = null;
        bool Them;
        DBNhanvien dbNV;
        public FrmNhanVien()
        {
            InitializeComponent();
            dbNV = new DBNhanvien();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.NHANVIENLETAN' table. You can move, or remove it, as needed.
            this.nHANVIENLETANTableAdapter.Fill(this.gYMCLUBDataSet.NHANVIENLETAN);
            LoadData();
        }
        void LoadData()
        {
            dtNV = new DataTable();
            dtNV.Clear();
            dtNV = dbNV.LayNV().Tables[0];

            dgvNV.DataSource = dtNV;
            dgvNV.AutoResizeColumns();

            dgvTimKiemNV.DataSource = dtNV;
            dgvTimKiemNV.AutoResizeColumns();
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            // Cho thao tác trên các nút ReLoad, thêm, sửa, xóa, thoát
            btnReload.Enabled = true;
            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnExit.Enabled = true;
            btnDelete.Enabled = true;
            //
            panel2.Enabled = false;
            dgvNV_CellContentClick(null, null);
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNV.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int r = dgvNV.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaNV.Text =
            dgvNV.Rows[r].Cells[0].Value.ToString();
            this.txtTenNV.Text =
            dgvNV.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text =
            dgvNV.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvNV.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text =
            dgvNV.Rows[r].Cells[4].Value.ToString();
            this.txtLuong.Text =
            dgvNV.Rows[r].Cells[5].Value.ToString();           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();
         

            // Không cho thao tác trên các nút thêm, sửa, xóa, thoát
            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnReload.Enabled = true;
            panel2.Enabled = true;
            this.txtMaNV.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            //
            txtMaNV.Enabled = true;
            // Không cho thao tác trên các nút thêm, sửa, xóa, thoát
            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnReload.Enabled = true;
            panel2.Enabled = true;
            // 
            this.txtTenNV.Focus();
            dgvNV_CellContentClick(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvNV.CurrentCell.RowIndex;
                string strNV = dgvNV.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbNV.XoaNV(ref err, strNV);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMaNV.ResetText();
            this.txtTenNV.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();

            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbNV.ThemNV(ref err, txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtLuong.Text);
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
                    f = dbNV.SuaNV(ref err, txtMaNV.Text, txtTenNV.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtLuong.Text);
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

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string MaNV = null;
            if (txtMaNV1.Text != "")
                MaNV = txtMaNV1.Text;
            string TenNV = null;
            if (txtTenNV1.Text != "")
                TenNV = txtTenNV1.Text;
            string GioiTinh = null;
            if (txtGioiTinh1.Text != "")
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
            int? Luong = null;
            if (txtLuong1.Text != "")
            {
                try { Luong = Convert.ToInt32(txtLuong1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi:Lương phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string errorMessage;
            DataSet ds = dbNV.TimNV(MaNV, TenNV, GioiTinh, SoDT, Email, Luong, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi : " + errorMessage);
            }
            else
            {
                dtTimKiemNV = ds.Tables[0];
                dgvTimKiemNV.DataSource = dtTimKiemNV;
                txtMaNV1.ResetText();
                txtTenNV1.ResetText();
                txtGioiTinh1.ResetText();
                txtSDT1.ResetText();
                txtEmail1.ResetText();
                txtLuong1.ResetText();

            }
        }

        private void btnReload2_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
