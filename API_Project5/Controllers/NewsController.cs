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
    public class NewsController : ControllerBase
    {
        private readonly Iterior_DesignContext _context;

        public NewsController(Iterior_DesignContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await _context.News.ToListAsync();
        }
        [Route("GetNewCount")]
        [HttpGet]
        public async Task<ActionResult<int>> GetNewsCount()
        {
            return _context.News.ToList().Count();
        }
        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // PUT: api/News/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.IdNew)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST: api/News
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.IdNew }, news);
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }
        [Route("Get3News")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get3News()
        {
            var ds = _context.News.OrderByDescending(s => s.IdNew).ToList().Take(3);
            return ds.ToList();
        }
        [HttpGet]
        [Route("GetCateNewId/{cteid}")]
        public async Task<ActionResult<IEnumerable<News>>> Get_CateId(int cteid)
        {
            return await _context.News.Where(e => e.IdCategoryNew == cteid).ToListAsync();
            //  return Get_CateID;
        }
        [HttpGet]
        [Route("SearchByNameNews/{name}")]
        public async Task<ActionResult<IEnumerable<News>>> SearchByName(string name)
        {
            return await _context.News.Where(x => x.NameNew.Contains(name)).ToListAsync();
        }
        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.IdNew == id);
        }
    }
}
