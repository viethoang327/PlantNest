using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNestApp.Models
{
    public class CategoryInProduct : Base
    {
        [ForeignKey("Category")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Product")]
        public int? ProductID { get; set; }
        public Product? Product { get; set; }

    }
}
