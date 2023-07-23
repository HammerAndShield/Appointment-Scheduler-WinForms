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
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _customerService = new CustomerService();
            _addressService = new AddressService();
            _cityService = new CityService();
            _countryService = new CountryService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerListView();
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

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            Country newCountry = new Country
            {
                CountryName = textBoxAddress1Country.Text,
                CreatedDate = DateTime.Now,
                CreatedBy = _loginForm.userName,
                LastUpdate = DateTime.Now,
                LastUpdatedBy = "CurrentUserName"
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

                // Validate that the city and country have been updated correctly
                var updatedCustomer = _customerService.GetCustomer(id);

                if (updatedCustomer.Address.City.CityName != textBoxAddress1City.Text || updatedCustomer.Address.City.Country.CountryName != textBoxAddress1Country.Text)
                {
                    // Display an error message to the user
                    MessageBox.Show("Failed to update city or country. Please try again.");
                }
                else
                {
                    // Reload the customer list view
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
    }
}
