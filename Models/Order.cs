using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNestApp.Models
{
    public class Order : Base
    {
        [ForeignKey("UserID")]
		public string? UserID { get; set; }
        public CustomerUser? customerUser { get; set; }
		public string? Code { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set;}
        public decimal? TotalMoney { get; set;}
        public string? Status { get; set;}
              
    }
}
