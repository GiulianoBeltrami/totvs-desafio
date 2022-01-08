using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using totvs_desafio.Models;

namespace totvs_desafio.Database
{
    public class DapperQuery
    {
        private NpgsqlConnection _connection;

        public DapperQuery()
        {
            _connection = new DapperDbConnection().connect();
        }

        public List<User> getAllUsers()
        {
            string userQuery = "Select * from \"Users\";";

            using (_connection)
            {
                _connection.Open();
                var allUsers = _connection.Query<User>(userQuery).ToList();

                foreach (User user in allUsers)
                {
                    string sql = $"Select * from \"Profile\" WHERE \"ID\" = {user.ID};";
                    var userProfile = _connection.Query<Profile>(sql).ToList();

                    user.profile = userProfile;
                }
                return allUsers;
            }
        }

    }
}
