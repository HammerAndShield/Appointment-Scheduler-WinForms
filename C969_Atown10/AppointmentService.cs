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
        private UserService _userService = new UserService();

        public AppointmentService()
        {
            _connectionString = "Server=127.0.0.1;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        private bool IsDuringBusinessHours(DateTime start, DateTime end)
        {
            var startHour = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local).Hour;
            var endHour = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local).Hour;

            Console.WriteLine($"Start Hour: {startHour}, End Hour: {endHour}");

            return startHour >= 9 && startHour < 17 && endHour < 18;
        }

        private bool HasOverlappingAppointments(Appointment newAppointment)
        {
            var appointments = GetAllAppointments().Where(a => a.User.Id == newAppointment.User.Id);// Using a lambda here with the linq "Where" function is the easiest way to build a list 
            //of appointments relating to a single user.  It provides both the fastest way to do it with the least amount of code, justifying the use of the lambda function.

            return appointments.Any(a => // Using a lambda function here with the linq "Any" method is the quickest way to search through the Appointments list.
                (newAppointment.Start >= a.Start && newAppointment.Start < a.End) || // Using a lambda here allows us to quickly iterate through the list without having to write a loop.
                (newAppointment.End > a.Start && newAppointment.End <= a.End)); 
        }

        private bool HasOverlappingAppointments(Appointment newAppointment, int updatingAppointmentId = -1)
        {
            //Overloaded version of the method to be used in updating appointments.
            var appointments = GetAllAppointments()
                .Where(a => a.User.Id == newAppointment.User.Id && a.Id != updatingAppointmentId);

            return appointments.Any(a =>
                (newAppointment.Start >= a.Start && newAppointment.Start < a.End) ||
                (newAppointment.End > a.Start && newAppointment.End <= a.End));
        }

        private bool CustomerExists(Customer customer)
        {
            if (customer == null)
                return false;

            return _customerService.GetCustomer(customer.Id) != null;
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
                        Customer = _customerService.GetCustomer(Convert.ToInt32(reader["customerId"])),
                        User = _userService.GetUser(Convert.ToInt32(reader["userId"])),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Location = reader["location"].ToString(),
                        Contact = reader["contact"].ToString(),
                        Type = reader["type"].ToString(),
                        Url = reader["url"].ToString(),
                        Start = DateTime.SpecifyKind(Convert.ToDateTime(reader["start"]), DateTimeKind.Utc),
                        End = DateTime.SpecifyKind(Convert.ToDateTime(reader["end"]), DateTimeKind.Utc),
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
                        Customer = _customerService.GetCustomer(Convert.ToInt32(reader["customerId"])),
                        User = _userService.GetUser(Convert.ToInt32(reader["userId"])),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Location = reader["location"].ToString(),
                        Contact = reader["contact"].ToString(),
                        Type = reader["type"].ToString(),
                        Url = reader["url"].ToString(),
                        Start = DateTime.SpecifyKind(Convert.ToDateTime(reader["start"]), DateTimeKind.Utc),
                        End = DateTime.SpecifyKind(Convert.ToDateTime(reader["end"]), DateTimeKind.Utc),
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

        public List<Appointment> GetAppointmentsByWeek(DateTime startOfWeek, DateTime endOfWeek)
        {
            return GetAllAppointments()
                .Where(a => a.Start.Date >= startOfWeek && a.Start.Date <= endOfWeek)
                .ToList();
        }

        public List<Appointment> GetAppointmentsByMonth(DateTime startOfMonth, DateTime endOfMonth)
        {
            return GetAllAppointments()
                .Where(a => a.Start.Date >= startOfMonth && a.Start.Date <= endOfMonth)
                .ToList();
        }

        public void AddAppointment(Appointment appointment)
        {
            if (!CustomerExists(appointment.Customer))
                throw new Exception("The customer does not exist.");

            if (!IsDuringBusinessHours(appointment.Start, appointment.End))
                throw new Exception("The appointment is not during business hours.");

            if (HasOverlappingAppointments(appointment))
                throw new Exception("The appointment overlaps with other appointments.");

            string sql = "INSERT INTO Appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
            "VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, @Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdatedBy)";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CustomerId", appointment.Customer.Id);
                command.Parameters.AddWithValue("@UserId", appointment.User.Id);
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
            if (!CustomerExists(appointment.Customer))
                throw new Exception("The customer does not exist.");

            if (!IsDuringBusinessHours(appointment.Start, appointment.End))
                throw new Exception("The appointment is not during business hours.");

            if (HasOverlappingAppointments(appointment, appointment.Id))
                throw new Exception("The appointment overlaps with other appointments.");

            string sql = "UPDATE Appointment SET customerId = @CustomerId, userId = @UserId, title = @Title, description = @Description, location = @Location, " +
            "contact = @Contact, type = @Type, url = @Url, start = @Start, end = @End, createDate = @CreateDate, createdBy = @CreatedBy, lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdatedBy " +
            "WHERE appointmentId = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", appointment.Id);
                command.Parameters.AddWithValue("@CustomerId", appointment.Customer.Id);
                command.Parameters.AddWithValue("@UserId", appointment.User.Id);
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
