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
    public class Product_sub_CategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public Product_sub_CategoryController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Product_sub_Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_subCategory>>> GetProduct_sub_Category()
        {
            return await _context.Product_subCategory.ToListAsync();
        }

        // GET: api/Product_sub_Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_subCategory>> GetProduct_sub_Category(int id)
        {
            var product_sub_Category = await _context.Product_subCategory.FindAsync(id);

            if (product_sub_Category == null)
            {
                return NotFound();
            }

            return product_sub_Category;
        }

        // PUT: api/Product_sub_Category/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_sub_Category(int id, Product_subCategory product_sub_Category)
        {
            if (id != product_sub_Category.id)
            {
                return BadRequest();
            }

            _context.Entry(product_sub_Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_sub_CategoryExists(id))
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

        // POST: api/Product_sub_Category
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product_subCategory>> PostProduct_sub_Category(Product_subCategory product_sub_Category)
        {
            _context.Product_subCategory.Add(product_sub_Category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_sub_Category", new { id = product_sub_Category.id }, product_sub_Category);
        }

        // DELETE: api/Product_sub_Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product_subCategory>> DeleteProduct_sub_Category(int id)
        {
            var product_sub_Category = await _context.Product_subCategory.FindAsync(id);
            if (product_sub_Category == null)
            {
                return NotFound();
            }

            _context.Product_subCategory.Remove(product_sub_Category);
            await _context.SaveChangesAsync();

            return product_sub_Category;
        }

        private bool Product_sub_CategoryExists(int id)
        {
            return _context.Product_subCategory.Any(e => e.id == id);
        }
    }
}
