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
    public partial class FrmPT : Form
    {
        DataTable dtPT = null;
        DataTable dtTimKiemPT = null;
        bool Them;
        DBPersonaltrainer dbPT;
        public FrmPT()
        {
            InitializeComponent();
            dbPT = new DBPersonaltrainer();
        }

        private void FrmPT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.PERSONALTRAINER' table. You can move, or remove it, as needed.
            this.pERSONALTRAINERTableAdapter.Fill(this.gYMCLUBDataSet.PERSONALTRAINER);
            LoadData();

        }
        void LoadData()
        {
            dtPT = new DataTable();
            dtPT.Clear();
            dtPT = dbPT.LayPT().Tables[0];

            dgvPT.DataSource = dtPT;
            dgvPT.AutoResizeColumns();

            dgvTimKiemPT.DataSource = dtPT;
            dgvTimKiemPT.AutoResizeColumns();
            this.txtMaPT.ResetText();
            this.txtTenPT.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();
            this.txtThh.ResetText();

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
            dgvPT_CellContentClick(null, null);
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

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPT.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int r = dgvPT.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaPT.Text =
            dgvPT.Rows[r].Cells[0].Value.ToString();
            this.txtTenPT.Text =
            dgvPT.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text =
            dgvPT.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvPT.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text =
            dgvPT.Rows[r].Cells[4].Value.ToString();
            this.txtLuong.Text =
            dgvPT.Rows[r].Cells[5].Value.ToString();
            this.txtThh.Text =
            dgvPT.Rows[r].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaPT.ResetText();
            this.txtTenPT.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();
            this.txtThh.ResetText();

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
            this.txtMaPT.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            //
            txtMaPT.Enabled = true;
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
            this.txtTenPT.Focus();
            dgvPT_CellContentClick(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvPT.CurrentCell.RowIndex;
                string strPT = dgvPT.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa PT này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbPT.XoaPT(ref err, strPT);
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {
                    f = dbPT.ThemPT(ref err, txtMaPT.Text, txtTenPT.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtLuong.Text, txtThh.Text);
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
                    f = dbPT.SuaPT(ref err, txtMaPT.Text, txtTenPT.Text, txtGioiTinh.Text,
                        txtSDT.Text, txtEmail.Text, txtLuong.Text, txtThh.Text);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMaPT.ResetText();
            this.txtTenPT.ResetText();
            this.txtGioiTinh.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtLuong.ResetText();
            this.txtThh.ResetText();

            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void dgvPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPT.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaPT.Text =
            dgvPT.Rows[r].Cells[0].Value.ToString();
            this.txtTenPT.Text =
            dgvPT.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text =
            dgvPT.Rows[r].Cells[2].Value.ToString();
            this.txtSDT.Text =
            dgvPT.Rows[r].Cells[3].Value.ToString();
            this.txtEmail.Text =
            dgvPT.Rows[r].Cells[4].Value.ToString();
            this.txtLuong.Text =
            dgvPT.Rows[r].Cells[5].Value.ToString();
            this.txtThh.Text =
            dgvPT.Rows[r].Cells[5].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaPT = null;
            if (txtMaPT1.Text != "")
                MaPT = txtMaPT1.Text;
            string TenPT = null;
            if (txtTenPT1.Text != "")
                TenPT = txtTenPT1.Text;
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
            int? THH = null;
            if (txtThh1.Text != "")
            {
                try { THH = Convert.ToInt32(txtThh1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi:Tiền hoa hồng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string errorMessage;
            DataSet ds = dbPT.TimPT(MaPT, TenPT, GioiTinh, SoDT, Email, Luong,THH, out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi : " + errorMessage);
            }
            else
            {
                dtTimKiemPT = ds.Tables[0];
                dgvTimKiemPT.DataSource = dtTimKiemPT;
                txtMaPT1.ResetText();
                txtTenPT1.ResetText();
                txtGioiTinh1.ResetText();
                txtSDT1.ResetText();
                txtEmail1.ResetText();
                txtLuong1.ResetText();
                txtThh1.ResetText();
            }
        }
    }
        
}
