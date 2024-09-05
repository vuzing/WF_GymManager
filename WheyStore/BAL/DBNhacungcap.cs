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
    public class DBNhacungcap
    {
        DALayer db = null;
        public DBNhacungcap() 
        {
            db = new DALayer();
        }
        public DataSet LayNCC()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM NHACUNGCAP", CommandType.Text, null);
        }
        public bool ThemNCC(ref string err, string MaNCC,
            string TenNCC, string DiaChi, string Email, string SoDT)
        {
            return db.MyExecuteNonQuery("spThemNCC",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNCC", MaNCC),
                new SqlParameter("@TenNCC", TenNCC),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@Email", Email),               
                new SqlParameter("@SoDT", SoDT));

        }
        // DELETE
        public bool XoaNCC(ref string err,
            string MaNCC)
        {
            return db.MyExecuteNonQuery("spXoaNCC",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNCC", MaNCC));
        }
        // UPDATE
        public bool SuaNCC(ref string err, string MaNCC,
            string TenNCC, string DiaChi, string Email, string SoDT)
        {
            return db.MyExecuteNonQuery("spSuaNCC",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNCC", MaNCC),
                new SqlParameter("@TenNCC", TenNCC),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@Email", Email),
                new SqlParameter("@SoDT", SoDT));
        }
        public DataSet TimKiemNCC(string MaNCC,string TenNCC, string DiaChi,
            string Email, int? SoDT, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemNCC(@MaNCC, @TenNCC,@DiaChi,@Email, @SoDT)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaNCC", (object)MaNCC ?? DBNull.Value),
                    new SqlParameter("@TenNCC", (object)TenNCC ?? DBNull.Value),
                    new SqlParameter("@DiaChi", (object)DiaChi ?? DBNull.Value),
                    new SqlParameter("@Email", (object)Email ?? DBNull.Value),
                    new SqlParameter("@SoDT", (object)SoDT ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
