using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNestApp.Models
{
    public class OrderDetail : Base
    {
        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        [ForeignKey("OderID")]
        public int? OrderID { get; set; }
        public Order? Order { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
