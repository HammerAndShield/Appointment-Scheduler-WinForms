using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class CountryService
    {
        private string _connectionString;

        public CountryService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection( _connectionString );
        }

        public Country GetCountry(int id)
        {
            Country country = null;
            string sql = "SELECT * FROM Country WHERE countryId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()

                    };
                }

                return country;

            }

        }

        public Country GetCountryByName(string countryName)
        {
            Country country = null;
            string sql = "SELECT * FROM Country WHERE country = @CountryName";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CountryName", countryName);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }
            }

            return country;
        }

        public List<Country> GetAllCountries() 
        {
            List<Country> countries = new List<Country>();
            string sql = "SELECT * FROM Country";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Country country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    countries.Add(country);
                }
            }

            return countries;
        }

        public int AddCountry(Country country)
        {
            string sqlCheck = "SELECT countryId FROM Country WHERE country = @CountryName";
            string sqlInsert = "INSERT INTO Country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@CountryName, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy); SELECT LAST_INSERT_ID();";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlCheck, connection);

                command.Parameters.AddWithValue("@CountryName", country.CountryName);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    // Country already exists, return its ID
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Country does not exist, insert new country
                    command.CommandText = sqlInsert;
                    command.Parameters.AddWithValue("@CreateDate", country.CreatedDate);
                    command.Parameters.AddWithValue("@CreatedBy", country.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", country.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdatedBy", country.LastUpdatedBy);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void UpdateCountry(Country country)
        {
            string sql = "UPDATE Country SET country = @CountryName, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE countryId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand( sql, connection);

                command.Parameters.AddWithValue("@Id", country.Id);
                command.Parameters.AddWithValue("@CountryName", country.CountryName);
                command.Parameters.AddWithValue("@CreateDate", country.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", country.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", country.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", country.LastUpdatedBy);

                command.ExecuteNonQuery();
            }

        }

        public void DeleteCountry(int id)
        {
            string sql = "DELETE FROM Country WHERE countryId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

        }
    }
}
