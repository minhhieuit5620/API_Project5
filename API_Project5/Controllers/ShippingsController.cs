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
    public class ShippingsController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public ShippingsController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShipping()
        {
            return await _context.Shipping.ToListAsync();
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(int id)
        {
            var shipping = await _context.Shipping.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return shipping;
        }

        [HttpGet]
        [Route("getShipOrder/{id}")]
        public async Task<ActionResult<IEnumerable<Shipping>>> getIdOrder(int id)
        {
            return await _context.Shipping.Where(e => e.idOrder == id).ToListAsync();
            //  return Get_CateID;
        }

        // PUT: api/Shippings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(int id, Shipping shipping)
        {
            if (id != shipping.ShipId)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            _context.Shipping.Add(shipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipping", new { id = shipping.ShipId }, shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipping>> DeleteShipping(int id)
        {
            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();

            return shipping;
        }

        private bool ShippingExists(int id)
        {
            return _context.Shipping.Any(e => e.ShipId == id);
        }
    }
}
