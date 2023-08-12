namespace PlantNestApp.DataTransferObject
{


	

	public class ProductMinify
	{
		public int id { get; set; }
		public string? title { get; set; }
		public string? description { get; set; }
		public string? image { get; set; }
		public decimal? price { get; set; }
		public int? quantity { get; set; }
		public List<string>? categoriesName { get; set; }

		public string? categoriesType { get; set; }
		public decimal? priceAfterDiscount { get; set; }
		public int? rating { get; set; }
		public decimal? discountPercentage { get; set; }


	}

}
