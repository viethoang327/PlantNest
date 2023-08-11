namespace PlantNestApp.Models
{
	public class Promotion : Base
	{
		public string? CouponCode { get; set; }
		public decimal? DiscountPercent { get; set; }
		public DateTime? ExpireDate { get; set; }
		public string? CouponeType { get;set; }
	}
}
