using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository irepository; 
        public ProductService()
        {
            irepository = new ProductRepository(); 
        }

        public bool CreateProduct(Products products)
        {
            return irepository.CreateProduct(products);   
        }

        public bool DeleteProduct(Products products)
        {
            return irepository.DeleteProduct(products);  
        }

        public List<Products> getAllProducts()
        {
            return irepository.getAllProducts();   
        }

        public bool UpdateProduct(Products products)
        {
            return irepository.UpdateProduct(products);
        }
    }
}
