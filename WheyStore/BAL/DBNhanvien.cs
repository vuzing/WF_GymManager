using DBL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class DBNhanvien
    {
        DALayer db = null;
        public DBNhanvien() { 
            db = new DALayer();
        }
        public DataSet LayNV()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHANVIENLETAN", CommandType.Text, null);
        }
        public bool ThemNV(ref string err, string MaNV,
            string TenNV, string GioiTinh, string SoDT, string Email, string Luong)
        {
            return db.MyExecuteNonQuery("spThemNV",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Luong", Luong));

        }
        // DELETE
        public bool XoaNV(ref string err,
            string MaNV)
        {
            return db.MyExecuteNonQuery("spXoaNV",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV));
        }
        // UPDATE
        public bool SuaNV(ref string err, string MaNV,
            string TenNV, string GioiTinh, string SoDT, string Email, string Luong)
        {
            return db.MyExecuteNonQuery("spSuaNV",
                CommandType.StoredProcedure, ref err,
                 new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Luong", Luong));

        }
        public DataSet TimNV(string MaNV,
            string TenNV, string GioiTinh, int? SoDT, string Email, int? Luong, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemNV(@MaNV, @TenNV,@Gioitinh, @SoDT,@Email,@Luong)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaNV", (object)MaNV ?? DBNull.Value),
                    new SqlParameter("@TenNV", (object)TenNV ?? DBNull.Value),
                    new SqlParameter("@Gioitinh", (object)GioiTinh ?? DBNull.Value),
                    new SqlParameter("@SoDT", (object)SoDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)Email ?? DBNull.Value),
                    new SqlParameter("@Luong", (object)Luong ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
