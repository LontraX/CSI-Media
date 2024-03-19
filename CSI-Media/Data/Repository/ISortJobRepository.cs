using CSI_Media.Models;
using CSI_Media.Models.DTOs;

namespace CSI_Media.Data.Repository
{
    public interface ISortJobRepository
    {
        Task<List<SortJob>> GetAllSortJobs();
        
        Task<bool> AddSortJob(SortJob sortJobRequest);
        
    }
}
