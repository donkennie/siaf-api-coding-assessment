using SIAF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Contracts
{
    public interface IProduct
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductsById(int id);
        Task<Products> CreateProducts(Products products);
        void UpdateProducts(Products products);
    }
}
