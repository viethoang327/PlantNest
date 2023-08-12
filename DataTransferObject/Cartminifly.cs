namespace PlantNestApp.DataTransferObject
{
	public class Cartminifly
	{

		
			public int? id { get; set; }
			public DateTime? createdAt { get; set; }
			public string? createdBy { get; set; }
			public DateTime? updatedAt { get; set; }
			public string? updatedBy { get; set; }
			public bool? isDeleted { get; set; }
			public DateTime? deleteAt { get; set; }
			public string? deleteBy { get; set; }
			public string? userID { get; set; }
			public int? productID { get; set; }
			public int? quantity { get; set; }
			public decimal? price { get; set; }
		public string? name { get; set; }
		public decimal? totalprice { get; set; }
		public string? image { get; set; }


	}
}
