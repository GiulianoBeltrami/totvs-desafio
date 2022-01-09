using Microsoft.Extensions.Configuration;
using Npgsql;

namespace totvs_desafio.Database
{
    public class DapperDbConnection
    {
        private IConfiguration _configuration;

        public DapperDbConnection()
        {
            _configuration = DbConfiguration.Configuration;
        }

        public NpgsqlConnection connect()
        {
            var connection = new NpgsqlConnection(getConnectionString());
            return connection;
        }

        private string getConnectionString()
        {
            return _configuration.GetConnectionString("postgresql");
        }
    }

}
