using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project5.Models;

namespace API_Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class introducesController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public introducesController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/introduces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<intruduce>>> Getintroduce()
        {
            return await _context.introduce.ToListAsync();
        }

        // GET: api/introduces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<intruduce>> Getintroduce(int id)
        {
            var introduce = await _context.introduce.FindAsync(id);

            if (introduce == null)
            {
                return NotFound();
            }

            return introduce;
        }

        // PUT: api/introduces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putintroduce(int id, intruduce introduce)
        {
            if (id != introduce.id)
            {
                return BadRequest();
            }

            _context.Entry(introduce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!introduceExists(id))
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

        // POST: api/introduces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<intruduce>> Postintroduce(intruduce introduce)
        {
            _context.introduce.Add(introduce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getintroduce", new { id = introduce.id }, introduce);
        }

        // DELETE: api/introduces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<intruduce>> Deleteintroduce(int id)
        {
            var introduce = await _context.introduce.FindAsync(id);
            if (introduce == null)
            {
                return NotFound();
            }

            _context.introduce.Remove(introduce);
            await _context.SaveChangesAsync();

            return introduce;
        }

        private bool introduceExists(int id)
        {
            return _context.introduce.Any(e => e.id == id);
        }
    }
}
