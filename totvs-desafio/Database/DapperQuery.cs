using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using totvs_desafio.Models;

namespace totvs_desafio.Database
{
    public static class DapperQuery
    {

        public static List<User> getAllUsers()
        {
            string getUsersQuery = $"SELECT * FROM \"Users\";";

            using (var connection = new DapperDbConnection().connect())
            {
                connection.Open();
                var allUsers = connection.Query<User>(getUsersQuery).ToList();

                foreach (User user in allUsers)
                {
                    populateUserProfile(user, connection);
                }
                return allUsers;
            }
        }


        public static User getUserByEmail(string email)
        {
            string findUserQuery = $"SELECT * FROM \"Users\" WHERE \"email\"='{email}'";

            using (var connection = new DapperDbConnection().connect())
            {
                connection.Open();
                var user = connection.QueryFirstOrDefault<User>(findUserQuery);

                if (!isUserNull(user))
                {
                    populateUserProfile(user, connection);
                }

                return user;
            }
        }


        public static void updateLastLogin(string email)
        {

            string updateQuery = $"UPDATE \"Users\" SET \"LastAccessed\" = '{DateTime.Now}' WHERE \"email\"='{email}'";

            using (var connection = new DapperDbConnection().connect())
            {
                connection.Open();
                connection.Query(updateQuery);
            }

        }


        private static void populateUserProfile(User user, NpgsqlConnection connection)
        {
            string profileQuery = $"SELECT p.\"ID\", p.profession, p.interests FROM \"Profiles\" p JOIN \"ProfileUser\" x ON p.\"ID\" = x.\"profileID\" JOIN \"Users\" t ON x.\"UserID\" = t.\"ID\" WHERE t.\"ID\" = '{user.ID}';";

            var userProfile = connection.Query<Profile>(profileQuery).ToList();

            user.profile = userProfile;
        }


        private static bool isUserNull(User user)
        {
            return user == null;
        }


    }
}
