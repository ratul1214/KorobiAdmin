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
    public class Product_CategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public Product_CategoryController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Product_Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Category>>> Getproduct_category()
        {
            return await _context.product_category.ToListAsync();
        }

        // GET: api/Product_Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Category>> GetProduct_Category(int id)
        {
            var product_Category = await _context.product_category.FindAsync(id);

            if (product_Category == null)
            {
                return NotFound();
            }

            return product_Category;
        }

        // PUT: api/Product_Category/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_Category(int id, Product_Category product_Category)
        {
            if (id != product_Category.id)
            {
                return BadRequest();
            }

            _context.Entry(product_Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_CategoryExists(id))
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

        // POST: api/Product_Category
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product_Category>> PostProduct_Category(Product_Category product_Category)
        {
            _context.product_category.Add(product_Category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_Category", new { id = product_Category.id }, product_Category);
        }

        // DELETE: api/Product_Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product_Category>> DeleteProduct_Category(int id)
        {
            var product_Category = await _context.product_category.FindAsync(id);
            if (product_Category == null)
            {
                return NotFound();
            }

            _context.product_category.Remove(product_Category);
            await _context.SaveChangesAsync();

            return product_Category;
        }

        private bool Product_CategoryExists(int id)
        {
            return _context.product_category.Any(e => e.id == id);
        }
    }
}
