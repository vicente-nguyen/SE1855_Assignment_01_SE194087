using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects;
using Services;

namespace WpfApp
{
    public partial class CustomerProfileWindow : Window
    {
        private readonly CustomerService customerService = new();
        private Customers _loggedInCustomer;

        public CustomerProfileWindow(Customers customer)
        {
            InitializeComponent();
            _loggedInCustomer = customer;
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            // refresh from DB to reflect new changes
            _loggedInCustomer = customerService.GetCustomerById(_loggedInCustomer.CustomerID);

            lvCustomers.ItemsSource = new List<Customers> { _loggedInCustomer };
            lvCustomers.SelectedIndex = 0; // auto-select
        }

        private void lvCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomers.SelectedItem is not Customers c) return;

            txtCustomerID.Text = c.CustomerID.ToString();
            txtCompanyName.Text = c.CompanyName;
            txtContactName.Text = c.ContactName;
            txtContactTitle.Text = c.ContactTitle;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.Phone;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtCustomerID.Text, out int id))
            {
                MessageBox.Show("No customer selected.", "Save", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Customers updated = new()
            {
                CustomerID = id,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };

            bool result = customerService.UpdateCustomer(updated);

            MessageBox.Show(result ? "Profile updated." : "Update failed.",
                "Save", MessageBoxButton.OK,
                result ? MessageBoxImage.Information : MessageBoxImage.Error);

            if (result)
            {
                LoadCustomer(); // refresh data after update
            }
        }
    }
}
