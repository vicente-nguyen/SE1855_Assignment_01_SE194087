using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        CustomerService customerService = new CustomerService();
        public CustomerManagementWindow()
        {
            InitializeComponent();
            DisplayCustomer();
        }
        
        private void DisplayCustomer()
        {
            lvCustomer.ItemsSource = customerService.getAllCustomers();
        }

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvCustomer.SelectedItem is not Customers c) return;
            txtCustomerID.Text = c.CustomerID.ToString();
            txtCompanyName.Text = c.CompanyName;
            txtContactName.Text = c.ContactName;
            txtContactTitle.Text = c.ContactTitle;
            txtAddress.Text = c.Address;
            txtPhone.Text = c.Phone;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers
            {
                CustomerID = int.Parse(txtCustomerID.Text),
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bool result = customerService.CreateCustomer(c);
            if (result)
            {
                MessageBox.Show("Customer created successfully.");
                DisplayCustomer();
            }
            else
            {
                MessageBox.Show("Failed to create customer.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customers customer = new Customers
            {
                CustomerID = int.Parse(txtCustomerID.Text),
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bool result = customerService.UpdateCustomer(customer);
            if (result)
            {
                MessageBox.Show("Customer updated successfully.");
                DisplayCustomer();
            }
            else
            {
                MessageBox.Show("Failed to update customer.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(
                "You want to delete this customer?",
                "Yes!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (ret == MessageBoxResult.No)
                return;
            Customers customer = new Customers
            {
                CustomerID = int.Parse(txtCustomerID.Text),
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bool result = customerService.DeleteCustomer(customer);
            if (result)
            {
                MessageBox.Show("Customer deleted successfully.");
                DisplayCustomer();
            }
            else
            {
                MessageBox.Show("Failed to delete customer.");
            }
        }
    }
}
