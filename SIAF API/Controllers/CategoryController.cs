using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIAF_API.Contracts;
using SIAF_API.Data;
using SIAF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ICategories _categoryService;

        public CategoryController(ApplicationDbContext dbContext, ICategories categoryService)
        {
            _dbContext = dbContext; 
            _categoryService = categoryService;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
        {
            var profile = await _categoryService.GetAllCategories();

            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<Categories>> PostProfile(Categories categories)
        {
            if (categories == null)
            {
                return BadRequest("Categories object is null");
            }
            await _categoryService.CreateCategories(categories);

                await _dbContext.SaveChangesAsync();
            
            
            return StatusCode(201);
        }
    }
}
