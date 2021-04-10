using Microsoft.EntityFrameworkCore;

namespace GiphyApp.Models
{
    public class GiphyContext : DbContext
    {
        public GiphyContext(DbContextOptions<GiphyContext> options)
            : base(options)
        {
        }

        public DbSet<GiphyItem> GiphyItems { get; set; }
    }
}