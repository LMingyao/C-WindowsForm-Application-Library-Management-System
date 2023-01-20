using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace FinalProject2021.DAL
{
    public static class UnilityDB
    {
        static DataSet dsFinalProjectDB = new DataSet("FinalProjectDB");
        public static SqlConnection ConnectDB()
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            sqlConn.Open();
            return sqlConn;
        }
        public static DataSet GetDataSet(DataTable t, string tablename)
        {

            if (dsFinalProjectDB.Tables.Contains(tablename))
            {

                dsFinalProjectDB.Tables.Remove(tablename);
                dsFinalProjectDB.Tables.Add(t);
            }
            else
            {
                dsFinalProjectDB.Tables.Add(t);
            }

            return dsFinalProjectDB;
        }

    }
}
