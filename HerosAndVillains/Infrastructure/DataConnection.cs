using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HerosAndVillains.Infrastructure
{
    public static class DataConnection
    {
        public static IDbConnection CatalystDBConnection(IConfiguration configuration)
        {
            IDbConnection dbConn = new SqlConnection(configuration.GetConnectionString("CatalystExpressDB"));

            return dbConn;
        }
    }

}