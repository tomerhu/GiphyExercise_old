using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiphyApp.Models;
using Microsoft.Extensions.Configuration;
using GiphyWebApi.Tools;
using GiphyWebApi.Models;
using System;
using GiphyWebApi.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GiphyApp.Controllers
{
    [Route("api/Giphy")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly GiphyContext _context;
        private readonly IGiphyTools _giphyTools;
        private readonly GiphyConfig _giphyConfig;
        private IMemoryCache _cache;

        public GiphyController(GiphyContext context, IConfiguration configuration, 
            IGiphyTools giphyTools, GiphyConfig giphyConfig, IMemoryCache memoryCache)
        {
            _giphyConfig = giphyConfig;
            Configuration = configuration;
            _context = context;
            _giphyTools = giphyTools;
            _cache = memoryCache;
        }

        // GET: api/Giphy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiphyItem>>> GetGiphyItems()
        {
            return await _context.GiphyItems.ToListAsync();
        }

        // GET: api/Giphy/cat
        [HttpGet("{searchTerm}")]
        public async Task<ActionResult<GiphyItem>> GetGiphyItem(string searchTerm)
        {
            GiphyItem giphyItem = new GiphyItem();
            try
            {
                //giphyItem = await _context.GiphyItems.FindAsync(searchTerm);
                if(!_cache.TryGetValue(searchTerm, out giphyItem))
                {
                    GifResult gifResult = await _giphyTools.GifFetch(searchTerm);
                    if (gifResult != null)
                    {
                        giphyItem = new GiphyItem()
                        {
                            SearchTerm = searchTerm,
                            Url = gifResult.Data.First().Url
                        };

                        var cacheEntryOptions = new MemoryCacheEntryOptions();

                        _cache.Set(searchTerm, giphyItem, cacheEntryOptions);

                        _context.GiphyItems.Add(giphyItem);
                    }
                }
            }
            catch (Exception ex)
            {
                string exc = ex.Message;
            }

            return giphyItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<GiphyItem>> PostGiphyItem(GiphyItem item)
        {
            _context.GiphyItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGiphyItem), new { id = item.SearchTerm }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiphyItem(string searchTerm, GiphyItem item)
        {
            if (searchTerm != item.SearchTerm)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiphyItem(string searchTerm)
        {
            var GiphyItem = await _context.GiphyItems.FindAsync(searchTerm);

            if (GiphyItem == null)
            {
                return NotFound();
            }

            _context.GiphyItems.Remove(GiphyItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}