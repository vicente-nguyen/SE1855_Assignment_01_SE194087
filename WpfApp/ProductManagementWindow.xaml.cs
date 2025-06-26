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
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        ProductService productService = new ProductService();
        public ProductManagementWindow()
        {
            InitializeComponent();
            DisplayProduct();
        }

        private void DisplayProduct()
        {
            lvProduct.ItemsSource = productService.getAllProducts();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem is not Products p) return;
            txtProductID.Text = p.ProductID.ToString();
            txtProductName.Text = p.ProductName;
            txtCategoryID.Text = p.CategoryID?.ToString();
            txtUnitPrice.Text = p.UnitPrice?.ToString("F2");
            txtUnitsInStock.Text = p.UnitsInStock?.ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Products p = new Products
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text,
                CategoryID = string.IsNullOrEmpty(txtCategoryID.Text) ? (int?)null : int.Parse(txtCategoryID.Text),
                UnitPrice = string.IsNullOrEmpty(txtUnitPrice.Text) ? (decimal?)null : decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = string.IsNullOrEmpty(txtUnitsInStock.Text) ? (int?)null : int.Parse(txtUnitsInStock.Text)
            };
            bool result = productService.CreateProduct(p);
            if (result)
            {
                MessageBox.Show("Product created successfully.");
                DisplayProduct();
            }
            else
            {
                MessageBox.Show("Failed to create product.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Products p = new Products
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text,
                CategoryID = string.IsNullOrEmpty(txtCategoryID.Text) ? (int?)null : int.Parse(txtCategoryID.Text),
                UnitPrice = string.IsNullOrEmpty(txtUnitPrice.Text) ? (decimal?)null : decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = string.IsNullOrEmpty(txtUnitsInStock.Text) ? (int?)null : int.Parse(txtUnitsInStock.Text)
            };
            bool result = productService.UpdateProduct(p);
            if (result)
            {
                MessageBox.Show("Product updated successfully.");
                DisplayProduct();
            }
            else
            {
                MessageBox.Show("Failed to update product.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (ret == MessageBoxResult.No)
                return;
            Products p = new Products
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text,
                CategoryID = string.IsNullOrEmpty(txtCategoryID.Text) ? (int?)null : int.Parse(txtCategoryID.Text),
                UnitPrice = string.IsNullOrEmpty(txtUnitPrice.Text) ? (decimal?)null : decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = string.IsNullOrEmpty(txtUnitsInStock.Text) ? (int?)null : int.Parse(txtUnitsInStock.Text)
            };
            bool result = productService.DeleteProduct(p);
            if (result)
            {
                MessageBox.Show("Product deleted successfully.");
                DisplayProduct();
            }
            else
            {
                MessageBox.Show("Failed to delete product.");
            }
        }
    }
}
