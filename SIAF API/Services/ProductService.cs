using Microsoft.EntityFrameworkCore;
using SIAF_API.Contracts;
using SIAF_API.Data;
using SIAF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Services
{
    public class ProductService : IProduct
    {

        private readonly ApplicationDbContext _context;


        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var obj = await _context.GetProducts.ToListAsync();

            return obj;
        }


        public async Task<Products> GetProductsById(int id)
        {
            var obj = await _context.GetProducts.FirstOrDefaultAsync(p => p.Id == id);
            return obj;
        }


        public async Task<Products> CreateProducts(Products products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var obj = await _context.GetProducts.AddAsync(products);

            return obj.Entity;
        }


        public void UpdateProducts(Products products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            _context.GetProducts.Update(products);
        }
    }
}
