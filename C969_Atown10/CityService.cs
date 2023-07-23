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
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {                   
                    CountryService countryService = new CountryService();                    
                    Country country = countryService.GetCountry(Convert.ToInt32(reader["countryId"]));

                    city = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        Country = country,
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                return city;
            }
        }

        public City GetCityByName(string cityName)
        {
            City city = null;
            string sql = "SELECT * FROM City WHERE city = @CityName";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CityName", cityName);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryService countryService = new CountryService();
                    Country country = countryService.GetCountry(Convert.ToInt32(reader["countryId"]));

                    city = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        Country = country,
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }
            }

            return city;
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
                    CountryService countryService = new CountryService();
                    Country country = countryService.GetCountry(Convert.ToInt32(reader["countryId"]));

                    City city = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        Country = country,
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

        public int AddCity(City city)
        {
            string sqlCheck = "SELECT cityId FROM City WHERE city = @CityName";
            string sqlInsert = "INSERT INTO City (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy); SELECT LAST_INSERT_ID();";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlCheck, connection);

                command.Parameters.AddWithValue("@CityName", city.CityName);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    // City already exists, return its ID
                    return Convert.ToInt32(result);
                }
                else
                {
                    // City does not exist, insert new city
                    command.CommandText = sqlInsert;
                    command.Parameters.AddWithValue("@CountryId", city.Country.Id);
                    command.Parameters.AddWithValue("@CreateDate", city.CreatedDate);
                    command.Parameters.AddWithValue("@CreatedBy", city.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", city.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdatedBy", city.LastUpdatedBy);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
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
                command.Parameters.AddWithValue("@CountryId", city.Country.Id);
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
