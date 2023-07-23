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
        private CustomerService _customerService = new CustomerService();

        public AppointmentService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private TimeZoneInfo UserTimeZone => TimeZoneInfo.Local;  //Lambda expression to get the users local timezone and set it to the UserTimeZone variable.
        //It was by far the easiest to do this as a lambda expression instead of a normal method, because it could be done in one line with minimal code.
        //We also do not need to call this method specifically, we just need the information saved in the variable.

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        private bool IsDuringBusinessHours(DateTime start, DateTime end)
        {
            var startHour = TimeZoneInfo.ConvertTimeFromUtc(start, UserTimeZone).Hour;
            var endHour = TimeZoneInfo.ConvertTimeFromUtc(end, UserTimeZone).Hour;
            return startHour >= 9 && endHour <= 17;
        }

        private bool HasOverlappingAppointments(Appointment newAppointment)
        {
            var appointments = GetAllAppointments().Where(a => a.UserId == newAppointment.UserId);
            return appointments.Any(a => // Using a lambda function here with the linq "Any" method is the quickest way to search through the Appointments list.
                (newAppointment.Start >= a.Start && newAppointment.Start < a.End) || // Using a lambda here allows us to quickly iterate through the list without having to write a loop.
                (newAppointment.End > a.Start && newAppointment.End <= a.End)); 
        }

        private bool CustomerExists(int customerId)
        {
            return _customerService.GetCustomer(customerId) != null;
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

                appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, UserTimeZone);
                appointment.End = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, UserTimeZone);

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

                    appointment.Start = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, UserTimeZone);
                    appointment.End = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, UserTimeZone);

                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            if (!CustomerExists(appointment.CustomerId))
                throw new Exception("The customer does not exist.");

            if (!IsDuringBusinessHours(appointment.Start, appointment.End))
                throw new Exception("The appointment is not during business hours.");

            if (HasOverlappingAppointments(appointment))
                throw new Exception("The appointment overlaps with other appointments.");

            appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start, UserTimeZone);
            appointment.End = TimeZoneInfo.ConvertTimeToUtc(appointment.End, UserTimeZone);

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
            if (!CustomerExists(appointment.CustomerId))
                throw new Exception("The customer does not exist.");

            if (!IsDuringBusinessHours(appointment.Start, appointment.End))
                throw new Exception("The appointment is not during business hours.");

            if (HasOverlappingAppointments(appointment))
                throw new Exception("The appointment overlaps with other appointments.");

            appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start, UserTimeZone);
            appointment.End = TimeZoneInfo.ConvertTimeToUtc(appointment.End, UserTimeZone);

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
