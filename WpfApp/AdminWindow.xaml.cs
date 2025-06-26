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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Btn_CustomerMN_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagementWindow cmw = new();
            cmw.Show();
        }

        private void Btn_ProductMN_Click(object sender, RoutedEventArgs e)
        {
            ProductManagementWindow pmw = new();
            pmw.Show();
        }

        private void Btn_OrderMN_Click(object sender, RoutedEventArgs e)
        {
            OrderManagementWindow omw = new();
            omw.Show();
        }

        private void Btn_OrderMN1_Click(object sender, RoutedEventArgs e)
        {
            AdminReportWindow arw = new();
            arw.Show();
        }
    }
}
