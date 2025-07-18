﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    public interface IProductService
    {
        public List<Products> getAllProducts();
        public bool CreateProduct(Products products);
        public bool UpdateProduct(Products products);
        public bool DeleteProduct(Products products);
    }
}
