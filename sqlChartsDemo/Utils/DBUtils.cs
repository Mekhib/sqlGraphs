using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace chartsDemo.SqlConn
{
    class DBUtils
    {
        public static OracleConnection GetDBConnection()
        {
            string host = "stcmzborap017l";
            int port = 1521;
            string sid = "2133";
            string user = "BOSDOM2\\L14262";
            string password = "UCW2w8cs_1K6ZQeQ";

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }

}