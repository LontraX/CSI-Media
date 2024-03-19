using CSI_Media.Models;
using CSI_Media.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSI_Media.Data.Repository
{
    public class SortJobRepository : ISortJobRepository
    {
        private readonly AppDbContext _ctx;

        public SortJobRepository(AppDbContext appDbContext)
        {
                _ctx = appDbContext;
        }
        public async Task<bool> AddSortJob(SortJob sortJobRequest)
        {
            
            await _ctx.SortJobs.AddAsync(sortJobRequest);
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<List<SortJob>> GetAllSortJobs()
        {
            return await _ctx.SortJobs.ToListAsync();
        }
    }
}
