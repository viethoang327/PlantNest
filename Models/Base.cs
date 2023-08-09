using System.ComponentModel.DataAnnotations;

namespace PlantNestApp.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? DeleteAt { get; set; } = DateTime.Now;
        public string? DeleteBy { get; set; }
    }
}
