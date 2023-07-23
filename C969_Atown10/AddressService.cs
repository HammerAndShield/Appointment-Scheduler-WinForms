using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class AddressService
    {
        private string _connectionString;

        public AddressService() 
        {
            _connectionString = "Server=127.0.0.01;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection( _connectionString );
        }

        public Address GetAddress(int id)
        {
            Address address = null;
            string sql = "SELECT * FROM Address WHERE addressId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                CityService cityService = new CityService();  

                if (reader.Read())
                {
                    int cityId = Convert.ToInt32(reader["cityId"]);
                    City city = cityService.GetCity(cityId);

                    address = new Address()
                    {
                        Id = Convert.ToInt32(reader["addressId"]),
                        AddressLine1 = reader["address"].ToString(),
                        AddressLine2 = reader["address2"].ToString(),
                        City = city,
                        PostalCode = reader["postalCode"].ToString(),
                        Phone = reader["phone"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                return address;
            }
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();
            string sql = "SELECT * FROM Address";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                CityService cityService = new CityService();

                while (reader.Read())
                {
                    int cityId = Convert.ToInt32(reader["cityId"]);
                    City city = cityService.GetCity(cityId);

                    Address address = new Address()
                    {
                        Id = Convert.ToInt32(reader["addressId"]),
                        AddressLine1 = reader["address"].ToString(),
                        AddressLine2 = reader["address2"].ToString(),
                        City = city,
                        PostalCode = reader["postalCode"].ToString(),
                        Phone = reader["phone"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                    addresses.Add(address);
                }
            }

            return addresses;
        }

        public int AddAddress(Address address)
        {
            string sql = "INSERT INTO Address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@Address1, @Address2, @CityId, @PostalCode, @Phone, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy); SELECT LAST_INSERT_ID();";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Address1", address.AddressLine1);
                command.Parameters.AddWithValue("@Address2", address.AddressLine2);
                command.Parameters.AddWithValue("@CityId", address.City.Id);
                command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                command.Parameters.AddWithValue("@Phone", address.Phone);
                command.Parameters.AddWithValue("@CreateDate", address.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", address.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", address.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", address.LastUpdatedBy);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void UpdateAddress(Address address) 
        {
            string sql = "UPDATE Address SET address = @Address1, address2 = @Address2, cityId = @CityId, postalCode = @PostalCode, phone = @Phone, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE addressId = @Id";

            using (var connection = GetConnection())
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Id", address.Id);
                    command.Parameters.AddWithValue("@Address1", address.AddressLine1);
                    command.Parameters.AddWithValue("@Address2", address.AddressLine2);
                    command.Parameters.AddWithValue("@CityId", address.City.Id);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Phone", address.Phone);
                    command.Parameters.AddWithValue("@CreateDate", address.CreatedDate);
                    command.Parameters.AddWithValue("@CreatedBy", address.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", address.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdatedBy", address.LastUpdatedBy);

                    command.ExecuteNonQuery();
                }
        }

        public void DeleteAddress(int id)
        {
            string sql = "DELETE FROM Address WHERE addressId = @Id";

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
