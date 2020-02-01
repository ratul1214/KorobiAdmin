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
    public class WriterListsController : ControllerBase
    {
        private readonly ApiContext _context;

        public WriterListsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/WriterLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WriterList>>> GetWriterList()
        {
            return await _context.WriterList.ToListAsync();
        }

        // GET: api/WriterLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WriterList>> GetWriterList(int id)
        {
            var writerList = await _context.WriterList.FindAsync(id);

            if (writerList == null)
            {
                return NotFound();
            }

            return writerList;
        }

        // PUT: api/WriterLists/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWriterList(int id, WriterList writerList)
        {
            if (id != writerList.id)
            {
                return BadRequest();
            }

            _context.Entry(writerList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WriterListExists(id))
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

        // POST: api/WriterLists
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WriterList>> PostWriterList(WriterList writerList)
        {
            _context.WriterList.Add(writerList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWriterList", new { id = writerList.id }, writerList);
        }

        // DELETE: api/WriterLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WriterList>> DeleteWriterList(int id)
        {
            var writerList = await _context.WriterList.FindAsync(id);
            if (writerList == null)
            {
                return NotFound();
            }

            _context.WriterList.Remove(writerList);
            await _context.SaveChangesAsync();

            return writerList;
        }

        private bool WriterListExists(int id)
        {
            return _context.WriterList.Any(e => e.id == id);
        }
    }
}
