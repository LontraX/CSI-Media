using CSI_Media.Models;
using Microsoft.EntityFrameworkCore;

namespace CSI_Media.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SortJob> SortJobs { get; set; }
    }

    
}
