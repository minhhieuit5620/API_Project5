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
    public class CategoryProjectsController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public CategoryProjectsController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/CategoryProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProject>>> GetCategoryProject()
        {
            return await _context.CategoryProject.ToListAsync();
        }

        [Route("GetCateProjCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountCateProject()
        {
            return _context.CategoryProject.ToList().Count();
        }

        // GET: api/CategoryProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProject>> GetCategoryProject(int id)
        {
            var categoryProject = await _context.CategoryProject.FindAsync(id);

            if (categoryProject == null)
            {
                return NotFound();
            }

            return categoryProject;
        }

        // PUT: api/CategoryProjects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryProject(int id, CategoryProject categoryProject)
        {
            if (id != categoryProject.IdCateProject)
            {
                return BadRequest();
            }

            _context.Entry(categoryProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryProjectExists(id))
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

        // POST: api/CategoryProjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryProject>> PostCategoryProject(CategoryProject categoryProject)
        {
            _context.CategoryProject.Add(categoryProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryProject", new { id = categoryProject.IdCateProject }, categoryProject);
        }

        // DELETE: api/CategoryProjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryProject>> DeleteCategoryProject(int id)
        {
            var categoryProject = await _context.CategoryProject.FindAsync(id);
            if (categoryProject == null)
            {
                return NotFound();
            }

            _context.CategoryProject.Remove(categoryProject);
            await _context.SaveChangesAsync();

            return categoryProject;
        }

        private bool CategoryProjectExists(int id)
        {
            return _context.CategoryProject.Any(e => e.IdCateProject == id);
        }
    }
}
