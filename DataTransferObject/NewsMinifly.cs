namespace PlantNestApp.DataTransferObject
{
	public class NewsMinifly
	{

		
			public string? name { get; set; }
			public string? description { get; set; }
			public string? image { get; set; }
			public string? content { get; set; }
			public string? author { get; set; }
			public int? id { get; set; }
		    public List<string>? categoriesName { get; set; }

		    public string? categoriestype { get; set; }
		   public List<int>? categoriesId { get; set; }
		    public DateTime? createdAt { get; set; }
			public string? createdBy { get; set; }
			public DateTime? updatedAt { get; set; }
			public string? updatedBy { get; set; }
			public string? isDeleted { get; set; }
			public DateTime? deleteAt { get; set; }
			public string? deleteBy { get; set; }
		

	}
}
