using CSI_Media.Commons;
using CSI_Media.Data.Repository;
using CSI_Media.Models;
using CSI_Media.Models.DTOs;
using CSI_Media.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSI_Media.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISortingService _sortingService;
        private readonly ISortJobRepository _repo;

        public HomeController(ILogger<HomeController> logger,ISortingService sortingService, ISortJobRepository sortJobRepository)
        {
            _logger = logger;
            _sortingService = sortingService;
            _repo = sortJobRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SortJobViewModel();

            // Load previous sort jobs
            var pastSorts = await _repo.GetAllSortJobs();
            foreach (var pastSort in pastSorts)
            {
                viewModel.PastSorts.Add(new SortJobResponseDTO
                {
                    Numbers = string.Join(",", pastSort.Numbers),
                    SortDirection = pastSort.SortDirection,
                    Timestamp = pastSort.Timestamp,
                    TimeTaken = pastSort.TimeTaken
                });
            }

            return View(viewModel);
        }

        public async Task<IActionResult> ExportSortsJson()
        {
            // Fetch past sorts data from the repository or database
            var pastSorts = await _repo.GetAllSortJobs(); 
                                                    // Return the past sorts data in JSON format
            return Json(pastSorts);
        }


        [HttpPost]
        public async Task<IActionResult> PerformSortJob(SortJobRequestDTO jobRequestDTO)
        {
            if (jobRequestDTO == null)
            {
                return View("Error");
            }
            var viewModel = new SortJobViewModel();
            SortDirection sortDirection;
            
            Enum.TryParse(jobRequestDTO.SortDirection, out sortDirection);
            
            
            var listToSort = Utilities.ParseNumbersFromInput(jobRequestDTO.Numbers);
            var result = _sortingService.SortNumber(listToSort,sortDirection);
            await _repo.AddSortJob(new SortJob
            {
                DateCreated = DateTime.Now,
                SortDirection = sortDirection,
                Timestamp = DateTime.Now,
                TimeTaken = result.TimeTaken,
                Numbers = listToSort,
                DateUpdated = DateTime.Now,
            });
            
            if (result != null)
            {
                viewModel.SortJobRequest = result;
                var pastSorts = await _repo.GetAllSortJobs();
                foreach ( var pastSort in pastSorts)
                {
                    viewModel.PastSorts.Add(new SortJobResponseDTO { 
                        Numbers = string.Join(",",pastSort.Numbers),
                        SortDirection = pastSort.SortDirection,
                        Timestamp = pastSort.Timestamp,
                        TimeTaken = pastSort.TimeTaken,
                    });
                }
            }
            return View("Index",viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
