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
    public class LienHesController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public LienHesController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/LienHes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LienHe>>> GetLienHe()
        {
            return await _context.LienHe.ToListAsync();
        }
        [Route("GetContactCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetContactCount()
        {
            return _context.LienHe.ToList().Count();
        }

        // GET: api/LienHes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LienHe>> GetLienHe(int id)
        {
            var lienHe = await _context.LienHe.FindAsync(id);

            if (lienHe == null)
            {
                return NotFound();
            }

            return lienHe;
        }

        // PUT: api/LienHes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLienHe(int id, LienHe lienHe)
        {
            if (id != lienHe.Id)
            {
                return BadRequest();
            }

            _context.Entry(lienHe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LienHeExists(id))
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

        // POST: api/LienHes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LienHe>> PostLienHe(LienHe lienHe)
        {
            _context.LienHe.Add(lienHe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLienHe", new { id = lienHe.Id }, lienHe);
        }

        // DELETE: api/LienHes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LienHe>> DeleteLienHe(int id)
        {
            var lienHe = await _context.LienHe.FindAsync(id);
            if (lienHe == null)
            {
                return NotFound();
            }

            _context.LienHe.Remove(lienHe);
            await _context.SaveChangesAsync();

            return lienHe;
        }

        private bool LienHeExists(int id)
        {
            return _context.LienHe.Any(e => e.Id == id);
        }
    }
}
