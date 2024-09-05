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
    public partial class FrmChiTieu : Form
    {
        DataTable dtChiTieu = null;
        DataTable dtTimKiemChiTieu = null;
        bool Them;
        DBChitieu dbChiTieu;
        public FrmChiTieu()
        {
            InitializeComponent();
            dbChiTieu = new DBChitieu();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.CHITIEU' table. You can move, or remove it, as needed.
            this.cHITIEUTableAdapter.Fill(this.gYMCLUBDataSet.CHITIEU);
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.NHAPHANG' table. You can move, or remove it, as needed.           
            LoadData();
        }
        void LoadData()
        {
            dtChiTieu = new DataTable();
            dtChiTieu.Clear();
            dtChiTieu = dbChiTieu.LayChiTieu().Tables[0];

            dgvChiTieu.DataSource = dtChiTieu;
            dgvTimKiemChiTieu.DataSource = dtChiTieu;

            txtMaCT.ResetText();
            txtMucDich.ResetText();
            txtTien.ResetText();
            dtpThoiGianCT.Value = DateTime.Today.Date;

            btnSave1.Enabled = false;
            btnCancel1.Enabled = false;
            // Cho thao tác trên các nút ReLoad, thêm, sửa, xóa, thoát
            btnReload1.Enabled = true;
            btnAdd1.Enabled = true;
            btnChange1.Enabled = true;
            btnExit1.Enabled = true;
            btnDelete1.Enabled = true;

            panel2.Enabled = false;
            dgvChiTieu_SelectionChanged(null, null);
        }

        private void dgvChiTieu_SelectionChanged(object sender, EventArgs e)
        {
            int r = dgvChiTieu.CurrentCell.RowIndex;

            txtMaCT.Text = dgvChiTieu.Rows[r].Cells[0].Value.ToString();
            txtMucDich.Text = dgvChiTieu.Rows[r].Cells[1].Value.ToString();
            txtTien.Text = dgvChiTieu.Rows[r].Cells[2].Value.ToString();
            if (dgvChiTieu.Rows[r].Cells[3].Value != null)
            {
                DateTime ThoiGianGiaoDich;
                if (DateTime.TryParse(dgvChiTieu.Rows[r].Cells[3].Value.ToString(), out ThoiGianGiaoDich))
                {
                    dtpThoiGianCT.Value = ThoiGianGiaoDich;
                }
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaCT.ResetText();
            txtMucDich.ResetText();
            txtTien.ResetText();
            dtpThoiGianCT.Value = DateTime.Today.Date;

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
            this.txtMaCT.Focus();
        }

        private void btnChange1_Click(object sender, EventArgs e)
        {
            dgvChiTieu_SelectionChanged(null, null);
            Them = false;
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
            this.txtMaCT.Focus();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
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
                    bool f = dbChiTieu.XoaChiTieu(ref err, txtMaCT.Text);
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

                    f = dbChiTieu.ThemChiTieu(ref err, txtMaCT.Text, txtMucDich.Text, txtTien.Text, dtpThoiGianCT.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    f = dbChiTieu.SuaChiTieu(ref err, txtMaCT.Text, txtMucDich.Text, txtTien.Text, dtpThoiGianCT.Value.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            txtMaCT.ResetText();
            txtMucDich.ResetText();
            txtTien.ResetText();
            dtpThoiGianCT.Value = DateTime.Today.Date;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaCT = null;
            if (txtMaCT1.Text != "")
            {
                MaCT = txtMaCT1.Text;
            }
            string MucDich = null;
            if (txtMucDich1.Text != "")
            {
                MucDich = txtMucDich1.Text;
            }
            int? Tien = null;
            if (txtTien1.Text != "")
            {
                try { Tien = Convert.ToInt32(txtTien1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Chi Phi phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DateTime? ThoiGianChiTra = DateTime.Today.Date;
            if (dtpThoiGianCT1.Value != DateTime.Today.Date)
            {
                ThoiGianChiTra = dtpThoiGianCT1.Value.Date;
            }
            string errorMessage;
            DataSet ds = dbChiTieu.TimKiemChiTieu(MaCT, MucDich, Tien, ThoiGianChiTra, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {

                dtTimKiemChiTieu = ds.Tables[0];
                dgvTimKiemChiTieu.DataSource = dtTimKiemChiTieu;

                txtMaCT1.ResetText();
                txtMucDich1.ResetText();
                txtTien1.ResetText();
                dtpThoiGianCT1.Value = DateTime.Today.Date;
            }
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
