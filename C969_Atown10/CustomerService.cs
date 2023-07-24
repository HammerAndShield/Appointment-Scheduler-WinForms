using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class CustomerService
    {
        private string _connectionString;

        public CustomerService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection( _connectionString );
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            string sql = @"SELECT Customer.*, Address.*, City.*, Country.* FROM Customer 
                    INNER JOIN Address ON Customer.addressId = Address.addressId 
                    INNER JOIN City ON Address.cityId = City.cityId
                    INNER JOIN Country ON City.countryId = Country.countryId
                    WHERE Customer.customerId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    customer = new Customer()
                    {
                        Id = Convert.ToInt32(reader["customerId"]),
                        CustomerName = reader["customerName"].ToString(),
                        AddressId = Convert.ToInt32(reader["addressId"]),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address = new Address()
                    {
                        Id = Convert.ToInt32(reader["addressId"]),
                        AddressLine1 = reader["address"].ToString(),
                        AddressLine2 = reader["address2"].ToString(),
                        PostalCode = reader["postalCode"].ToString(),
                        Phone = reader["phone"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City.Country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }
                return customer;
            }
        }

        public Customer GetCustomerByName(string name)
        {
            Customer customer = null;
            string sql = @"SELECT Customer.*, Address.*, City.*, Country.* FROM Customer 
                INNER JOIN Address ON Customer.addressId = Address.addressId 
                INNER JOIN City ON Address.cityId = City.cityId
                INNER JOIN Country ON City.countryId = Country.countryId
                WHERE Customer.customerName = @Name";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", name);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer()
                    {
                        Id = Convert.ToInt32(reader["customerId"]),
                        CustomerName = reader["customerName"].ToString(),
                        AddressId = Convert.ToInt32(reader["addressId"]),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address = new Address()
                    {
                        Id = Convert.ToInt32(reader["addressId"]),
                        AddressLine1 = reader["address"].ToString(),
                        AddressLine2 = reader["address2"].ToString(),
                        PostalCode = reader["postalCode"].ToString(),
                        Phone = reader["phone"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City.Country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }
                return customer;
            }
        }


        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = @"SELECT Customer.*, Address.*, City.*, Country.* FROM Customer 
                    INNER JOIN Address ON Customer.addressId = Address.addressId 
                    INNER JOIN City ON Address.cityId = City.cityId
                    INNER JOIN Country ON City.countryId = Country.countryId";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer()
                    {
                        Id = Convert.ToInt32(reader["customerId"]),
                        CustomerName = reader["customerName"].ToString(),
                        AddressId = Convert.ToInt32(reader["addressId"]),
                        Active = Convert.ToBoolean(reader["active"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address = new Address()
                    {
                        Id = Convert.ToInt32(reader["addressId"]),
                        AddressLine1 = reader["address"].ToString(),
                        AddressLine2 = reader["address2"].ToString(),
                        PostalCode = reader["postalCode"].ToString(),
                        Phone = reader["phone"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City = new City()
                    {
                        Id = Convert.ToInt32(reader["cityId"]),
                        CityName = reader["city"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customer.Address.City.Country = new Country()
                    {
                        Id = Convert.ToInt32(reader["countryId"]),
                        CountryName = reader["country"].ToString(),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    customers.Add(customer);
                }
            }

            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            AddressService addressService = new AddressService();
            int addressId = addressService.AddAddress(customer.Address);

            string sql = "INSERT INTO Customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@CustomerName, @AddressId, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@AddressId", addressId);
                command.Parameters.AddWithValue("@Active", customer.Active);
                command.Parameters.AddWithValue("@CreateDate", customer.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", customer.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", customer.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            // Check for the existence of Country and City or create new ones
            CountryService countryService = new CountryService();
            CityService cityService = new CityService();

            Country country = countryService.GetCountryByName(customer.Address.City.Country.CountryName);
            if (country == null)
            {
                country = new Country
                {
                    CountryName = customer.Address.City.Country.CountryName,
                    CreatedDate = DateTime.Now,
                    CreatedBy = customer.CreatedBy,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = customer.LastUpdatedBy
                };
                country.Id = countryService.AddCountry(country);
            }

            City city = cityService.GetCityByName(customer.Address.City.CityName);
            if (city == null)
            {
                city = new City
                {
                    CityName = customer.Address.City.CityName,
                    Country = country,
                    CreatedDate = DateTime.Now,
                    CreatedBy = customer.CreatedBy,
                    LastUpdate = DateTime.Now,
                    LastUpdatedBy = customer.LastUpdatedBy
                };
                city.Id = cityService.AddCity(city);
            }

            // Assign updated country and city to the address
            customer.Address.City.Country = country;
            customer.Address.City = city;

            AddressService addressService = new AddressService();
            addressService.UpdateAddress(customer.Address);

            // Update the customer
            string sql = "UPDATE Customer SET customerName = @CustomerName, addressId = @AddressId, active = @Active, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE customerId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", customer.Id);
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@AddressId", customer.Address.Id);
                command.Parameters.AddWithValue("@Active", customer.Active);
                command.Parameters.AddWithValue("@CreateDate", customer.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", customer.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", customer.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer customerToDelete = GetCustomer(id);
            AddressService addressService = new AddressService();

            string sql = "DELETE FROM Customer WHERE customerId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }

            addressService.DeleteAddress(customerToDelete.Address.Id);
        }
    }
}
