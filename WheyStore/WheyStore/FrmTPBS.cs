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
using DBL;
using BAL;

namespace WheyStore
{
    public partial class FrmTPBS : Form
    {
        DataTable dtTPBS = null;
        DataTable dtLOAITPBS = null;
        bool Them;
        DBThucphambosung dbtpbs;
        DBLoaiTPBS dbLoaiTPBS;
        public FrmTPBS()
        {
            InitializeComponent();
            dbtpbs  = new DBThucphambosung();
            dbLoaiTPBS = new DBLoaiTPBS();
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

        private void FrmTPBS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gYMCLUBDataSet.THUCPHAMBOSUNG' table. You can move, or remove it, as needed.
            this.tHUCPHAMBOSUNGTableAdapter.Fill(this.gYMCLUBDataSet.THUCPHAMBOSUNG);
            LoadData();
        }
        void LoadData()
        {
            try
            {
                
                dtLOAITPBS = new DataTable();
                dtLOAITPBS.Clear();
                dtLOAITPBS = dbLoaiTPBS.LayLoaiTPBS().Tables[0];
                dgvLoaiTPBS.DataSource = dtLOAITPBS;

                MaLoaiTP.DataSource = dtLOAITPBS;
                MaLoaiTP.DisplayMember = "MaLoaiTP";
                MaLoaiTP.ValueMember = "MaLoaiTP";

                dtTPBS = new DataTable();
                dtTPBS.Clear();
                dtTPBS = dbtpbs.LayTPBS().Tables[0];
                dgvTPBS.DataSource = dtTPBS;

                MaLoaiTP1.DataSource = dtLOAITPBS;
                MaLoaiTP1.DisplayMember = "MaLoaiTP";
                MaLoaiTP1.ValueMember = "MaLoaiTP";

               

                cbbMaLoaiTP1.DataSource = dtLOAITPBS;
                cbbMaLoaiTP1.DisplayMember = "MaLoaiTP";
                cbbMaLoaiTP1.ValueMember = "MaLoaiTP";

                dgvTimKiemTPBS.DataSource = dtTPBS;

                this.txtMaTP1.ResetText();
                this.txtTenTP1.ResetText();
                this.txtKhluong1.ResetText();
                this.txtHuongvi1.ResetText();
                this.txtSLD1.ResetText();
                this.txtGt1.ResetText();
                this.txtSoluong1.ResetText();
                cbbMaLoaiTP1.SelectedItem = null;
                

                this.txtMaTP.ResetText();
                this.txtTenTP.ResetText();
                this.txtKhluong.ResetText();
                this.txtHuongvi.ResetText();
                this.txtSLD.ResetText();
                this.txtGt.ResetText();
                this.txtSoLuong.ResetText();
                //
                this.txtMaLoaiTP.ResetText();
                this.txtTltp.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnSave1.Enabled = false;
                this.btnCancel1.Enabled = false;
                this.panel2.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAdd1.Enabled = true;
                this.btnChange1.Enabled = true;
                this.btnDelete1.Enabled = true;
                this.btnExit1.Enabled = true;
                //
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.panel3.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnAdd.Enabled = true;
                this.btnChange.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnExit.Enabled = true;

                dgvTPBS.AutoResizeColumns();
                dgvTimKiemTPBS.AutoResizeColumns();
                dgvTPBS_CellContentClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong DataBase. Lỗi rồi!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaLoaiTP.Text = "";  
            txtTltp.Text = "";

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnSave1.Enabled = true;
            btnCancel1.Enabled = true;
            panel2.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnAdd1.Enabled = false;
            btnChange1.Enabled = false;
            btnDelete1.Enabled = false;
            btnExit1.Enabled = false;           
            txtMaLoaiTP.Focus();
        }

        private void btnChange1_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel2.Enabled = true;
            dgvLoaiTPBS_CellContentClick(null, null);
            this.btnSave1.Enabled = true;
            this.btnCancel1.Enabled = true;
            this.panel2.Enabled = true;
            this.btnAdd1.Enabled = false;
            this.btnChange1.Enabled = false;
            this.btnDelete1.Enabled = false;
            this.btnExit1.Enabled = false;
            txtMaLoaiTP.Focus();
        }

        private void dgvLoaiTPBS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiTPBS.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thứ tự dòng hiện hành            
            // Thứ tự dòng hiện hành 
            int r = dgvLoaiTPBS.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaLoaiTP.Text =
            dgvLoaiTPBS.Rows[r].Cells[0].Value.ToString();
            this.txtTltp.Text =
            dgvLoaiTPBS.Rows[r].Cells[1].Value.ToString();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvLoaiTPBS.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaLoai =
                dgvLoaiTPBS.Rows[r].Cells[0].Value.ToString();
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
                    bool f = dbLoaiTPBS.XoaLoaiTPBS(ref err, txtMaLoaiTP.Text);
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

                    f = dbLoaiTPBS.ThemLoaiTPBS(ref err, txtMaLoaiTP.Text, txtTltp.Text);
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
                    f = dbLoaiTPBS.CapNhatLoaiTPBS(ref err, txtMaLoaiTP.Text, txtTltp.Text);
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
            this.txtMaLoaiTP.ResetText();
            this.txtTltp.ResetText();

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

        private void btnReload1_Click(object sender, EventArgs e)
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

        private void dgvTPBS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTPBS.CurrentRow == null)
            {
                MessageBox.Show("Dữ liệu trong DataGridView trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            this.cbbMaLoaiTP.DataSource = dtLOAITPBS;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            // Thứ tự dòng hiện hành 
            int r = dgvTPBS.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            this.txtMaTP.Text =
            dgvTPBS.Rows[r].Cells[0].Value.ToString();
            this.cbbMaLoaiTP.SelectedValue =
            dgvTPBS.Rows[r].Cells[1].Value.ToString();
            this.txtTenTP.Text =
            dgvTPBS.Rows[r].Cells[2].Value.ToString();
            this.txtKhluong.Text =
            dgvTPBS.Rows[r].Cells[3].Value.ToString();
            this.txtHuongvi.Text =
            dgvTPBS.Rows[r].Cells[4].Value.ToString();
            this.txtSLD.Text =
            dgvTPBS.Rows[r].Cells[5].Value.ToString();
            this.txtGt.Text =
            dgvTPBS.Rows[r].Cells[6].Value.ToString();
            this.txtSoLuong.Text =
            dgvTPBS.Rows[r].Cells[7].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaTP.Text = "";
            txtMaTP.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            panel3.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnAdd.Enabled = false;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;
            this.cbbMaLoaiTP.DataSource = dtLOAITPBS;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            txtMaTP.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel3.Enabled = true;
            dgvTPBS_CellContentClick(null, null);
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.panel3.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnChange.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExit.Enabled = false;
            this.cbbMaLoaiTP.DataSource = dtLOAITPBS;
            this.cbbMaLoaiTP.DisplayMember = "MaLoaiTP";
            this.cbbMaLoaiTP.ValueMember = "MaLoaiTP";
            txtMaTP.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                // Lấy thứ tự record hiện hành 
                int r = dgvTPBS.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMaTP =dgvTPBS.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa sản phẩm này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = dbtpbs.XoaTPBS(ref err, strMaTP);
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

                    f = dbtpbs.ThemTPBS(ref err, txtMaTP.Text, cbbMaLoaiTP.SelectedValue.ToString(), txtTenTP.Text, txtKhluong.Text,
                        txtHuongvi.Text, txtSLD.Text, txtGt.Text, txtSoLuong.Text);
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
            else // Sửa 
            {
                string err = "";
                try
                {
                    f = dbtpbs.CapNhatTPBS(ref err, txtMaTP.Text, cbbMaLoaiTP.SelectedValue.ToString(), txtTenTP.Text, txtKhluong.Text,
                        txtHuongvi.Text, txtSLD.Text, txtGt.Text, txtSoLuong.Text);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMaTP.ResetText();
            this.txtTenTP.ResetText();
            this.txtKhluong.ResetText();
            this.txtHuongvi.ResetText();
            this.txtSLD.ResetText();
            this.txtGt.ResetText();
            this.txtSoLuong.ResetText();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MaTP = null;
            if (txtMaTP1.Text != "")
                MaTP = txtMaTP1.Text;
            string MaLoaiTP = null;
            if (cbbMaLoaiTP1.SelectedValue != null)
            {
                MaLoaiTP = cbbMaLoaiTP.SelectedValue.ToString();
            }
            string TenTP = null;
            if (txtTenTP1.Text != "")
                TenTP = txtTenTP.Text;
            float? KhoiLuong = null;
            if (txtKhluong1.Text != "")
            {
                try { KhoiLuong = Convert.ToSingle(txtKhluong.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Khối lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string HV = null;
            if (txtHuongvi1.Text != "")
                HV = txtHuongvi1.Text;
            int? SoLanDung = null;
            if (txtSLD1.Text != "")
            {
                try { SoLanDung = Convert.ToInt32(txtSLD1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số lần dùng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }           
            int? GiaTien = null;
            if (txtGt1.Text != "")
            {
                try
                {
                    GiaTien = Convert.ToInt32(txtGt1.Text);
                    Console.WriteLine(GiaTien);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Giá tiền phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int? SoLuong = null;
            if (txtSoluong1.Text != "")
            {
                try { SoLuong = Convert.ToInt32(txtSoluong1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string errorMessage;
            DataSet ds = dbtpbs.TimKiemTPBS(MaTP, MaLoaiTP,
                                TenTP, KhoiLuong,HV,SoLanDung,GiaTien, SoLuong,
                                out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvTimKiemTPBS.DataSource = dt;
                txtMaTP1.ResetText();
                cbbMaLoaiTP1.SelectedValue = "";
                txtTenTP1.ResetText();
                txtKhluong1.ResetText();
                txtHuongvi1.ResetText();
                txtSLD1.ResetText();
                txtGt1.ResetText();
                txtSoluong1.ResetText();

            }
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string MaTP = null;
            if (txtMaTP1.Text != "")
                MaTP = txtMaTP1.Text;
            string MaLoaiTP = null;
            if (cbbMaLoaiTP1.SelectedValue != null)
            {
                MaLoaiTP = cbbMaLoaiTP1.SelectedValue.ToString();
            }
            string TenTP = null;
            if (txtTenTP1.Text != "")
                TenTP = txtTenTP.Text;
            float? KhoiLuong = null;
            if (txtKhluong1.Text != "")
            {
                try { KhoiLuong = Convert.ToSingle(txtKhluong.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Khối lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string HV = null;
            if (txtHuongvi1.Text != "")
                HV = txtHuongvi1.Text;
            int? SoLanDung = null;
            if (txtSLD1.Text != "")
            {
                try { SoLanDung = Convert.ToInt32(txtSLD1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số lần dùng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int? GiaTien = null;
            if (txtGt1.Text != "")
            {
                try
                {
                    GiaTien = Convert.ToInt32(txtGt1.Text);
                    Console.WriteLine(GiaTien);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Giá tiền phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int? SoLuong = null;
            if (txtSoluong1.Text != "")
            {
                try { SoLuong = Convert.ToInt32(txtSoluong1.Text); }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi: Số lượng phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string errorMessage;
            DataSet ds = dbtpbs.TimKiemTPBS(MaTP, MaLoaiTP,
                                TenTP, KhoiLuong, HV, SoLanDung, GiaTien, SoLuong,
                                out errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show("Lỗi: " + errorMessage);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                dgvTimKiemTPBS.DataSource = dt;
                txtMaTP1.ResetText();
                cbbMaLoaiTP1.SelectedValue = "";
                txtTenTP1.ResetText();
                txtKhluong1.ResetText();
                txtHuongvi1.ResetText();
                txtSLD1.ResetText();
                txtGt1.ResetText();
                txtSoluong1.ResetText();

            }
        }
    }
}
