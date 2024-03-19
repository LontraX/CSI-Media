using CSI_Media.Models.DTOs;

namespace CSI_Media.Models
{
    public class SortJobViewModel
    {
        public SortJobResponseDTO? SortJobRequest { get; set; } // For current sort data
        public List<SortJobResponseDTO> PastSorts { get; set; } // For past sort data
        public SortJobViewModel()
        {
                PastSorts = new List<SortJobResponseDTO>();
        }
    }
}
