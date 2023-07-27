using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Atown10
{
    public partial class MainForm : Form
    {
        private LoginForm _loginForm;
        private CustomerService _customerService;
        private AddressService _addressService;
        private CityService _cityService;
        private CountryService _countryService;
        private AppointmentService _appointmentService;
        private UserService _userService;
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _customerService = new CustomerService();
            _addressService = new AddressService();
            _cityService = new CityService();
            _countryService = new CountryService();
            _appointmentService = new AppointmentService();
            _userService = new UserService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerListView();
            PopulateAppointmentListView();
            UpdateAppointmentView();
            radioButtonMonthView.Checked = true;
            CheckUpcomingAppointments();
            comboBoxConsultantFilter.Items.AddRange(_appointmentService.GetUniqueConsultantNames().ToArray());
        }

        private void PopulateCustomerListView()
        {
            listViewCustomers.Items.Clear();

            List<Customer> customers = _customerService.GetAllCustomers();

            foreach (Customer customer in customers)
            {
                Address address = customer.Address;
                ListViewItem item = new ListViewItem(customer.Id.ToString());
                item.SubItems.Add(customer.CustomerName);

                if (address != null)
                {
                    item.SubItems.Add(address.AddressLine1);
                    item.SubItems.Add(address.City.CityName);
                    item.SubItems.Add(address.City.Country.CountryName);
                    item.SubItems.Add(address.PostalCode);
                    item.SubItems.Add(address.AddressLine2);
                    item.SubItems.Add(""); 
                    item.SubItems.Add(""); 
                    item.SubItems.Add(""); 
                    item.SubItems.Add(address.Phone);
                }
                else
                {
                    item.SubItems.Add("Address not found");
                    for (int i = 0; i < 7; i++) 
                        item.SubItems.Add("");
                }
                item.SubItems.Add(customer.Active.ToString());

                listViewCustomers.Items.Add(item);
            }
        }

        private void PopulateAppointmentListView()
        {
            listViewAppointments.Items.Clear();

            List<Appointment> appointments = _appointmentService.GetAllAppointments();

            foreach (Appointment appointment in appointments)
            {
                ListViewItem item = new ListViewItem(appointment.Id.ToString());
                item.SubItems.Add(appointment.Customer.CustomerName);
                item.SubItems.Add(appointment.User.UserName); 
                item.SubItems.Add(appointment.Title);
                item.SubItems.Add(appointment.Description);
                item.SubItems.Add(appointment.Location);
                item.SubItems.Add(appointment.Contact);
                item.SubItems.Add(appointment.Type);
                item.SubItems.Add(appointment.Url);
                item.SubItems.Add(TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local).ToString());
                item.SubItems.Add(TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local).ToString());

                listViewAppointments.Items.Add(item);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            _loginForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewCustomers.SelectedItems[0];
                var id = int.Parse(selectedItem.SubItems[0].Text);

                var customer = _customerService.GetCustomer(id);

                textBoxNameCustomer.Text = customer.CustomerName;

                if (customer.Address != null)
                {
                    textBoxAddress1Customer.Text = customer.Address.AddressLine1;
                    textBoxAddress2Customer.Text = customer.Address.AddressLine2;
                    textBoxPhoneNumberCustomer.Text = customer.Address.Phone;
                    textBoxAddress1City.Text = customer.Address.City.CityName;
                    textBoxAddress1Country.Text = customer.Address.City.Country.CountryName;
                    textBoxPostalCode1.Text = customer.Address.PostalCode;
                }
                else
                {
                    textBoxAddress1Customer.Text = "";
                    textBoxAddress2Customer.Text = "";
                    textBoxPhoneNumberCustomer.Text = "";
                    textBoxAddress1City.Text = "";
                    textBoxAddress1Country.Text = "";
                    textBoxPostalCode1.Text = "";
                }

                checkBoxActiveCustomer.Checked = customer.Active;
            }
        }

        private void listViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAppointments.SelectedItems[0];
                var id = int.Parse(selectedItem.SubItems[0].Text);

                var appointment = _appointmentService.GetAppointment(id);

                textBoxCustomerAppointment.Text = appointment.Customer.CustomerName;
                textBoxTitleAppointment.Text = appointment.Title;
                textBoxDescriptionAppointment.Text = appointment.Description;
                textBoxLocationAppointment.Text = appointment.Location;
                textBoxContactAppointment.Text = appointment.Contact;
                textBoxTypeAppointment.Text = appointment.Type;
                textBoxURLAppointment.Text = appointment.Url;
                dateTimePickerStartAppointment.Value = TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local);
                dateTimePickerEndAppointment.Value = TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local);
            }
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            Country newCountry = new Country
            {
                CountryName = textBoxAddress1Country.Text,
                CreatedDate = DateTime.Now,
                CreatedBy = _loginForm.userName,
                LastUpdate = DateTime.Now,
                LastUpdatedBy = _loginForm.userName
            };

            newCountry.Id = _countryService.AddCountry(newCountry);

            City newCity = new City
            {
                CityName = textBoxAddress1City.Text,
                Country = newCountry,
                CreatedDate = DateTime.Now,
                CreatedBy = _loginForm.userName,
                LastUpdate = DateTime.Now,
                LastUpdatedBy = _loginForm.userName
            };

            newCity.Id = _cityService.AddCity(newCity);

            Address newAddress = new Address
            {
                AddressLine1 = textBoxAddress1Customer.Text,
                AddressLine2 = textBoxAddress2Customer.Text,
                Phone = textBoxPhoneNumberCustomer.Text,
                City = newCity,
                PostalCode = textBoxPostalCode1.Text,
                CreatedDate = DateTime.Now,
                CreatedBy = _loginForm.userName,
                LastUpdate = DateTime.Now,
                LastUpdatedBy = _loginForm.userName
            };

            _addressService.AddAddress(newAddress);

            Customer newCustomer = new Customer
            {
                CustomerName = textBoxNameCustomer.Text,
                Address = newAddress,
                Active = checkBoxActiveCustomer.Checked,
                CreatedDate = DateTime.Now,
                CreatedBy = _loginForm.userName,
                LastUpdate = DateTime.Now,
                LastUpdatedBy = _loginForm.userName
            };

            _customerService.AddCustomer(newCustomer);

            PopulateCustomerListView();
        }

        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewCustomers.SelectedItems[0];
                var id = int.Parse(selectedItem.SubItems[0].Text);

                var customer = _customerService.GetCustomer(id);

                customer.CustomerName = textBoxNameCustomer.Text;
                customer.Address.AddressLine1 = textBoxAddress1Customer.Text;
                customer.Address.AddressLine2 = textBoxAddress2Customer.Text;
                customer.Address.Phone = textBoxPhoneNumberCustomer.Text;
                customer.Address.City.CityName = textBoxAddress1City.Text;
                customer.Address.City.Country.CountryName = textBoxAddress1Country.Text;
                customer.Address.PostalCode = textBoxPostalCode1.Text;
                customer.Active = checkBoxActiveCustomer.Checked;

                _customerService.UpdateCustomer(customer);

          
                var updatedCustomer = _customerService.GetCustomer(id);

                if (updatedCustomer.Address.City.CityName != textBoxAddress1City.Text || updatedCustomer.Address.City.Country.CountryName != textBoxAddress1Country.Text)
                {
                    
                    MessageBox.Show("Failed to update city or country. Please try again.");
                }
                else
                {
                    
                    PopulateCustomerListView();
                }
            }
        }

        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewCustomers.SelectedItems[0];
                var id = int.Parse(selectedItem.SubItems[0].Text);

                _customerService.DeleteCustomer(id);

                PopulateCustomerListView();
            }
        }

        private void buttonAddAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _userService.GetUserByName(_loginForm.userName);
                Appointment appointment = new Appointment
                {
                    Customer = _customerService.GetCustomerByName(textBoxCustomerAppointment.Text),
                    User = user,
                    Title = textBoxTitleAppointment.Text,
                    Description = textBoxDescriptionAppointment.Text,
                    Location = textBoxLocationAppointment.Text,
                    Contact = textBoxContactAppointment.Text,
                    Type = textBoxTypeAppointment.Text,
                    Url = textBoxURLAppointment.Text,
                    Start = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerStartAppointment.Value),
                    End = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerEndAppointment.Value),
                    CreatedBy = _loginForm.userName,
                    LastUpdatedBy = _loginForm.userName,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow
                };

                _appointmentService.AddAppointment(appointment);

                PopulateAppointmentListView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonUpdateAppointment_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem selectedItem = listViewAppointments.SelectedItems[0];
                    var id = int.Parse(selectedItem.SubItems[0].Text);

                    Appointment appointment = _appointmentService.GetAppointment(id);

                    User user = _userService.GetUserByName(_loginForm.userName);

                    appointment.Customer = _customerService.GetCustomerByName(textBoxCustomerAppointment.Text);
                    appointment.User = user;
                    appointment.Title = textBoxTitleAppointment.Text;
                    appointment.Description = textBoxDescriptionAppointment.Text;
                    appointment.Location = textBoxLocationAppointment.Text;
                    appointment.Contact = textBoxContactAppointment.Text;
                    appointment.Type = textBoxTypeAppointment.Text;
                    appointment.Url = textBoxURLAppointment.Text;
                    appointment.Start = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerStartAppointment.Value);
                    appointment.End = TimeZoneInfo.ConvertTimeToUtc(dateTimePickerEndAppointment.Value);
                    appointment.LastUpdatedBy = _loginForm.userName;
                    appointment.LastUpdate = DateTime.UtcNow;

                    _appointmentService.UpdateAppointment(appointment);

                    PopulateAppointmentListView();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void buttonDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAppointments.SelectedItems[0];
                var id = int.Parse(selectedItem.SubItems[0].Text);

                _appointmentService.DeleteAppointment(id);

                PopulateAppointmentListView();
            }
        }

        public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(DateTime dt)
        {
            return StartOfWeek(dt, DayOfWeek.Monday).AddDays(6);
        }

        public static DateTime StartOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime EndOfMonth(DateTime dt)
        {
            return StartOfMonth(dt).AddMonths(1).AddDays(-1);
        }

        private void UpdateAppointmentView()
        {
            listViewAppointmentsCalendar.Items.Clear();
            DateTime selectedDate = monthCalendar.SelectionStart;
            List<Appointment> appointments = new List<Appointment>();

            if (radioButtonMonthView.Checked)
            {
                DateTime startOfMonth = StartOfMonth(selectedDate);
                DateTime endOfMonth = EndOfMonth(selectedDate);
                appointments = _appointmentService.GetAppointmentsByMonth(startOfMonth, endOfMonth);
            }
            else if (radioButtonWeekView.Checked)
            {
                DateTime startOfWeek = StartOfWeek(selectedDate, DayOfWeek.Monday);
                DateTime endOfWeek = EndOfWeek(selectedDate);
                appointments = _appointmentService.GetAppointmentsByWeek(startOfWeek, endOfWeek);
            }

            foreach (Appointment appointment in appointments)
            {
                ListViewItem item = new ListViewItem(appointment.Id.ToString());
                item.SubItems.Add(appointment.Customer.CustomerName);
                item.SubItems.Add(appointment.User.UserName);
                item.SubItems.Add(appointment.Title);
                item.SubItems.Add(appointment.Description);
                item.SubItems.Add(appointment.Location);
                item.SubItems.Add(appointment.Contact);
                item.SubItems.Add(appointment.Type);
                item.SubItems.Add(appointment.Url);
                item.SubItems.Add(TimeZoneInfo.ConvertTimeFromUtc(appointment.Start, TimeZoneInfo.Local).ToString());
                item.SubItems.Add(TimeZoneInfo.ConvertTimeFromUtc(appointment.End, TimeZoneInfo.Local).ToString());

                listViewAppointmentsCalendar.Items.Add(item);
            }
        }

        private void radioButtonMonthView_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAppointmentView();
        }

        private void radioButtonWeekView_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAppointmentView();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateAppointmentView();
        }

        private void BindDataToGrid<T>(List<T> data)
        { 
            dataGridViewReport.DataSource = null;
            dataGridViewReport.Rows.Clear();
            dataGridViewReport.Columns.Clear();

            dataGridViewReport.DataSource = data;
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            var reportType = comboBoxReportSelection.SelectedItem.ToString();

            switch (reportType)
            {
                case "Appointment Types by Month":
                    var allAppointmentTypesByMonth = _appointmentService.GetAllAppointmentTypesByMonth();
                    var appointmentList = allAppointmentTypesByMonth.Select(kvp => new
                    {
                        Year = kvp.Key.Split(' ')[0],
                        Month = kvp.Key.Split(' ')[1],
                        Type = kvp.Key.Split(' ')[2],
                        Count = kvp.Value
                    }).ToList();
                    BindDataToGrid(appointmentList);
                    break;

                case "Consultant Schedules":
                    if (comboBoxConsultantFilter.SelectedItem != null)
                    {
                        var consultantName = comboBoxConsultantFilter.SelectedItem.ToString();
                        var consultantSchedules = _appointmentService.GetConsultantSchedules(consultantName);
                        var schedulesList = consultantSchedules.Select((appt, index) => new { Consultant = consultantName, AppointmentDetails = appt }).ToList();
                        BindDataToGrid(schedulesList);
                    }
                    else if (comboBoxConsultantFilter.SelectedItem == null) 
                    {
                        MessageBox.Show("Please select a consultant from the filter.");
                    }
                    break;

                case "Customer Statistics":
                    var customerStatistics = _appointmentService.GetCustomerStatistics();
                    var customerList = customerStatistics.Select(kvp => new
                    {
                        Customer = kvp.Key,
                        AppointmentCount = kvp.Value
                    }).ToList();
                    BindDataToGrid(customerList);
                    break;
            }
        }

        private void CheckUpcomingAppointments()
        {
            var userName = _loginForm.userName; 
            var user = _userService.GetUserByName(userName);
            var appointments = _appointmentService.GetAppointmentsByUserId(user.Id);

            var now = DateTime.UtcNow;
            var upcomingAppointments = appointments.Where(a => a.Start > now && a.Start < now.AddMinutes(15)).ToList();

            if (upcomingAppointments.Any())
            {
                var message = string.Join(Environment.NewLine, upcomingAppointments.Select(a =>
                    $"Title: {a.Title}, Start: {TimeZoneInfo.ConvertTimeFromUtc(a.Start, TimeZoneInfo.Local)}, End: {TimeZoneInfo.ConvertTimeFromUtc(a.End, TimeZoneInfo.Local)}"
                ));

                MessageBox.Show($"You have the following appointments coming up in the next 15 minutes: {Environment.NewLine}{message}");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
