namespace PlantNestApp.DataTransferObject
{
	public class OderMinifile
	{


			
			public string? code { get; set; }
			public string? address { get; set; }
			public string? phone { get; set; }
			public List<int> productid { get; set; }
	     	public List<string> productname { get; set; }
		    public string? price { get; set; }	

		    public string? quantity { get; set; }

		    public DateTime? createdAt { get; set; }
			public string? createdBy { get; set; }
			public DateTime? updatedAt { get; set; }
			public string? updatedBy { get; set; }
			public string? isDeleted { get; set; }
			public DateTime? deleteAt { get; set; }
			public string? deleteBy { get; set; }
		

	}
}
