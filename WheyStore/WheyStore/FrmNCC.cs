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
    public partial class FrmNCC : Form
    {
        DataTable dtNCC = null;
        DataTable dtTimKiemNCC = null;
        DBNhacungcap dbNCC;
        bool Them;
        public FrmNCC()
        {
            InitializeComponent();
            dbNCC = new DBNhacungcap();
        }

        private void FrmNCC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.nHACUNGCAPTableAdapter.Fill(this.gYMCLUBDataSet.NHACUNGCAP);
            LoadData();

        }
        void LoadData()
        {
            dtNCC = new DataTable();
            dtNCC.Clear();
            dtNCC = dbNCC.LayNCC().Tables[0];

            dgvNCC.DataSource = dtNCC;
            dgvNCC.AutoResizeColumns();

            dgvTimKiemNCC.DataSource = dtNCC;
            dgvTimKiemNCC.AutoResizeColumns();
            this.txtMaNCC.ResetText();
            this.txtTenNCC.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();


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
            dgvNCC_CellContentClick(null, null);
            dgvNCC_CellClick(null, null);
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNCC.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            dgvNCC.Rows[r].Cells[0].Value.ToString();
            this.txtTenNCC.Text =
            dgvNCC.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text =
            dgvNCC.Rows[r].Cells[2].Value.ToString();
            this.txtEmail.Text =
            dgvNCC.Rows[r].Cells[3].Value.ToString();
            this.txtSDT.Text =
            dgvNCC.Rows[r].Cells[4].Value.ToString();
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNCC.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int r = dgvNCC.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaNCC.Text =
            dgvNCC.Rows[r].Cells[0].Value.ToString();
            this.txtTenNCC.Text =
            dgvNCC.Rows[r].Cells[1].Value.ToString();
            this.txtDiaChi.Text =
            dgvNCC.Rows[r].Cells[2].Value.ToString();            
            this.txtEmail.Text =
            dgvNCC.Rows[r].Cells[3].Value.ToString();
            this.txtSDT.Text =
            dgvNCC.Rows[r].Cells[4].Value.ToString();

        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaNCC.ResetText();
            this.txtTenNCC.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();

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
            this.txtMaNCC.Focus();
        }

        private void btnChange1_Click(object sender, EventArgs e)
        {
            Them = false;
            //
            txtMaNCC.Enabled = true;
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
            this.txtTenNCC.Focus();
            dgvNCC_CellContentClick(null, null);
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvNCC.CurrentCell.RowIndex;
                string strNCC = dgvNCC.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa nhà cung cấp này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbNCC.XoaNCC(ref err, strNCC);
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

        private void btnReload1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbNCC.ThemNCC(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text,
                        txtEmail.Text, txtSDT.Text);
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
                    f = dbNCC.SuaNCC(ref err, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text,
                        txtEmail.Text, txtSDT.Text);
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

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            this.txtMaNCC.ResetText();
            this.txtTenNCC.ResetText();
            this.txtEmail.ResetText();
            this.txtDiaChi.ResetText();
            this.txtSDT.ResetText();

            btnAdd1.Enabled = true;
            btnChange1.Enabled = true;
            btnDelete1.Enabled = true;
            btnExit1.Enabled = true;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnExit1_Click(object sender, EventArgs e)
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

        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaNCC = null;
            if (txtMaNCC1.Text != "")
                MaNCC = txtMaNCC1.Text;
            string TenKH = null;
            if (txtTenNCC1.Text != "")
                TenKH = txtTenNCC1.Text;
            string DiaChi = null;
            if (txtDiaChi1.Text != "")
                DiaChi = txtDiaChi1.Text;
            string Email = null;
            if (txtEmail1.Text != "")
                Email = txtEmail1.Text;          
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

            string errorMessage;
            DataSet ds = dbNCC.TimKiemNCC(MaNCC, TenKH, DiaChi , Email, SoDT, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi : " + errorMessage);
            }
            else
            {
                dtTimKiemNCC = ds.Tables[0];
                dgvTimKiemNCC.DataSource = dtTimKiemNCC;
                this.txtMaNCC1.ResetText();
                this.txtTenNCC1.ResetText();
                this.txtEmail1.ResetText();
                this.txtDiaChi1.ResetText();
                this.txtSDT1.ResetText();
            }
        }
    }
}
