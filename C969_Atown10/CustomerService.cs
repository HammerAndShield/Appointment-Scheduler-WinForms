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
            string sql = "SELECT * FROM Customer WHERE customerId = @Id";

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
                }

                return customer;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT * FROM Customer";

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

                    customers.Add(customer);
                }
            }

            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            string sql = "INSERT INTO Customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@CustomerName, @AddressId, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@AddressId", customer.AddressId);
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
            string sql = "UPDATE Customer SET customerName = @CustomerName, addressId = @AddressId, active = @Active, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy WHERE customerId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", customer.Id);
                command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                command.Parameters.AddWithValue("@AddressId", customer.AddressId);
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
            string sql = "DELETE FROM Customer WHERE customerId = @Id";

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
