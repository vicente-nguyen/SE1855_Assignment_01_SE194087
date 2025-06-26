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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly Customers _customer;
        public CustomerWindow(Customers customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void BtnOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrderHistory coh = new CustomerOrderHistory(_customer.CustomerID);
            coh.Show();
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            CustomerProfileWindow cpw = new CustomerProfileWindow(_customer);
            cpw.Show();
        }
    }
}
