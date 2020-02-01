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
    public class Product_PriceController : ControllerBase
    {
        private readonly ApiContext _context;

        public Product_PriceController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Product_Price
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Price>>> GetProduct_Price()
        {
            return await _context.Product_Price.ToListAsync();
        }

        // GET: api/Product_Price/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Price>> GetProduct_Price(int id)
        {
            var product_Price = await _context.Product_Price.FindAsync(id);

            if (product_Price == null)
            {
                return NotFound();
            }

            return product_Price;
        }

        // PUT: api/Product_Price/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_Price(int id, Product_Price product_Price)
        {
            if (id != product_Price.price_id)
            {
                return BadRequest();
            }

            _context.Entry(product_Price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_PriceExists(id))
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

        // POST: api/Product_Price
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product_Price>> PostProduct_Price(Product_Price product_Price)
        {
            _context.Product_Price.Add(product_Price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_Price", new { id = product_Price.price_id }, product_Price);
        }

        // DELETE: api/Product_Price/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product_Price>> DeleteProduct_Price(int id)
        {
            var product_Price = await _context.Product_Price.FindAsync(id);
            if (product_Price == null)
            {
                return NotFound();
            }

            _context.Product_Price.Remove(product_Price);
            await _context.SaveChangesAsync();

            return product_Price;
        }

        private bool Product_PriceExists(int id)
        {
            return _context.Product_Price.Any(e => e.price_id == id);
        }
    }
}
