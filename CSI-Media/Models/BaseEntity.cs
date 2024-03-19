namespace CSI_Media.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; } 
        public DateTime DateUpdated { get; set; } 
    }
}
