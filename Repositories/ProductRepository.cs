using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAcessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();
        public bool CreateProduct(Products products)
        {
            return productDAO.CreateProduct(products);
        }

        public bool DeleteProduct(Products products)
        {
            return productDAO.DeleteProduct(products);
        }

        public List<Products> getAllProducts()
        {
            return productDAO.getAllProducts();
        }

        public bool UpdateProduct(Products products)
        {
            return productDAO.UpdateProduct(products);
        }
    }
}
