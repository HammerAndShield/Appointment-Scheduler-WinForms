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

        public void AddCountry(Country country)
        {
            string sql = "INSERT INTO Country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@CountryName, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CountryName", country.CountryName);
                command.Parameters.AddWithValue("@CreateDate", country.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", country.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", country.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", country.LastUpdatedBy);

                command.ExecuteNonQuery();
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
