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
    public class DBLoaiTPBS
    {
        DALayer db = null;
        public DBLoaiTPBS() 
        { 
            db = new DALayer();
        }
        public DataSet LayLoaiTPBS()
        {
            return db.ExecuteQueryDataSet("select * from LOAITPBS", CommandType.Text, null);
        }
        public bool ThemLoaiTPBS(ref string err, string MaLoai, string TenLoaiDichVu)
        {
            return db.MyExecuteNonQuery("spThemLoaiTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tenloai", TenLoaiDichVu));


        }
        // DELETE
        public bool XoaLoaiTPBS(ref string err, string MaLoai)
        {
            return db.MyExecuteNonQuery("spXoaLoaiTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Ma_LOAI", MaLoai));
        }
        // UPDATE
        public bool CapNhatLoaiTPBS(ref string err, string MaLoai, string TenLoaiDichVu)
        {
            return db.MyExecuteNonQuery("spSuaLoaiTPBS",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tenloai", TenLoaiDichVu));
        }

    }
}
