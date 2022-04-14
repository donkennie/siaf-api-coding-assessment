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
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IProduct _productService;

        public ProductController(ApplicationDbContext dbContext, IProduct productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllCategories()
        {
            var obj = await _productService.GetAllProducts();

            return Ok(obj);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProductById(int id)
        {
            var obj = await _productService.GetProductsById(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProfile(Products products)
        {
            if (products == null)
            {
                return BadRequest("Products object is null");
            }
            await _productService.CreateProducts(products);

            await _dbContext.SaveChangesAsync();


            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Products product)
        {

            if (id != product.Id)
            {
                return BadRequest();
            }

            _productService.UpdateProducts(product);

            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

    }
}
