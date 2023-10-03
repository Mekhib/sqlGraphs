using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using chartsDemo.SqlConn;

namespace ConnectOracleWithoutClient
{
    static class ConnectionTet
    {

        static void Test()
        {

            OracleConnection conn = DBUtils.GetDBConnection();

            Console.WriteLine("Get Connection: " + conn);
            try
            {
                conn.Open();

                Console.WriteLine(conn.ConnectionString, "Successful Connection");
            }
            catch (Exception ex)
            {
                Console.WriteLine("## ERROR: " + ex.Message);
                Console.Read();
                return;
            }

            Console.WriteLine("Connection successful!");

            Console.Read();
        }
    }
}
