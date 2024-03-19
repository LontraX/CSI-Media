namespace CSI_Media.Models
{
    
    public class SortJob:BaseEntity
    {
        public List<int> Numbers { get; set; } // List of integers for sorted numbers
        public SortDirection SortDirection { get; set; } // "Ascending" or "Descending"
        public DateTime Timestamp { get; set; } // Time when the sort was performed
        public TimeSpan TimeTaken { get; set; } // Time taken for the sorting process

        public SortJob()
        {
            Numbers = new List<int>();
        }
    }
    
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    
}
