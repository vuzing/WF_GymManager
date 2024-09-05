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
    public partial class FrmThanhVien : Form
    {
        DataTable dtTV = null;
        DataTable dtTimKiemTV = null;
        bool Them;
        DBThanhvien dbTV;

        public FrmThanhVien()
        {
            InitializeComponent();
            dbTV = new DBThanhvien();
        }

        private void FrmThanhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.THANHVIEN' table. You can move, or remove it, as needed.
            this.tHANHVIENTableAdapter.Fill(this.gYMCLUBDataSet.THANHVIEN);
            LoadData();
        }

        void LoadData()
        {
            dtTV = new DataTable();
            dtTV.Clear();
            dtTV = dbTV.LayThanhVien().Tables[0];

            dgvThanhVien.DataSource = dtTV;
          

            txtMaTV.ResetText();
            txtGioiTinh.ResetText();
            txtTenTV.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();

            dgvThanhVien.Columns["NGAYBATDAU"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvThanhVien.Columns["NGAYKETTHUC"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvTimKiemTV.DataSource = dtTV;
            dtpNgayBD.Value = DateTime.Today.Date;
            dtpNgayKT.Value = DateTime.Today.Date;
            dtpNgayBD1.Value = DateTime.Today.Date;
            dtpNgayKT1.Value = DateTime.Today.Date;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            // Cho thao tác trên các nút ReLoad, thêm, sửa, xóa, thoát
            btnReload.Enabled = true;
            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnExit.Enabled = true;
            btnDelete.Enabled = true;

            panel2.Enabled = false;
            dgvThanhVien_SelectionChanged_1(null, null);
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
           LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }
     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaTV.ResetText();
            txtGioiTinh.ResetText();
            txtTenTV.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            dtpNgayBD.ResetText();
            dtpNgayKT.ResetText();

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
            this.txtMaTV.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
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
            this.txtMaTV.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaTV.ResetText();
            txtGioiTinh.ResetText();
            txtTenTV.ResetText();
            txtSDT.ResetText();
            txtEmail.ResetText();
            dtpNgayBD.ResetText();
            dtpNgayKT.ResetText();

            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;
            // Cho thao tác trên các nút lưu, hủy, reload và mở panel
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            panel2.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbTV.XoaThanhVien(ref err, txtMaTV.Text);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
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

                    f = dbTV.ThemThanhVien(ref err, txtMaTV.Text, txtTenTV.Text, txtGioiTinh.Text, txtSDT.Text,
                        txtEmail.Text, dtpNgayBD.Value.ToString("yyyy - MM - dd hh: mm:ss"), dtpNgayKT.Value.ToString("yyyy - MM - dd hh: mm:ss"));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                string err = "";
                try
                {
                    f = dbTV.SuaThanhVien(ref err, txtMaTV.Text, txtTenTV.Text, txtGioiTinh.Text, txtSDT.Text,
                        txtEmail.Text, dtpNgayBD.Value.ToString("yyyy - MM - dd hh: mm:ss"), dtpNgayKT.Value.ToString("yyyy - MM - dd hh: mm:ss"));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaTV = null;
            if (txtMaTV1.Text != "")
            {
                MaTV = txtMaTV1.Text;
            }
            string TenTV = null;
            if (txtTenTV1.Text != "")
            {
                TenTV = txtTenTV1.Text;
            }

            string Gioitinh = null;
            if (txtGioiTinh1.Text != "")
            {
                Gioitinh = txtGioiTinh1.Text;
            }

            int? SoDT = null;
            if (txtSDT1.Text != "")
            {
                try { SoDT = Convert.ToInt32(txtSDT1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Chi Phí phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string Email = null;
            if (txtEmail1.Text != "")
            {
                Email = txtEmail1.Text;
            }


            DateTime? NgayBD = DateTime.Today.Date;
            if (dtpNgayBD1.Value != DateTime.Today.Date)
            {
                NgayBD = dtpNgayBD1.Value.Date;
            }

            DateTime? NgayKT = DateTime.Today.Date;
            if (dtpNgayKT1.Value != DateTime.Today.Date)
            {
                NgayKT = dtpNgayKT1.Value.Date;
            }

            string errorMessage;
            DataSet ds = dbTV.TimKiemThanhVien(MaTV, TenTV, Gioitinh, SoDT, Email, NgayBD, NgayKT, out errorMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                dgvTimKiemTV.DataSource = ds.Tables[0];
                dgvTimKiemTV.AutoResizeColumns();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {

                dtTimKiemTV = ds.Tables[0];
                dgvTimKiemTV.DataSource = dtTimKiemTV;


                txtMaTV1.ResetText();
                txtGioiTinh1.ResetText();
                txtTenTV1.ResetText();
                txtSDT1.ResetText();
                txtEmail1.ResetText();
         
            }
        }

        private void dgvThanhVien_SelectionChanged_1(object sender, EventArgs e)
        {
            int r = dgvThanhVien.CurrentCell.RowIndex;
            txtMaTV.Text = dgvThanhVien.Rows[r].Cells[0].Value.ToString();
            txtTenTV.Text = dgvThanhVien.Rows[r].Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvThanhVien.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dgvThanhVien.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dgvThanhVien.Rows[r].Cells[4].Value.ToString();

            if (dgvThanhVien.Rows[r].Cells[5].Value != null)
            {
                DateTime ThoiGianGiaoDich;
                if (DateTime.TryParse(dgvThanhVien.Rows[r].Cells[5].Value.ToString(), out ThoiGianGiaoDich))
                {
                    dtpNgayBD.Value = ThoiGianGiaoDich;
                }
            }
            if (dgvThanhVien.Rows[r].Cells[6].Value != null)
            {
                DateTime ThoiGianGiaoDich;
                if (DateTime.TryParse(dgvThanhVien.Rows[r].Cells[6].Value.ToString(), out ThoiGianGiaoDich))
                {
                    dtpNgayKT.Value = ThoiGianGiaoDich;
                }
            }
        }
    }
}
