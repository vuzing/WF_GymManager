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
    public class DBHoaDon
    {
        DALayer db = null;
        public DBHoaDon()
        {
            db = new DALayer();
        }

        public DataSet LayHoaDon()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM HOADONTHANHTOAN", CommandType.Text, null);
        }

        public bool ThemHoaDon(ref string err, string MaHD, string MaNV, string MaTP, string MaLoaiTP,
            string MaKH, string SoLuong, string SoTien, string GhiChu, string ThoiGianThanhToan)
        {
            return db.MyExecuteNonQuery("spThemHoaDon",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHD", MaHD),
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaTP", MaTP),
                new SqlParameter("@MaloaiTP", MaLoaiTP),
                new SqlParameter("@MaKH", MaKH),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@SoTien", SoTien),
                new SqlParameter("@GhiChu", GhiChu),
                new SqlParameter("@ThoiGian", ThoiGianThanhToan));
        }
        // DELETE
        public bool XoaHoaDon(ref string err,
            string MaHD)
        {
            return db.MyExecuteNonQuery("spXoaHoaDon",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHD", MaHD));
        }

        // UPDATE
        public bool SuaHoaDon(ref string err, string MaHD, string MaNV, string MaTP, string MaLoaiTP,
            string MaKH, string SoLuong, string SoTien, string GhiChu, string ThoiGianThanhToan)
        {
            return db.MyExecuteNonQuery("spSuaHoaDon",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHD", MaHD),
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaTP", MaTP),
                new SqlParameter("@MaloaiTP", MaLoaiTP),
                new SqlParameter("@MaKH", MaKH),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@SoTien", SoTien),
                new SqlParameter("@GhiChu", GhiChu),
                new SqlParameter("@ThoiGian", ThoiGianThanhToan));
        }

        public DataSet TimKiemHoaDon(string MaHD, string MaNV, string MaTP, string MaLoaiTP,
            string MaKH, int? SoLuong, int? SoTien, string GhiChu, DateTime? ThoiGianThanhToan, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemHoaDon(@MaHD,@MaNV,@MaTP,@MaLoaiTP,@MaKH,@SoLuong,@SoTien,@GhiChu,@Thoigian)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaHD", (object)MaHD ?? DBNull.Value),
                    new SqlParameter("@MaNV", (object)MaNV ?? DBNull.Value),
                    new SqlParameter("@MaTP", (object)MaTP ?? DBNull.Value),
                    new SqlParameter("@MaLoaiTP", (object)MaLoaiTP ?? DBNull.Value),
                    new SqlParameter("@MaKH", (object)MaKH ?? DBNull.Value),
                    new SqlParameter("@SoLuong", (object)SoLuong ?? DBNull.Value),
                    new SqlParameter("@SoTien", (object)SoTien ?? DBNull.Value),
                    new SqlParameter("@GhiChu", (object)GhiChu ?? DBNull.Value),
                    new SqlParameter("@Thoigian", (object)ThoiGianThanhToan ?? DBNull.Value)
                    );
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }

    }
}
