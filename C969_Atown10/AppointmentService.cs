using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Atown10
{
    public class AppointmentService
    {
        private string _connectionString;

        public AppointmentService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public Appointment GetAppointment(int id)
        {
            Appointment appointment = null;
            string sql = "SELECT * FROM Appointment WHERE appointmentId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    appointment = new Appointment()
                    {
                        Id = Convert.ToInt32(reader["appointmentId"]),
                        CustomerId = Convert.ToInt32(reader["customerId"]),
                        UserId = Convert.ToInt32(reader["userId"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Location = reader["location"].ToString(),
                        Contact = reader["contact"].ToString(),
                        Type = reader["type"].ToString(),
                        Url = reader["url"].ToString(),
                        Start = Convert.ToDateTime(reader["start"]),
                        End = Convert.ToDateTime(reader["end"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };
                }

                return appointment;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            string sql = "SELECT * FROM Appointment";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appointment = new Appointment()
                    {
                        Id = Convert.ToInt32(reader["appointmentId"]),
                        CustomerId = Convert.ToInt32(reader["customerId"]),
                        UserId = Convert.ToInt32(reader["userId"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Location = reader["location"].ToString(),
                        Contact = reader["contact"].ToString(),
                        Type = reader["type"].ToString(),
                        Url = reader["url"].ToString(),
                        Start = Convert.ToDateTime(reader["start"]),
                        End = Convert.ToDateTime(reader["end"]),
                        CreatedDate = Convert.ToDateTime(reader["createDate"]),
                        CreatedBy = reader["createdBy"].ToString(),
                        LastUpdate = Convert.ToDateTime(reader["lastUpdate"]),
                        LastUpdatedBy = reader["lastUpdateBy"].ToString()
                    };

                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            string sql = "INSERT INTO Appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
                command.Parameters.AddWithValue("@UserId", appointment.UserId);
                command.Parameters.AddWithValue("@Title", appointment.Title);
                command.Parameters.AddWithValue("@Description", appointment.Description);
                command.Parameters.AddWithValue("@Location", appointment.Location);
                command.Parameters.AddWithValue("@Contact", appointment.Contact);
                command.Parameters.AddWithValue("@Type", appointment.Type);
                command.Parameters.AddWithValue("@Url", appointment.Url);
                command.Parameters.AddWithValue("@Start", appointment.Start);
                command.Parameters.AddWithValue("@End", appointment.End);
                command.Parameters.AddWithValue("@CreateDate", appointment.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", appointment.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", appointment.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", appointment.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            string sql = "UPDATE Appointment SET customerId = @CustomerId, userId = @UserId, title = @Title, description = @Description, location = @Location, " +
            "contact = @Contact, type = @Type, url = @Url, start = @Start, end = @End, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy " +
            "WHERE appointmentId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", appointment.Id);
                command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
                command.Parameters.AddWithValue("@UserId", appointment.UserId);
                command.Parameters.AddWithValue("@Title", appointment.Title);
                command.Parameters.AddWithValue("@Description", appointment.Description);
                command.Parameters.AddWithValue("@Location", appointment.Location);
                command.Parameters.AddWithValue("@Contact", appointment.Contact);
                command.Parameters.AddWithValue("@Type", appointment.Type);
                command.Parameters.AddWithValue("@Url", appointment.Url);
                command.Parameters.AddWithValue("@Start", appointment.Start);
                command.Parameters.AddWithValue("@End", appointment.End);
                command.Parameters.AddWithValue("@CreateDate", appointment.CreatedDate);
                command.Parameters.AddWithValue("@CreatedBy", appointment.CreatedBy);
                command.Parameters.AddWithValue("@LastUpdate", appointment.LastUpdate);
                command.Parameters.AddWithValue("@LastUpdatedBy", appointment.LastUpdatedBy);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAppointment(int id)
        {
            string sql = "DELETE FROM Appointment WHERE appointmentId = @Id";

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
