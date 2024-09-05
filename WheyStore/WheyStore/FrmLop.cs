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
    public partial class FrmLop : Form
    {
        DataTable dtLop=null;
        DataTable dtTimKiemLop =null;
        DataTable dtLoaiLop=null;
        DataTable dtPT = null;
        DataTable dtTV=null;
        bool Them;
        DBLop dbLop;
        DBLoaiLop dbLoaiLop;
        DBThanhvien dbTV;
        DBPersonaltrainer dbPT;

        public FrmLop()
        {
            InitializeComponent();
            dbLop = new DBLop();
            dbLoaiLop = new DBLoaiLop();
            dbPT = new DBPersonaltrainer();
            dbTV = new DBThanhvien();    
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.gYMCLUBDataSet.LOP);
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.LOAILOP' table. You can move, or remove it, as needed.
            this.lOAILOPTableAdapter.Fill(this.gYMCLUBDataSet.LOAILOP);
            LoadData();

        }
        void LoadData()
        {
            dtLoaiLop = new DataTable();
            dtLoaiLop.Clear();
            dtLoaiLop = dbLoaiLop.LayLoaiLop().Tables[0];
            dgvLoaiLop.DataSource = dtLoaiLop;
            
            MaLoaiLop.DataSource = dtLoaiLop;
            MaLoaiLop.DisplayMember = "MaLoaiLOP";
            MaLoaiLop.ValueMember = "MaLoaiLOP";

            dtPT = new DataTable();
            dtPT.Clear();
            dtPT = dbPT.LayPT().Tables[0];
            MaPT.DataSource = dtPT;

            MaPT.DataSource = dtPT;
            MaPT.DisplayMember = "MaPT";
            MaPT.ValueMember = "MaPT";

            dtTV = new DataTable();
            dtTV.Clear();
            dtTV = dbTV.LayThanhVien().Tables[0];
            MaTV.DataSource = dtTV;
            MaTV.DisplayMember = "MaTV";
            MaTV.ValueMember = "MaTV";

            dtLop = new DataTable();
            dtLop = dbLop.LayLop().Tables[0];
            dgvLop.Columns["NgayBD"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvLop.Columns["NgayKT"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvLop.DataSource = dtLop;
            dgvTimKiemLop.DataSource = dtLop;

            MaPT1.DataSource = dtPT;
            MaPT1.DisplayMember = "MaPT";
            MaPT1.ValueMember = "MaPT";

            MaTV1.DataSource = dtTV;
            MaTV1.DisplayMember = "MaTV";
            MaTV1.ValueMember = "MaTV";

            MaLoaiLop1.DataSource = dtLoaiLop;
            MaLoaiLop1.DisplayMember = "MaLoaiLOP";
            MaLoaiLop1.ValueMember = "MaLoaiLOP";
            dgvLop.AutoResizeColumns();
            dgvTimKiemLop.AutoResizeColumns();
            

            this.txtMaLop.ResetText();
           
            dtpNgayBD.MinDate = DateTime.MinValue;
            dtpNgayKT.MinDate = DateTime.MinValue;
            dtpNgayBD1.MinDate = DateTime.MinValue;
            dtpNgayKT1.MinDate = DateTime.MinValue;

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;

            this.btnAdd.Enabled = true;
            this.btnChange.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnExit.Enabled = true;
            //
            panel3.Enabled = false;
            //
            this.btnSave1.Enabled = false;
            this.btnCancel1.Enabled = false;
            this.panel2.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd1.Enabled = true;
            this.btnChange1.Enabled = true;
            this.btnDelete1.Enabled = true;
            this.btnExit1.Enabled = true;

            cbbMaLoaiLop1.DataSource = dtLoaiLop;
            cbbMaLoaiLop1.DisplayMember = "MaLoaiLOP";
            cbbMaLoaiLop1.ValueMember = "MaLoaiLOP";

            cbbMaPT1.DataSource = dtPT;
            cbbMaPT1.DisplayMember = "MaPT";
            cbbMaPT1.ValueMember = "MaPT";

            cbbMaTV1.DataSource = dtTV;
            cbbMaTV1.DisplayMember = "MaTV";
            cbbMaTV1.ValueMember = "MaTV";


            cbbMaLoaiLop1.SelectedItem = null;
            cbbMaPT1.SelectedItem = null;
            cbbMaTV1.SelectedItem = null;           
            dgvLop_SelectionChanged(null, null);
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            this.cbbMaLoaiLop.DataSource = dtLoaiLop;
            this.cbbMaLoaiLop.DisplayMember = "MaLoaiLop";
            this.cbbMaLoaiLop.ValueMember = "MaLoaiLop";
            this.cbbMaPT.DataSource = dtPT;
            this.cbbMaPT.DisplayMember = "MaPT";
            this.cbbMaPT.ValueMember = "MaPT";
            this.cbbMaTV.DataSource = dtTV;
            this.cbbMaTV.DisplayMember = "MaTV";
            this.cbbMaTV.ValueMember = "MaTV";
            int r = dgvLop.CurrentCell.RowIndex;
            txtMaLop.Text = dgvLop.Rows[r].Cells[0].Value.ToString();
            this.cbbMaLoaiLop.SelectedValue =
            dgvLop.Rows[r].Cells[1].Value.ToString();
            this.cbbMaPT.SelectedValue =
            dgvLop.Rows[r].Cells[2].Value.ToString();
            this.cbbMaTV.SelectedValue =
            dgvLop.Rows[r].Cells[3].Value.ToString();

            if (dgvLop.Rows[r].Cells[4].Value != null)
            {
                DateTime ThoiGianBatDau;
                if (DateTime.TryParse(dgvLop.Rows[r].Cells[4].Value.ToString(), out ThoiGianBatDau))
                {
                    dtpNgayBD.Value = ThoiGianBatDau;
                }
            }
            if (dgvLop.Rows[r].Cells[5].Value != null)
            {
                DateTime ThoiGianKetThuc;
                if (DateTime.TryParse(dgvLop.Rows[r].Cells[5].Value.ToString(), out ThoiGianKetThuc))
                {
                    dtpNgayKT.Value = ThoiGianKetThuc;
                }
            }
            txtGhiChu.Text = dgvLop.Rows[r].Cells[6].Value.ToString();
            txtCP.Text = dgvLop.Rows[r].Cells[7].Value.ToString();
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

        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnExit1_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnReload1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaLop.Enabled = true;
            this.cbbMaLoaiLop.DataSource = dtLoaiLop;
            this.cbbMaLoaiLop.DisplayMember = "MaLoaiLop";
            this.cbbMaLoaiLop.ValueMember = "MaLoaiLop";
            this.cbbMaPT.DataSource = dtPT;
            this.cbbMaPT.DisplayMember = "MaPT";
            this.cbbMaPT.ValueMember = "MaPT";
            this.cbbMaTV.DataSource = dtTV;
            this.cbbMaTV.DisplayMember = "MaTV";
            this.cbbMaTV.ValueMember = "MaTV";
            this.txtGhiChu.ResetText();
            this.txtCP.ResetText();
            
            dtpNgayBD.MinDate = DateTime.MinValue;
            dtpNgayKT.MinDate = DateTime.MinValue;

            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnReload.Enabled = true;
            panel3.Enabled = true;

            this.txtMaLop.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel3.Enabled = true;
            dgvLop_SelectionChanged(null,null);
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.panel3.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnChange.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExit.Enabled = false;
            this.cbbMaLoaiLop.DataSource = dtLoaiLop;
            this.cbbMaLoaiLop.DisplayMember = "MaLoaiLop";
            this.cbbMaLoaiLop.ValueMember = "MaLoaiLop";
            this.cbbMaPT.DataSource = dtPT;
            this.cbbMaPT.DisplayMember = "MaPT";
            this.cbbMaPT.ValueMember = "MaPT";
            this.cbbMaTV.DataSource = dtTV;
            this.cbbMaTV.DisplayMember = "MaTV";
            this.cbbMaTV.ValueMember = "MaTV";
            dtpNgayBD.MinDate = DateTime.MinValue;
            dtpNgayKT.MinDate = DateTime.MinValue;
            txtMaLop.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvLop.CurrentCell.RowIndex;
                string strMaLop = dgvLop.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    bool f = dbLop.XoaLop(ref err, strMaLop);
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
                    f = dbLop.ThemLop(ref err, txtMaLop.Text, cbbMaLoaiLop.SelectedValue.ToString(), cbbMaPT.SelectedValue.ToString(),
                        cbbMaTV.SelectedValue.ToString(), dtpNgayBD.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpNgayKT.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        txtGhiChu.Text,txtCP.Text);
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
                    f = dbLop.CapNhatLop(ref err, txtMaLop.Text, cbbMaLoaiLop.SelectedValue.ToString(), cbbMaPT.SelectedValue.ToString(),
                        cbbMaTV.SelectedValue.ToString(), dtpNgayBD.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpNgayKT.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        txtGhiChu.Text, txtCP.Text);

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
            this.txtMaLop.ResetText();
            this.txtCP.ResetText();
            this.txtGhiChu.ResetText();          
            this.btnAdd.Enabled = true;
            this.btnChange.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnExit.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.panel3.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {         
            string MaLop = null;
            if (txtMaLop1.Text != "")
                MaLop = txtMaLop1.Text;
            string MaLoaiLop = null;
            if (cbbMaLoaiLop1.SelectedValue != null)
            {
                MaLoaiLop = cbbMaLoaiLop1.SelectedValue.ToString();
            }
            string MaPT = null;
            if (cbbMaPT1.SelectedValue != null)
            {
                MaPT = cbbMaPT1.SelectedValue.ToString();
            }
            string MaTV = null;
            if (cbbMaTV1.SelectedValue != null)
            {
                MaTV = cbbMaTV1.SelectedValue.ToString();
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
            string GhiChu = null;
            if (txtGhiChu1.Text != "")
                GhiChu = txtGhiChu1.Text;
            int? ChiPhi = null;
            if (txtCP1.Text != "")
            {
                try { ChiPhi = Convert.ToInt32(txtCP1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Chi phí phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string errorMessage;
            DataSet dsGiaoDich = dbLop.TimKiemLop(MaLop,MaLoaiLop,MaPT,MaTV,NgayBD,NgayKT,GhiChu
                ,ChiPhi, out errorMessage);
            if (dsGiaoDich != null && dsGiaoDich.Tables.Count > 0)
            {
                dgvTimKiemLop.DataSource = dsGiaoDich.Tables[0];
                dgvTimKiemLop.AutoResizeColumns();
            }
            
           
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {
                dtTimKiemLop = dsGiaoDich.Tables[0];
                dgvTimKiemLop.DataSource = dtTimKiemLop;                             
                txtMaLop.ResetText();
                cbbMaLoaiLop1.SelectedValue = "";
                cbbMaPT1.SelectedValue = "";
                cbbMaTV1.SelectedValue = "";
                txtGhiChu1.ResetText();
                txtCP1.ResetText();

            }
           

        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaLoaiLop.Text = "";
            txtTenLoai.Text = "";

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnSave1.Enabled = true;
            btnCancel1.Enabled = true;
            panel2.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnAdd1.Enabled = false;
            btnChange1.Enabled = false;
            btnDelete1.Enabled = false;
            btnExit1.Enabled = false;
            txtMaLoaiLop.Focus();
        }

        private void btnChange1_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel2.Enabled = true;
            dgvLoaiLop_CellContentClick(null, null);
            this.btnSave1.Enabled = true;
            this.btnCancel1.Enabled = true;
            this.panel2.Enabled = true;
            this.btnAdd1.Enabled = false;
            this.btnChange1.Enabled = false;
            this.btnDelete1.Enabled = false;
            this.btnExit1.Enabled = false;
            txtMaLoaiLop.Focus();
        }

        private void dgvLoaiLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiLop.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thứ tự dòng hiện hành            
            // Thứ tự dòng hiện hành 
            int r = dgvLoaiLop.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaLoaiLop.Text =
            dgvLoaiLop.Rows[r].Cells[0].Value.ToString();
            this.txtTenLoai.Text =
            dgvLoaiLop.Rows[r].Cells[1].Value.ToString();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvLoaiLop.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaLoai =
                dgvLoaiLop.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbLoaiLop.XoaLoaiLop(ref err, txtMaLoaiLop.Text);
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

        private void btnSave1_Click(object sender, EventArgs e)
        {
            bool f = false;
            if (Them)
            {
                string err = "";
                try
                {

                    f = dbLoaiLop.ThemLoaiLop(ref err, txtMaLoaiLop.Text, txtTenLoai.Text);
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
            else // Sửa MAY
            {
                string err = "";
                try
                {
                    f = dbLoaiLop.CapNhatLoaiLop(ref err, txtMaLoaiLop.Text, txtTenLoai.Text);
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
            // Xóa trống các đối tượng trong Panel
            this.txtMaLoaiLop.ResetText();
            this.txtTenLoai.ResetText();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd1.Enabled = true;
            this.btnChange1.Enabled = true;
            this.btnDelete1.Enabled = true;
            this.btnExit1.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave1.Enabled = false;
            this.btnCancel1.Enabled = false;
            this.panel2.Enabled = false;
        }
    }
}
