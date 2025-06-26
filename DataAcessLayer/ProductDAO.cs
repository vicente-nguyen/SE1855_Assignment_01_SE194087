using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAcessLayer
{
    public class ProductDAO
    {
        private const string ConnectionString = @"server=localhost;database=Lucy_SalesData;uid=sa;pwd=12345";
        lucyDataContext context = new lucyDataContext(ConnectionString);
        public List<Products> getAllProducts()
        {
            return context.Products
                .Select(p => new Products
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    CategoryID = p.CategoryID,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                })
                .ToList();
        }

        public bool CreateProduct(Products products)
        {
            Product old = context.Products.FirstOrDefault(p => p.ProductID == products.ProductID);
            if (old != null)
            {
                return false;
            }

            
            Product newProduct = new Product
            {
                ProductID = products.ProductID,
                ProductName = products.ProductName,
                CategoryID = products.CategoryID,
                UnitPrice = products.UnitPrice,
                UnitsInStock = products.UnitsInStock
            };

            context.Products.InsertOnSubmit(newProduct);
            context.SubmitChanges();
            return true;
        }

        public bool UpdateProduct(Products products)
        {
            Product old = context.Products.FirstOrDefault(c => c.ProductID == products.ProductID);
            if (old == null)
            {
                return false;
            }
            old.ProductID = products.ProductID;
            old.ProductName = products.ProductName;
            old.CategoryID = products.CategoryID;
            old.UnitPrice = products.UnitPrice;
            old.UnitsInStock = products.UnitsInStock;
            context.SubmitChanges();
            return true;
        }

        public bool DeleteProduct(Products products)
        {
            Product old = context.Products.FirstOrDefault(c => c.ProductID == products.ProductID);
            if (old == null)
            {
                return false;
            }
            context.Products.DeleteOnSubmit(old);
            context.SubmitChanges();
            return true;
        }
    }
}
