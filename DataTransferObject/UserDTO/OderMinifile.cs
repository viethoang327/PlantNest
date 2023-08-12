namespace PlantNestApp.DataTransferObject.UserDTO
{
	public class OderMinifile
	{

		public class Rootobject
		{
			public int id { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public string image { get; set; }
			public float price { get; set; }
			public int quantity { get; set; }
			public string[] categoriesName { get; set; }
			public float priceAfterDiscount { get; set; }
			public int rating { get; set; }
			public int discountPercentage { get; set; }
		}

	}
}
