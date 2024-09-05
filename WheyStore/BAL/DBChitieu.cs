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
    public class DBChitieu
    {
        DALayer db = null;
        public DBChitieu()
        {
            db = new DALayer();
        }
        public DataSet LayChiTieu()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM CHITIEU", CommandType.Text, null);
        }

        public bool ThemChiTieu(ref string err, string MaCT, string MucDich, string Tien, string ThoiGianChiTra)
        {
            return db.MyExecuteNonQuery("spThemChiTieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCT", MaCT),
                new SqlParameter("@Mucdich", MucDich),
                new SqlParameter("@SoTien", Tien),
                new SqlParameter("@Thoigian", ThoiGianChiTra));
        }
        // DELETE
        public bool XoaChiTieu(ref string err,
            string MaCT)
        {
            return db.MyExecuteNonQuery("spXoaChiTieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCT", MaCT));
        }

        // UPDATE
        public bool SuaChiTieu(ref string err, string MaCT, string MucDich, string Tien, string ThoiGianChiTra)
        {
            return db.MyExecuteNonQuery("spSuaChiTieu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCT", MaCT),
                new SqlParameter("@Mucdich", MucDich),
                new SqlParameter("@SoTien", Tien),
                new SqlParameter("@Thoigian", ThoiGianChiTra));
        }

        public DataSet TimKiemChiTieu(string MaCT, string MucDich, int? Tien, DateTime? ThoiGianChiTra, out string error)
        {
            string sqlString = "SELECT * FROM TimKiemChiTieu(@MaCT, @MucDich, @Tien, @ThoiGianChiTra)";
            error = null;
            try
            {
                return db.ExecuteQueryDataSet(sqlString, CommandType.Text,
                    new SqlParameter("@MaCT", (object)MaCT ?? DBNull.Value),
                    new SqlParameter("@MucDich", (object)MucDich ?? DBNull.Value),
                    new SqlParameter("@Tien", (object)Tien ?? DBNull.Value),
                    new SqlParameter("@ThoiGianChiTra", (object)ThoiGianChiTra ?? DBNull.Value));
            }
            catch (DataException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
