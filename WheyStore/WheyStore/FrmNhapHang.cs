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
    public partial class FrmNhapHang : Form
    {
        DataTable dtNhapHang;
        DataTable dtTPBS;
        DataTable dtLoaiTP;
        DataTable dtNCC;
        DataTable dtTKNH;
        bool Them;
        DBNhapHang dbNhapHang;
        DBThucphambosung dbTPBS;
        DBLoaiTPBS dbLoaiTP;
        DBNhacungcap dbNCC;
        public FrmNhapHang()
        {
            InitializeComponent();
            dbNhapHang = new DBNhapHang();
            dbTPBS = new DBThucphambosung();
            dbLoaiTP = new DBLoaiTPBS();
            dbNCC = new DBNhacungcap();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.NHAPHANG' table. You can move, or remove it, as needed.
            this.nHAPHANGTableAdapter.Fill(this.gYMCLUBDataSet.NHAPHANG);
            LoadData();
         
           
        }
        void LoadData() 
        {
            dtLoaiTP = new DataTable();
            dtLoaiTP.Clear();
            dtLoaiTP = dbLoaiTP.LayLoaiTPBS().Tables[0];
            LoaiTP.DataSource = dtLoaiTP;
            LoaiTP.DisplayMember = "MaLoaiTP";
            LoaiTP.ValueMember = "MaLoaiTP";

            dtTPBS = new DataTable();
            dtTPBS.Clear();
            dtTPBS = dbTPBS.LayTPBS().Tables[0];            

            MaTP.DataSource = dtTPBS;
            MaTP.DisplayMember = "MaTP";
            MaTP.ValueMember = "MaTP";

            dtNCC = new DataTable();
            dtNCC.Clear();
            dtNCC = dbNCC.LayNCC().Tables[0];
            MaNCC.DataSource = dtNCC;
            MaNCC.DisplayMember = "MaNCC";
            MaNCC.ValueMember = "MaNCC";

            dtNhapHang = new DataTable();
            dtNhapHang = dbNhapHang.LayNhapHang().Tables[0];
            dgvNhapHang.Columns["NgayNhap"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";            
            dgvNhapHang.DataSource = dtNhapHang;
            //
            dgvTimKiemNhapHang.DataSource = dtNhapHang;

            LoaiTP1.DataSource = dtLoaiTP;
            LoaiTP1.DisplayMember = "MaLoaiTP";
            LoaiTP1.ValueMember = "MaLoaiTP";

            MaTP1.DataSource = dtTPBS;
            MaTP1.DisplayMember = "MaTP";
            MaTP1.ValueMember = "MaTP";


            MaNCC1.DataSource = dtNCC;
            MaNCC1.DisplayMember = "MaNCC";
            MaNCC1.ValueMember = "MaNCC";

            cbbMaLoaiTP1.DataSource = dtLoaiTP;
            cbbMaLoaiTP1.DisplayMember = "MaLoaiTP";
            cbbMaLoaiTP1.ValueMember = "MaLoaiTP";

            cbbMaTP1.DataSource = dtTPBS;
            cbbMaTP1.DisplayMember = "MaTP";
            cbbMaTP1.ValueMember = "MaTP";


            cbbMaNCC1.DataSource = dtNCC;
            cbbMaNCC1.DisplayMember = "MaNCC";
            cbbMaNCC1.ValueMember = "MaNCC";

            dgvNhapHang.AutoResizeColumns();

            this.txtMaNH.ResetText();
            this.txtSoLuong.ResetText();
            this.txtTongTien.ResetText();
            dtpNgayNhap.MinDate = DateTime.MinValue;
            dtpNgayNhap1.MinDate = DateTime.MinValue;

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            panel3.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnChange.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnExit.Enabled = true;          
            cbbMaNCC1.SelectedItem = null;
            cbbMaTP1.SelectedItem = null;
            cbbMaLoaiTP1.SelectedItem = null;
            dgvNhapHang_SelectionChanged(null, null);

        }

        private void dgvNhapHang_SelectionChanged(object sender, EventArgs e)
        {
            this.cbbMaNCC.DataSource = dtNCC;
            this.cbbMaNCC.DisplayMember = "MaNCC";
            this.cbbMaNCC.ValueMember = "MaNCC";
            //
            this.cbbMaTP.DataSource = dtTPBS;
            this.cbbMaTP.DisplayMember = "MaTP";
            this.cbbMaTP.ValueMember = "MaTP";
            //
            this.cbbMaLoaiTP.DataSource = dtLoaiTP;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            //
            int r = dgvNhapHang.CurrentCell.RowIndex;
            txtMaNH.Text = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
            this.cbbMaNCC.SelectedValue =
            dgvNhapHang.Rows[r].Cells[1].Value.ToString();
            this.cbbMaTP.SelectedValue =
            dgvNhapHang.Rows[r].Cells[2].Value.ToString();
            this.cbbMaLoaiTP.SelectedValue =
            dgvNhapHang.Rows[r].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvNhapHang.Rows[r].Cells[4].Value.ToString();
            txtTongTien.Text = dgvNhapHang.Rows[r].Cells[5].Value.ToString();
            if (dgvNhapHang.Rows[r].Cells[6].Value != null)
            {
                DateTime ThoiGian;
                if (DateTime.TryParse(dgvNhapHang.Rows[r].Cells[6].Value.ToString(), out ThoiGian))
                {
                    dtpNgayNhap.Value = ThoiGian;
                }
            }
                       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaNH.Enabled = true;
            this.cbbMaNCC.DataSource = dtNCC;
            this.cbbMaNCC.DisplayMember = "MaNCC";
            this.cbbMaNCC.ValueMember = "MaNCC";
            //
            this.cbbMaTP.DataSource = dtTPBS;
            this.cbbMaTP.DisplayMember = "MaTP";
            this.cbbMaTP.ValueMember = "MaTP";
            //
            this.cbbMaLoaiTP.DataSource = dtLoaiTP;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            this.txtSoLuong.ResetText();
            this.txtTongTien.ResetText();

            dtpNgayNhap.MinDate = DateTime.MinValue;

            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnReload.Enabled = true;
            panel3.Enabled = true;

            this.txtMaNH.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel3.Enabled = true;
            dgvNhapHang_SelectionChanged(null, null);
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.panel3.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnChange.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExit.Enabled = false;
            this.cbbMaNCC.DataSource = dtNCC;
            this.cbbMaNCC.DisplayMember = "MaNCC";
            this.cbbMaNCC.ValueMember = "MaNCC";
            //
            this.cbbMaTP.DataSource = dtTPBS;
            this.cbbMaTP.DisplayMember = "MaTP";
            this.cbbMaTP.ValueMember = "MaTP";
            //
            this.cbbMaLoaiTP.DataSource = dtLoaiTP;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            dtpNgayNhap.MinDate = DateTime.MinValue;
            txtMaNH.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvNhapHang.CurrentCell.RowIndex;
                string strMaNH = dgvNhapHang.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbNhapHang.XoaNhapHang(ref err, strMaNH);
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
                MessageBox.Show("Không xóa được. Lỗi : " + ex.Message);
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
                    f = dbNhapHang.ThemNhapHang(ref err, txtMaNH.Text,cbbMaNCC.SelectedValue.ToString(),
                        cbbMaTP.SelectedValue.ToString(),cbbMaLoaiTP.SelectedValue.ToString(),txtSoLuong.Text,txtTongTien.Text,dtpNgayNhap.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thàng công!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                string err = "";
                try
                {
                    f = dbNhapHang.SuaNhapHang(ref err, txtMaNH.Text, cbbMaNCC.SelectedValue.ToString(), cbbMaTP.SelectedValue.ToString(),
                        cbbMaLoaiTP.SelectedValue.ToString(), txtSoLuong.Text, txtTongTien.Text, dtpNgayNhap.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Lỗi: " + ex.Message);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMaNH.ResetText();
            this.txtSoLuong.ResetText();
            this.txtTongTien.ResetText();
            this.btnAdd.Enabled = true;
            this.btnChange.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnExit.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.panel3.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void btnExit_Click(object sender, EventArgs e)
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
            string MaNH = null;
            if (txtMaNH1.Text != "")
                MaNH = txtMaNH1.Text;
            string MaNCC = null;
            if (cbbMaNCC1.SelectedValue != null)
            {
                MaNCC = cbbMaNCC1.SelectedValue.ToString();
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
            int? SoLuong = null;
            if (txtSoLuong1.Text != "")
            {
                try { SoLuong = Convert.ToInt32(txtSoLuong1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int? TongTien = null;
            if (txtTongTien1.Text != "")
            {
                try { TongTien = Convert.ToInt32(txtTongTien1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Tổng tiền phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DateTime? NgayNhap = DateTime.Today.Date;
            if (dtpNgayNhap1.Value != DateTime.Today.Date)
            {
                NgayNhap = dtpNgayNhap1.Value.Date;
            }
            
            string errorMessage;
            DataSet dsGiaoDich = dbNhapHang.TimKiemNhapHang(MaNH, MaNCC, MaTP, MaLoaiTP, SoLuong, TongTien, NgayNhap, out errorMessage);
            if (dsGiaoDich != null && dsGiaoDich.Tables.Count > 0)
            {
                dgvTimKiemNhapHang.DataSource = dsGiaoDich.Tables[0];
                dgvTimKiemNhapHang.AutoResizeColumns();
            }


            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {
                dtTKNH = dsGiaoDich.Tables[0];
                dgvTimKiemNhapHang.DataSource = dtTKNH;
                txtMaNH.ResetText();
                cbbMaNCC1.SelectedValue = "";
                cbbMaTP1.SelectedValue = "";
                cbbMaLoaiTP1.SelectedValue = "";
                txtSoLuong1.ResetText();
                txtTongTien1.ResetText();

            }
        }
    }
}
