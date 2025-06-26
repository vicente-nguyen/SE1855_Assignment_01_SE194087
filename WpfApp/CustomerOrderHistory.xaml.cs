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
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerOrderHistory.xaml
    /// </summary>
    public partial class CustomerOrderHistory : Window
    {
        int _customerId;
        OrderService orderService = new OrderService();
        OrderDetailService orderDetailService = new OrderDetailService();
        public CustomerOrderHistory(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            LoadHistory();
        }
        private void LoadHistory()
        {
            var orders = orderService.getAllOrders()
                                     .Where(o => o.CustomerID == _customerId)  // ★ filter ★
                                     .ToList();

            var rows = orders.Select(o =>
            {
                var details = orderDetailService.GetDetailsByOrder(o.OrderID);
                return new
                {
                    o.OrderID,
                    Quantity = details.Sum(d => d.Quantity),
                    TotalAmount = details.Sum(d =>
                                   d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount)),
                    o.OrderDate
                };
            })
            .OrderByDescending(r => r.OrderDate)
            .ThenByDescending(r => r.OrderID)
            .ToList();

            dgHistory.ItemsSource = rows;
        }
    }
}
