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
    public class ProductsController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public ProductsController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        [Route("GetProductCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCount()
        {
            return  _context.Products.ToList().Count();
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }
        [Route("GetProductNew")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductNew()
        {
            var ds = _context.Products.OrderByDescending(s => s.Id).ToList().Take(5);
            return ds.ToList();
        }

        [HttpGet]
        [Route("GetCateId/{cteid}")]
        public async Task<ActionResult<IEnumerable<Products>>> Get_CateId(int cteid)
        {
            return await _context.Products.Where(e => e.IdCategory == cteid).ToListAsync();
            //  return Get_CateID;
        }
        [HttpGet]
        [Route("SearchByName/{name}")]
        public async Task<ActionResult<IEnumerable<Products>>> SearchByName(string name)
        {
            return await _context.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        }
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
