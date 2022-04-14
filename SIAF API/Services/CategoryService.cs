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
    public class CategoryService : ICategories
    {
        private readonly ApplicationDbContext _context;


        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Categories> CreateCategories(Categories categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }

            var obj = await _context.GetCategories.AddAsync(categories);

            return obj.Entity;
        }


        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            var obj = await _context.GetCategories.ToListAsync();

            return obj;
        }
    }
}
