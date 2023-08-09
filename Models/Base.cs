using System.ComponentModel.DataAnnotations;

namespace PlantNestApp.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
        public bool? isDeleted { get; set; }
    }
}
