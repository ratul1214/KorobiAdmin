using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newweb.Models;

namespace Newweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_subSubCategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public Product_subSubCategoryController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Product_subSubCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_subSubCategory>>> GetProduct_subSubCategory()
        {
            return await _context.Product_subSubCategory.ToListAsync();
        }

        // GET: api/Product_subSubCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_subSubCategory>> GetProduct_subSubCategory(int id)
        {
            var product_subSubCategory = await _context.Product_subSubCategory.FindAsync(id);

            if (product_subSubCategory == null)
            {
                return NotFound();
            }

            return product_subSubCategory;
        }

        // PUT: api/Product_subSubCategory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_subSubCategory(int id, Product_subSubCategory product_subSubCategory)
        {
            if (id != product_subSubCategory.id)
            {
                return BadRequest();
            }

            _context.Entry(product_subSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_subSubCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product_subSubCategory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product_subSubCategory>> PostProduct_subSubCategory(Product_subSubCategory product_subSubCategory)
        {
            _context.Product_subSubCategory.Add(product_subSubCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_subSubCategory", new { id = product_subSubCategory.id }, product_subSubCategory);
        }

        // DELETE: api/Product_subSubCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product_subSubCategory>> DeleteProduct_subSubCategory(int id)
        {
            var product_subSubCategory = await _context.Product_subSubCategory.FindAsync(id);
            if (product_subSubCategory == null)
            {
                return NotFound();
            }

            _context.Product_subSubCategory.Remove(product_subSubCategory);
            await _context.SaveChangesAsync();

            return product_subSubCategory;
        }

        private bool Product_subSubCategoryExists(int id)
        {
            return _context.Product_subSubCategory.Any(e => e.id == id);
        }
    }
}
