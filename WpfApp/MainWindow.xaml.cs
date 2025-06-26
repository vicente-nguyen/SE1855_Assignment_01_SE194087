using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerService customerService = new CustomerService();
        EmployeeService employeeService = new EmployeeService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = txtCustomerPhone.Text.Trim();

            // 1) authenticate by phone
            Customers dummy = new Customers { Phone = phone };
            if (!customerService.AuthCustomer(dummy))
            {
                MessageBox.Show("Your phone is not valid!");
                return;
            }

            // 2) fetch the full customer row (to get CustomerID, etc.)
            Customers? customer = customerService
                                  .getAllCustomers()
                                  .FirstOrDefault(c => c.Phone == phone);

            if (customer == null)
            {
                MessageBox.Show("Customer record not found!");
                return;
            }

            // 3) open the customer landing window and pass the object
            CustomerWindow cw = new CustomerWindow(customer);
            cw.Show();
            this.Close();                          // optional: hide login window
        }


        private void AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();
            employees.UserName = txtAdminUsername.Text;
            employees.Password = txtAdminPassword.Password;
            bool result = employeeService.AuthEmployee(employees);
            if (result)
            {
                AdminWindow aw = new();
                aw.Show();
            }
            else
            {
                MessageBox.Show("Your username or password is not valid!");
            }
        }
    }
}