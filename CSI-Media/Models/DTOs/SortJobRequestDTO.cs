namespace CSI_Media.Models.DTOs
{
    public class SortJobRequestDTO
    {
        public string? Numbers { get; set; } // List of integers for sorted numbers
        public string? SortDirection { get; set; } // "Ascending" or "Descending"
       
    }
}
