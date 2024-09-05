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
    public class DBLoaiLop
    {
        DALayer db = null;
        public DBLoaiLop( )
        {
            db = new DALayer();
        }
        public DataSet LayLoaiLop()
        {
            return db.ExecuteQueryDataSet("select * from LOAILOP", CommandType.Text, null);
        }
        public bool ThemLoaiLop(ref string err, string MaLoai, string LoaiLop)
        {
            return db.MyExecuteNonQuery("spThemLoaiLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tenloai", LoaiLop));


        }
        // DELETE
        public bool XoaLoaiLop(ref string err, string MaLoai)
        {
            return db.MyExecuteNonQuery("spXoaLoaiLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Ma_LOAI", MaLoai));
        }
        // UPDATE
        public bool CapNhatLoaiLop(ref string err, string MaLoai, string LoaiLop)
        {
            return db.MyExecuteNonQuery("spSuaLoaiLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@tenloai", LoaiLop));
        }
    }
}
