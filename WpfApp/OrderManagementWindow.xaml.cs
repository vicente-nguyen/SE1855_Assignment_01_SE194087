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
    /// Interaction logic for OrderManagementWindow.xaml
    /// </summary>
    public partial class OrderManagementWindow : Window
    {
        OrderService orderService = new OrderService();
        OrderDetailService orderDetailService = new OrderDetailService();
        public OrderManagementWindow()
        {
            InitializeComponent();
            DisplayOrder();
        }

        private void DisplayOrder()
        {
            lvOrderDetails.ItemsSource = null;
            lvOrders.ItemsSource = orderService.getAllOrders();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            Orders od = new Orders
            {
                OrderID = int.Parse(txtOrderID.Text),
                CustomerID = int.Parse(txtCustomerID.Text),
                EmployeeID = int.Parse(txtEmployeeID.Text),
                OrderDate = DateTime.Parse(dpOrderDate.Text)
            };
            bool result = orderService.CreateOrder(od);
            if (result)
            {
                MessageBox.Show("Order created successfully.");
                DisplayOrder();
            }
            else
            {
                MessageBox.Show("Failed to create order.");
            }
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders
            {
                OrderID = int.Parse(txtOrderID.Text),
                CustomerID = int.Parse(txtCustomerID.Text),
                EmployeeID = int.Parse(txtEmployeeID.Text),
                OrderDate = DateTime.Parse(dpOrderDate.Text)
            };
            bool result = orderService.UpdateOrder(orders);
            if (result)
            {
                MessageBox.Show("Order updated successfully.");
                DisplayOrder();
            }
            else
            {
                MessageBox.Show("Failed to update order.");
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(
                "Are you sure you want to delete this order?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (ret == MessageBoxResult.No) return;
            Orders orders = new Orders
            {
                OrderID = int.Parse(txtOrderID.Text),
                CustomerID = int.Parse(txtCustomerID.Text),
                EmployeeID = int.Parse(txtEmployeeID.Text),
                OrderDate = DateTime.Parse(dpOrderDate.Text)
            };
            bool result = orderService.DeleteOrder(orders);
            if (result)
            {
                MessageBox.Show("Order deleted successfully.");
                DisplayOrder();
            }
            else
            {
                MessageBox.Show("Failed to delete order.");
            }
        }

        private void btnAddDetail_Click(object sender, RoutedEventArgs e)
        {
            OrderDetails odetail = new OrderDetails
            {
                OrderID = int.Parse(txtOrderID.Text),
                ProductID = int.Parse(txtProductID.Text),
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                Discount = double.Parse(txtDiscount.Text)
            };
            bool result = orderDetailService.CreateOrderDetail(odetail);
            if (result)
            {
                MessageBox.Show("Order detail created successfully.");
                lvOrderDetails.ItemsSource = orderDetailService.getAllOrderDetails()
                    .Where(od => od.OrderID == odetail.OrderID).ToList();
            }
            else
            {
                MessageBox.Show("Failed to create order detail.");
            }
        }

        private void lvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOrders.SelectedItem is not Orders od) return;
            txtOrderID.Text = od.OrderID.ToString();
            txtCustomerID.Text = od.CustomerID.ToString();
            txtEmployeeID.Text = od.EmployeeID.ToString();
            dpOrderDate.Text = od.OrderDate.ToString("yyyy-MM-dd");
            lvOrderDetails.ItemsSource = orderDetailService.getAllOrderDetails()
                .Where(odetail => odetail.OrderID == od.OrderID).ToList();
        }

        private void lvOrderDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOrderDetails.SelectedItem is not OrderDetails odetail) return;
            txtProductID.Text = odetail.ProductID.ToString();
            txtUnitPrice.Text = odetail.UnitPrice.ToString("F2");
            txtQuantity.Text = odetail.Quantity.ToString();
            txtDiscount.Text = odetail.Discount.ToString("F2");
        }
    }
}
