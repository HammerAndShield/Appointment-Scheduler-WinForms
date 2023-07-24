using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class UserService
    {
        private string _connectionString;

        public UserService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public User GetUser(int id)
        {
            User user = null;
            string sql = "SELECT * FROM User WHERE userId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt32(reader["userId"]),
                        UserName = reader["userName"].ToString(),
                        Password = reader["password"].ToString(),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                return user;

            }
        }

        public User GetUserByName(string userName)
        {
            User user = null;
            string sql = "SELECT * FROM User WHERE userName = @UserName";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt32(reader["userId"]),
                        UserName = reader["userName"].ToString(),
                        Password = reader["password"].ToString(),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string sql = "SELECT * FROM User";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User()
                    {
                        Id = Convert.ToInt32(reader["userId"]),
                        UserName = reader["userName"].ToString(),
                        Password = reader["password"].ToString(),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        public void AddUser(User user)
        {
            string sql = "INSERT INTO User (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@UserName, @Password, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Active", user.Active);
                command.Parameters.AddWithValue("@CreateDate", user.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", user.LastUpdatedBy);

                command.ExecuteNonQuery();
            }

        }

        public void UpdateUser(User user) 
        {
            string sql = "UPDATE User SET userName = @UserName, password = @Password, active = @Active, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE userId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Active", user.Active);
                command.Parameters.AddWithValue("@CreateDate", user.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", user.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }   

        public void DeleteUser(int id)
        {
            string sql = "DELETE FROM User WHERE userId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public User Login(string userName, string password)
        {
            User user = null;
            string sql = "SELECT * FROM User WHERE userName = @UserName AND password = @Password";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = Convert.ToInt32(reader["userId"]),
                        UserName = reader["userName"].ToString(),
                        Password = reader["password"].ToString(),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                return user;

            }
        }

        public bool Logout(User user)
        {
            user = null;
            return true;
        }
    }
}
