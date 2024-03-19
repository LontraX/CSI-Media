namespace CSI_Media.Models.DTOs
{
    public class SortJobResponseDTO
    {
        public string? Numbers { get; set; } // List of integers for sorted numbers
        public SortDirection SortDirection { get; set; } // "Ascending" or "Descending"
        public DateTime Timestamp { get; set; } // Time when the sort was performed
        public TimeSpan TimeTaken { get; set; } // Time taken for the sorting process

        
    }
}
