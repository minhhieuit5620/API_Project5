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
    public class CategoryProductsController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public CategoryProductsController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProduct()
        {
            return await _context.CategoryProduct.ToListAsync();
        }

        [Route("GetCateCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountCatePro()
        {
            return _context.CategoryProduct.ToList().Count();
        }

        // GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProduct>> GetCategoryProduct(int id)
        {
            var categoryProduct = await _context.CategoryProduct.FindAsync(id);

            if (categoryProduct == null)
            {
                return NotFound();
            }

            return categoryProduct;
        }

        // PUT: api/CategoryProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProduct(int id, CategoryProduct categoryProduct)
        {
            if (id != categoryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProductExists(id))
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

        // POST: api/CategoryProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryProduct>> PostCategoryProduct(CategoryProduct categoryProduct)
        {
            _context.CategoryProduct.Add(categoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryProduct", new { id = categoryProduct.Id }, categoryProduct);
        }

        // DELETE: api/CategoryProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryProduct>> DeleteCategoryProduct(int id)
        {
            var categoryProduct = await _context.CategoryProduct.FindAsync(id);
            if (categoryProduct == null)
            {
                return NotFound();
            }

            _context.CategoryProduct.Remove(categoryProduct);
            await _context.SaveChangesAsync();

            return categoryProduct;
        }

        private bool CategoryProductExists(int id)
        {
            return _context.CategoryProduct.Any(e => e.Id == id);
        }
    }
}
