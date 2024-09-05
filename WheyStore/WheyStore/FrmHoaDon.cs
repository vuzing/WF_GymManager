using BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WheyStore
{
    public partial class FrmHoaDon : Form
    {
        DataTable dtHoaDon = null;
        DataTable dtTimHoaDon = null;
        DataTable dtNhanVien = null;
        DataTable dtThucPham = null;
        DataTable dtLoaiTP = null;
        DataTable dtKhachHang = null;
        bool Them;
        DBHoaDon dbHoaDon;
        DBNhanvien dbNhanVien;
        DBThucphambosung dbThucPham;
        DBLoaiTPBS dbLoaiTP;
        DBKhachHang dbKhachHang;

        public FrmHoaDon()
        {
            InitializeComponent();
            dbHoaDon = new DBHoaDon();
            dbNhanVien = new DBNhanvien();
            dbThucPham = new DBThucphambosung();
            dbLoaiTP = new DBLoaiTPBS();
            dbKhachHang = new DBKhachHang();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            dtNhanVien = new DataTable();
            dtNhanVien.Clear();
            dtNhanVien = dbNhanVien.LayNV().Tables[0];
            MaNV.DataSource = dtNhanVien;
            MaNV.DisplayMember = "MaNV";
            MaNV.ValueMember = "MaNV";

            dtThucPham = new DataTable();
            dtThucPham.Clear();
            dtThucPham = dbThucPham.LayTPBS().Tables[0];
            MaTP.DataSource = dtThucPham;
            MaTP.DisplayMember = "MaTP";
            MaTP.ValueMember = "MaTP";

            dtLoaiTP = new DataTable();
            dtLoaiTP.Clear();
            dtLoaiTP = dbLoaiTP.LayLoaiTPBS().Tables[0];
            MaLoaiTP.DataSource = dtThucPham;
            MaLoaiTP.DisplayMember = "MaLoaiTP";
            MaLoaiTP.ValueMember = "MaLoaiTP";

            dtKhachHang = new DataTable();
            dtKhachHang.Clear();
            dtKhachHang = dbKhachHang.LayKhachHang().Tables[0];
            MaKH.DataSource = dtKhachHang;
            MaKH.DisplayMember = "MaKH";
            MaKH.ValueMember = "MaKH";

            dtHoaDon = new DataTable();
            dtHoaDon = dbHoaDon.LayHoaDon().Tables[0];
            dgvHoaDon.DataSource = dtHoaDon;

            MaNV1.DataSource = dtNhanVien;
            MaNV1.DisplayMember = "MaNV";
            MaNV1.ValueMember = "MaNV";

            MaTP1.DataSource = dtThucPham;
            MaTP1.DisplayMember = "MaTP";
            MaTP1.ValueMember = "MaTP";

            MaloaiTP1.DataSource = dtThucPham;
            MaloaiTP1.DisplayMember = "MaLoaiTP";
            MaloaiTP1.ValueMember = "MaLoaiTP";

            MaKH1.DataSource = dtKhachHang;
            MaKH1.DisplayMember = "MaKH";
            MaKH1.ValueMember = "MaKH";

            dgvTimHoaDon.DataSource = dtHoaDon;

            cbbMaNV.DataSource = dtNhanVien;
            cbbMaNV.DisplayMember = "MaNV";
            cbbMaNV.ValueMember = "MaNV";

            cbbMaNV1.DataSource = dtNhanVien;
            cbbMaNV1.DisplayMember = "MaNV";
            cbbMaNV1.ValueMember = "MaNV";

            cbbMaTP.DataSource = dtThucPham;
            cbbMaTP.DisplayMember = "MaTP";
            cbbMaTP.ValueMember = "MaTP";

            cbbMaTP1.DataSource = dtThucPham;
            cbbMaTP1.DisplayMember = "MaTP";
            cbbMaTP1.ValueMember = "MaTP";

            cbbMaLoaiTP.DataSource = dtThucPham;
            cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            cbbMaLoaiTP.ValueMember = "MaLoaiTP";

            cbbMaLoaiTP1.DataSource = dtThucPham;
            cbbMaLoaiTP1.DisplayMember = "MaLoaiTP";
            cbbMaLoaiTP1.ValueMember = "MaLoaiTP";

            cbbMaKH.DataSource = dtKhachHang;
            cbbMaKH.DisplayMember = "MaKH";
            cbbMaKH.ValueMember = "MaKH";

            cbbMaKH1.DataSource = dtKhachHang;
            cbbMaKH1.DisplayMember = "MaKH";
            cbbMaKH1.ValueMember = "MaKH";
            dtpThoiGian.MinDate = DateTime.MinValue;
            dtpThoiGian1.MinDate = DateTime.MinValue;
            txtMaHD.ResetText();
            cbbMaNV.ResetText();
            cbbMaTP.ResetText();
            cbbMaLoaiTP.ResetText();
            cbbMaKH.ResetText();
            txtSoLuong.ResetText();
            txtTien.ResetText();
            txtGhiChu.ResetText();

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            btnReload.Enabled = true;
            btnAdd.Enabled = true;
            btnChange.Enabled = true;
            btnExit.Enabled = true;
            //
            cbbMaNV1.SelectedItem = null;
            cbbMaTP1.SelectedItem = null;
            cbbMaLoaiTP1.SelectedItem = null;
            cbbMaKH1.SelectedItem = null;
            panel2.Enabled = false;
            //
            dgvHoaDon_SelectionChanged(null, null);
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            txtMaHD.Text = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            cbbMaNV.Text = dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            cbbMaTP.Text = dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            cbbMaLoaiTP.Text = dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            cbbMaKH.Text = dgvHoaDon.Rows[r].Cells[4].Value.ToString();
            txtSoLuong.Text = dgvHoaDon.Rows[r].Cells[5].Value.ToString();
            txtTien.Text = dgvHoaDon.Rows[r].Cells[6].Value.ToString();
            txtGhiChu.Text = dgvHoaDon.Rows[r].Cells[7].Value.ToString();

            if (dgvHoaDon.Rows[r].Cells[8].Value != null)
            {
                DateTime ThoiGianThanhToan;
                if (DateTime.TryParse(dgvHoaDon.Rows[r].Cells[8].Value.ToString(), out ThoiGianThanhToan))
                {
                    dtpThoiGian.Value = ThoiGianThanhToan;
                }
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaHD.ResetText();
            txtSoLuong.ResetText();
            txtTien.ResetText();
            txtGhiChu.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            panel2.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;
            txtMaHD.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            panel2.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;

            txtMaHD.Focus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa Hóa Đơn không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbHoaDon.XoaHoaDon(ref err, txtMaHD.Text);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được Hóa Đơn!\n\r" + "Lỗi:" + err);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            txtMaHD.ResetText();
            txtSoLuong.ResetText();
            txtTien.ResetText();
            txtGhiChu.ResetText();
            cbbMaNV.ResetText();
            cbbMaTP.ResetText();
            cbbMaLoaiTP.ResetText();
            cbbMaKH.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd.Enabled = true;
            this.btnChange.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnExit.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.panel2.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnSaveXuatHD_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {

                    f = dbHoaDon.ThemHoaDon(ref err, txtMaHD.Text, cbbMaNV.SelectedValue.ToString(), cbbMaTP.SelectedValue.ToString(),
                        cbbMaLoaiTP.SelectedValue.ToString(), cbbMaKH.SelectedValue.ToString(), txtSoLuong.Text, 
                        txtTien.Text, txtGhiChu.Text ,dtpThoiGian.Value.ToString("yyyy - MM - dd hh: mm:ss"));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Xuất Hóa Đơn xong!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không Xuất được Hóa Đơn. Lỗi rồi!");
                }
            }
            else
            {
                string err = "";
                try
                {
                    f = dbHoaDon.SuaHoaDon(ref err, txtMaHD.Text, cbbMaNV.SelectedValue.ToString(), cbbMaTP.SelectedValue.ToString(),
                        cbbMaLoaiTP.SelectedValue.ToString(), cbbMaKH.SelectedValue.ToString(), txtSoLuong.Text,
                        txtTien.Text, txtGhiChu.Text, dtpThoiGian.Value.ToString("yyyy - MM - dd hh: mm:ss"));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Cập nhật và Xuất Hóa đơn xong!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật và Xuất Hóa đơn được. Lỗi rồi!");
                }
            }
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaHD = null;
            if (txtMaHD1.Text != "")
            {
                MaHD = txtMaHD1.Text;
            }
            string MaNV = null;
            if (cbbMaNV1.SelectedValue != null)
            {
                MaNV = cbbMaNV1.SelectedValue.ToString();
            }
            string MaTP = null;
            if (cbbMaTP1.SelectedValue != null)
            {
                MaTP = cbbMaTP1.SelectedValue.ToString();
            }
            string MaLoaiTP = null;
            if (cbbMaLoaiTP1.SelectedValue != null)
            {
                MaLoaiTP = cbbMaLoaiTP1.SelectedValue.ToString();
            }

            DateTime? ThoiGianThanhToan = DateTime.Today.Date;
            if (dtpThoiGian.Value != DateTime.Today.Date)
            {
                ThoiGianThanhToan = dtpThoiGian1.Value.Date;
            }          

            string MaKH = null;
            if (cbbMaKH1.SelectedValue != null)
            {
                MaKH = cbbMaKH1.SelectedValue.ToString();
            }

            int? SoLuong = null;
            if (txtSoLuong1.Text != "")
            {
                try { SoLuong = Convert.ToInt32(txtSoLuong1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số Lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int? SoTien = null;
            if (txtTien1.Text != "")
            {
                try { SoTien = Convert.ToInt32(txtTien1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số Tiền phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string GhiChu = null;
            if (txtGhiChu1.Text != "")
            {
                GhiChu = txtGhiChu1.Text;
            }


            string errorMessage;
            DataSet dsTimHoaDon = dbHoaDon.TimKiemHoaDon(MaHD, MaNV, MaTP, MaLoaiTP, MaKH, SoLuong,
                SoTien, GhiChu, ThoiGianThanhToan, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {

                dtTimHoaDon = dsTimHoaDon.Tables[0];
                dgvTimHoaDon.DataSource = dtTimHoaDon;

                txtMaHD.ResetText();
                txtSoLuong.ResetText();
                txtTien.ResetText();
                txtGhiChu.ResetText();
                cbbMaNV.ResetText();
                cbbMaTP.ResetText();
                cbbMaLoaiTP.ResetText();
                cbbMaKH.ResetText();
            }
        }
    }
}
