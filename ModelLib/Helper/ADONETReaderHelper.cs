using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


namespace ModelLib.Helper
{
    public class ADONETReaderHelper
    {
        public DataTable ExecuteSQL(string sql, string conn, DBConnType connType)
        {
            DataTable table = new DataTable();

            switch (connType)
            {
                case DBConnType.SQLServer:
                    SqlDataReader reader;

                    using (SqlConnection dbConn = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, dbConn))
                        {
                            try
                            {
                                dbConn.Open();
                                reader = cmd.ExecuteReader();
                                table.Load(reader);
                            }
                            catch (Exception err)
                            {
                                throw err;
                            }
                        }
                    }

                    break;
                case DBConnType.Oracle:

                    break;
            }
            return table;
        }

    }
}
