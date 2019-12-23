using System;
using System.Collections.Generic;
using System.Configuration;

namespace ModelLib.Helper
{
    public static class DBConnHelper
    {

        public static string GetSQLConn()
        {
            return ConfigurationManager.ConnectionStrings["ConnContext"].ConnectionString;

        }

    }
}
