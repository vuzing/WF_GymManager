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
    public class DBKhachHang
    {
        DALayer db = null;
        public DBKhachHang()
        {
            db = new DALayer();
        }

        public DataSet LayKhachHang()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM KHACHHANG", CommandType.Text, null);
        }
        public bool ThemKhachHang(ref string err,string MaKH,
            string TenKH,string GioiTinh, string SoDT,string Email, string DiaChi)
        {
            return db.MyExecuteNonQuery("spThemKhachHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKH", MaKH),
                new SqlParameter("@TenKH", TenKH),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@DiaChi", DiaChi));

        }
        // DELETE
        public bool XoaKhachHang(ref string err,
            string MaKH)
        {
            return db.MyExecuteNonQuery("spXoaKhachHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKH", MaKH));
        }
        // UPDATE
        public bool SuaKhachHang(ref string err, string MaKH,
            string TenKH, string GioiTinh, string SoDT, string Email, string DiaChi)
        {
            return db.MyExecuteNonQuery("spSuaKhachHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKH", MaKH),
                new SqlParameter("@TenKH", TenKH),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@DiaChi", DiaChi));
        }
        public DataSet TimKiemKhachHang(string MaKH,
            string TenKH, string GioiTinh, int? SoDT, string Email, string DiaChi, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemKhachHang(@MaKH, @TenKH,@Gioitinh, @SoDT,@Email,@DiaChi)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaKH", (object)MaKH ?? DBNull.Value),
                    new SqlParameter("@TenKH", (object)TenKH ?? DBNull.Value),
                    new SqlParameter("@Gioitinh", (object)GioiTinh ?? DBNull.Value),
                    new SqlParameter("@SoDT", (object)SoDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)Email ?? DBNull.Value),
                    new SqlParameter("@DiaChi", (object)DiaChi ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
