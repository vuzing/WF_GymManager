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
    public class DBPersonaltrainer
    {
        DALayer db = null;
        public DBPersonaltrainer()
        {
            db = new DALayer();
        }

        public DataSet LayPT()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM PERSONALTRAINER", CommandType.Text, null);
        }
        public bool ThemPT(ref string err, string MaPT,
            string TenPT, string GioiTinh, string SoDT, string Email, string Luong, string HoaHong)
        {
            return db.MyExecuteNonQuery("spThemPT",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPT", MaPT),
                new SqlParameter("@TenPT", TenPT),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Luong", Luong),
                new SqlParameter("@TienHoahong", HoaHong));

        }
        // DELETE
        public bool XoaPT(ref string err,
            string MaPT)
        {
            return db.MyExecuteNonQuery("spXoaPT",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPT", MaPT));
        }
        // UPDATE
        public bool SuaPT(ref string err, string MaPT,
            string TenPT, string GioiTinh, string SoDT, string Email, string Luong, string HoaHong)
        {
            return db.MyExecuteNonQuery("spSuaPT",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaPT", MaPT),
                new SqlParameter("@TenPT", TenPT),
                new SqlParameter("@Gioitinh", GioiTinh),
                new SqlParameter("@SoDT", SoDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@Luong", Luong),
                new SqlParameter("@TienHoahong", HoaHong));

        }
        public DataSet TimPT(string MaPT,
            string TenPT, string GioiTinh, int? SoDT, string Email, int? Luong, int? HoaHong, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemPT(@MaPT, @TenPT,@Gioitinh, @SoDT,@Email,@Luong,@TienHoahong)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaPT", (object)MaPT ?? DBNull.Value),
                    new SqlParameter("@TenPT", (object)TenPT ?? DBNull.Value),
                    new SqlParameter("@Gioitinh", (object)GioiTinh ?? DBNull.Value),
                    new SqlParameter("@SoDT", (object)SoDT ?? DBNull.Value),
                    new SqlParameter("@Email", (object)Email ?? DBNull.Value),
                    new SqlParameter("@Luong", (object)Luong ?? DBNull.Value),
                    new SqlParameter("@TienHoahong", (object)HoaHong ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
