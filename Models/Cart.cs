namespace PlantNestApp.Models
{
    public class Cart : Base
    {
        public string? UserID { get; set; }
        public int? ProductID { get; set;}
        public int? Quantity { get; set;}

        public decimal? Price { get; set; }
    }
}
