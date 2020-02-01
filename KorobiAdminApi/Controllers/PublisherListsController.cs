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
    public class PublisherListsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PublisherListsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/PublisherLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherList>>> GetPublisherList()
        {
            return await _context.PublisherList.ToListAsync();
        }

        // GET: api/PublisherLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherList>> GetPublisherList(int id)
        {
            var publisherList = await _context.PublisherList.FindAsync(id);

            if (publisherList == null)
            {
                return NotFound();
            }

            return publisherList;
        }

        // PUT: api/PublisherLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisherList(int id, PublisherList publisherList)
        {
            if (id != publisherList.id)
            {
                return BadRequest();
            }

            _context.Entry(publisherList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherListExists(id))
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

        // POST: api/PublisherLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PublisherList>> PostPublisherList(PublisherList publisherList)
        {
            _context.PublisherList.Add(publisherList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublisherList", new { id = publisherList.id }, publisherList);
        }

        // DELETE: api/PublisherLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublisherList>> DeletePublisherList(int id)
        {
            var publisherList = await _context.PublisherList.FindAsync(id);
            if (publisherList == null)
            {
                return NotFound();
            }

            _context.PublisherList.Remove(publisherList);
            await _context.SaveChangesAsync();

            return publisherList;
        }

        private bool PublisherListExists(int id)
        {
            return _context.PublisherList.Any(e => e.id == id);
        }
    }
}
