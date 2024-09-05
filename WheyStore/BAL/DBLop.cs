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
    
    public class DBLop
    {
        DALayer db = null;
        public DBLop() 
        {
            db = new DALayer();
        }
        public DataSet LayLop()
        {
            return db.ExecuteQueryDataSet("select * from LOP", CommandType.Text, null);
        }
        public bool ThemLop(ref string err, string MaLop, string MaLoai, string MaPT,
            string MaTV, string NgayBD, string NgayKT, string GhiChu, string ChiPhi)
        {
            return db.MyExecuteNonQuery("spThemLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Malop", MaLop),
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@Mapt", MaPT),
                new SqlParameter("@Matv", MaTV),
                new SqlParameter("@ngaybatdau", NgayBD),
                new SqlParameter("@ngayketthuc", NgayKT),
                new SqlParameter("@ghichu", GhiChu),
                new SqlParameter("@chiphi", ChiPhi));

        }
        // DELETE
        public bool XoaLop(ref string err, string MaLop)
        {
            return db.MyExecuteNonQuery("spXoaLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Malop", MaLop));
        }
        // UPDATE
        public bool CapNhatLop(ref string err, string MaLop, string MaLoai, string MaPT,
            string MaTV, string NgayBD, string NgayKT, string GhiChu, string ChiPhi)
        {
            return db.MyExecuteNonQuery("spSuaLop",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Malop", MaLop),
                new SqlParameter("@Maloai", MaLoai),
                new SqlParameter("@Mapt", MaPT),
                new SqlParameter("@Matv", MaTV),
                new SqlParameter("@ngaybatdau", NgayBD),
                new SqlParameter("@ngayketthuc", NgayKT),
                new SqlParameter("@ghichu", GhiChu),
                new SqlParameter("@chiphi", ChiPhi));
        }
        public DataSet TimKiemLop(string MaLop, string MaLoai, string MaPT,
            string MaTV, DateTime? NgayBD, DateTime? NgayKT, string GhiChu, int? ChiPhi, out string err)
        {
            err = null;
            string sqlString = "SELECT * FROM dbo.TimKiemLop(@Malop, @Maloai, @Mapt,@Matv,@NgayBD,@NgayKT,@ghichu,@chiphi)";
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@Malop", (Object)MaLop ?? DBNull.Value),
                    new SqlParameter("@Maloai", (Object)MaLoai ?? DBNull.Value),
                    new SqlParameter("@Mapt", (Object)MaPT ?? DBNull.Value),
                    new SqlParameter("@Matv", (Object)MaTV ?? DBNull.Value),
                    new SqlParameter("@NgayBD", (Object)NgayBD ?? DBNull.Value),
                    new SqlParameter("@NgayKT", (Object)NgayKT ?? DBNull.Value),
                    new SqlParameter("@ghichu", (Object)GhiChu ?? DBNull.Value),
                    new SqlParameter("@chiphi", (Object)ChiPhi ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                err = ex.Message;
                return null;
            }
        }
    }
}
