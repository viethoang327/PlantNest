namespace PlantNestApp.Models
{
    public class Cart : Base
    {
        public int? UserID { get; set; }
        public int? ProductID { get; set;}
        public int? Quantity { get; set;}
    }
}
