using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;

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
                    using (OracleConnection oracleConn = new OracleConnection(conn))
                    {
                        using (OracleCommand cmd = new OracleCommand(sql, oracleConn))
                        {
                            //cmd.BindByName = true;
                            //cmd.Parameters.Add(":OrgId", OracleDbType.Varchar2).Value = orgId;
                            //cmd.Parameters.Add(":SDate", OracleDbType.Varchar2).Value = sDate;
                            //cmd.Parameters.Add(":EDate", OracleDbType.Varchar2).Value = eDate;

                            try
                            {
                                oracleConn.Open();
                                table.Load(cmd.ExecuteReader());

                                return table;
                            }
                            catch (Exception err)
                            {
                                throw err;
                            }
                        }
                    }
                    break;
            }
            return table;
        }

    }
}
