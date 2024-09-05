using DBL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BAL
{
    public class DBThanhvien
    {
        DALayer db = null;
        public DBThanhvien() 
        {
            db = new DALayer();
        }
        public DataSet LayThanhVien()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM THANHVIEN", CommandType.Text, null);
        }
        public bool ThemThanhVien(ref string err, string MaTV,
            string TenTV, string GioiTinh, string SoDT, string Email, string NgayBD,string NgayKT)
        {
            return db.MyExecuteNonQuery("spThemThanhVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTV", MaTV),
                new SqlParameter("@TenTV", TenTV),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NgayBD", NgayBD),
                new SqlParameter("@NgayKT", NgayKT));

        }
        // DELETE
        public bool XoaThanhVien(ref string err,
            string MaTV)
        {
            return db.MyExecuteNonQuery("spXoaThanhVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTV", MaTV));
        }
        // UPDATE
        public bool SuaThanhVien(ref string err, string MaTV,
            string TenTV, string GioiTinh, string SoDT, string Email, string NgayBD, string NgayKT)
        {
            return db.MyExecuteNonQuery("spSuaThanhVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaTV", MaTV),
                new SqlParameter("@TenTV", TenTV),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NgayBD", NgayBD),
                new SqlParameter("@NgayKT", NgayKT));
        }
        public DataSet TimKiemThanhVien(string MaTV,
            string TenTV, string GioiTinh, int? SoDT, string Email, DateTime? NgayBD, DateTime? NgayKT, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemThanhVien(@MaTV, @TenTV,@Gioitinh, @SoDT,@Email,@NgayBD ,@NgayKT)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaTV", (object)MaTV ?? DBNull.Value),
                    new SqlParameter("@TenTV", (object)TenTV ?? DBNull.Value),
                    new SqlParameter("@Gioitinh", (object)GioiTinh ?? DBNull.Value),
                    new SqlParameter("@SoDT", (object)SoDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)Email ?? DBNull.Value),
                    new SqlParameter("@NgayBD", (object)NgayBD ?? DBNull.Value),
                    new SqlParameter("@NgayKT", (object)NgayKT ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
