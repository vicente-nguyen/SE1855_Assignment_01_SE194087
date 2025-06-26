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
    /// Interaction logic for AdminReportWindow.xaml
    /// </summary>
    public partial class AdminReportWindow : Window
    {
        private readonly OrderService orderService = new OrderService();
        private readonly OrderDetailService detailService = new OrderDetailService();  
        public AdminReportWindow()
        {
            InitializeComponent();
            dpStart.SelectedDate = DateTime.Today.AddDays(-30);
            dpEnd.SelectedDate = DateTime.Today;
            GenerateReport();
        }

        private void GenerateReport()
        {
            if (dpStart.SelectedDate == null || dpEnd.SelectedDate == null)
            {
                MessageBox.Show("Please select both start and end dates.",
                    "Invalid Dates", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var start = dpStart.SelectedDate.Value.Date;
            var end = dpEnd.SelectedDate.Value.Date.AddDays(1).AddTicks(-1);

            var data = orderService.getAllOrders()
                .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                .Select(o => new
                {
                    o.OrderID,
                    o.CustomerID,
                    o.EmployeeID,
                    o.OrderDate,
                    TotalAmount = detailService
                    .GetDetailsByOrder(o.OrderID)
                    .Sum(od => od.Quantity * od.UnitPrice * (1 - (decimal)od.Discount))
                })
                .OrderByDescending(r => r.OrderDate)
                .ThenByDescending(r => r.OrderID)
                .ToList();
            dgReport.ItemsSource = data;
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            GenerateReport();
        }
    }
}
