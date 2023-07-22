using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class CityService
    {
        private string _connectionString;

        public CityService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection( _connectionString );
        }

        public City GetCity(int id)
        {
            City city = null;
            string sql = "SELECT * FROM City WHERE cityId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand( sql, connection );
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    city = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        CountryId = Convert.ToInt32(reader["countryId"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                return city;
            }
        }

        public List<City> GetAllCities() 
        {
            List<City> cities = new List<City>();
            string sql = "SELECT * FROM City";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City city = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        CountryId = Convert.ToInt32(reader["countryId"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    cities.Add(city);
                }
            }

            return cities;
        }

        public void AddCity (City city)
        {
            string sql = "INSERT INTO City (city, countryId, createDate, createdBy, lasteUpdate, lastUpdateBy) VALUES (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CityName", city.CityName);
                command.Parameters.AddWithValue("@CountryId", city.CountryId);
                command.Parameters.AddWithValue("@CreateDate", city.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", city.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", city.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", city.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCity (City city)
        {
            string sql = "UPDATE City SET city = @CityName, countryId = @CountryId, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE cityId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", city.Id);
                command.Parameters.AddWithValue("@CityName", city.CityName);
                command.Parameters.AddWithValue("@CountryId", city.CountryId);
                command.Parameters.AddWithValue("@CreateDate", city.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", city.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", city.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", city.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCity (int id)
        {
            string sql = "DELETE FROM City WHERE cityId = @Id";

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
