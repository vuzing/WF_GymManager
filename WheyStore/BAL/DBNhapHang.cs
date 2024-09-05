using DBL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BAL
{
    public class DBNhapHang
    {
        DALayer db = null;       
        public DBNhapHang()
        {
            db = new DALayer();
        }
        public DataSet LayNhapHang()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHAPHANG", CommandType.Text, null);
        }

        public bool ThemNhapHang(ref string err, string MaNH, string MaNCC, string MaTP, string LoaiTP,string SoLuong,
            string TongTien,string NgayNhap)
        {
            return db.MyExecuteNonQuery("spThemNhapHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNH", MaNH),
                new SqlParameter("@MaNCC", MaNCC),
                new SqlParameter("@MaTP", MaTP),
                new SqlParameter("@MaloaiTP", LoaiTP),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@SoTien", TongTien),
                new SqlParameter("@Thoigian", NgayNhap));
        }
        // DELETE
        public bool XoaNhapHang(ref string err,string MaNH)
        {
            return db.MyExecuteNonQuery("spXoaNhapHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNH", MaNH));
        }

        // UPDATE
        public bool SuaNhapHang(ref string err, string MaNH, string MaNCC, string MaTP, string LoaiTP, string SoLuong, 
            string TongTien, string NgayNhap)
        {
            return db.MyExecuteNonQuery("spSuaNhapHang",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNH", MaNH),
                new SqlParameter("@MaNCC", MaNCC),
                new SqlParameter("@MaTP", MaTP),
                new SqlParameter("@MaloaiTP", LoaiTP),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@SoTien", TongTien),
                new SqlParameter("@Thoigian", NgayNhap));
        }

        public DataSet TimKiemNhapHang(string MaNH, string MaNCC, string MaTP, string LoaiTP, int? SoLuong,
            int? TongTien, DateTime? NgayNhap, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemNhapHang(@MaNH, @MaNCC, @MaTP,@MaloaiTP,@SoLuong,@SoTien,@Thoigian)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaNH", (object)MaNH ?? DBNull.Value),
                    new SqlParameter("@MaNCC", (object)MaNCC ?? DBNull.Value),
                    new SqlParameter("@MaTP", (object)MaTP ?? DBNull.Value),
                    new SqlParameter("@MaloaiTP", (object)LoaiTP ?? DBNull.Value),
                    new SqlParameter("@SoLuong", (object)SoLuong ?? DBNull.Value),
                    new SqlParameter("@SoTien", (object)TongTien ?? DBNull.Value),
                    new SqlParameter("@Thoigian", (object)NgayNhap ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
