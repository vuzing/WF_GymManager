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
    public class DBThucphambosung
    {
        DALayer db = null;
        public DBThucphambosung()
        {
            db = new DALayer();
        }
        public DataSet LayTPBS()
        {
            return db.ExecuteQueryDataSet("select * from THUCPHAMBOSUNG", CommandType.Text, null);
        }
        public bool ThemTPBS(ref string err, string MaTP, string MaLoai,string TenTP, 
            string KhoiLuong,string HuongVi,string SoLanDung,string GiaTien,string SoLuong)
        {
            return db.MyExecuteNonQuery("spThemTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Matp", MaTP),
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tentp", TenTP),
                new SqlParameter("@khoiluong", KhoiLuong),
                new SqlParameter("@huongvi", HuongVi),
                new SqlParameter("@solandung", SoLanDung),
                new SqlParameter("@giatien", GiaTien),
                new SqlParameter("@soluong", SoLuong));

        }
        // DELETE
        public bool XoaTPBS(ref string err, string MaLoai)
        {
            return db.MyExecuteNonQuery("spXoaTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Matp", MaLoai));
        }
        // UPDATE
        public bool CapNhatTPBS(ref string err, string MaTP, string MaLoai, string TenTP,
            string KhoiLuong, string HuongVi, string SoLanDung, string GiaTien, string SoLuong)
        {
            return db.MyExecuteNonQuery("spSuaTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Matp", MaTP),
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tentp", TenTP),
                new SqlParameter("@khoiluong", KhoiLuong),
                new SqlParameter("@huongvi", HuongVi),
                new SqlParameter("@solandung", SoLanDung),
                new SqlParameter("@giatien", GiaTien),
                new SqlParameter("@soluong", SoLuong));
        }
        public DataSet TimKiemTPBS(string MaTP, string MaLoai, string TenTP,
            float? KhoiLuong, string HuongVi, int? SoLanDung, int? GiaTien, int? SoLuong, out string err)
        {
            err = null;
            string sqlString = "SELECT * FROM dbo.TimKiemTPBS(@Matp, @Maloai, @tentp, @khoiluong,@huongvi, @solandung,@giatien,@soluong)";
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,                
                    new SqlParameter("@Matp", (Object)MaTP ?? DBNull.Value),
                    new SqlParameter("@Maloai", (Object)MaLoai ?? DBNull.Value),
                    new SqlParameter("@tentp", (Object)TenTP ?? DBNull.Value),
                    new SqlParameter("@khoiluong", (Object)KhoiLuong ?? DBNull.Value),
                    new SqlParameter("@huongvi", (Object)HuongVi ?? DBNull.Value),
                    new SqlParameter("@solandung", (Object)SoLanDung ?? DBNull.Value),
                    new SqlParameter("@giatien", (Object)GiaTien ?? DBNull.Value),
                    new SqlParameter("@soluong", (Object)SoLuong ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                err = ex.Message;
                return null;
            }
        }

    }
}
