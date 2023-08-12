using PlantNestApp.Models;

namespace PlantNestApp.DataTransferObject
{
	public class productBycategories
	{
		public string productcategories { get; set; }
		public List<Product> Products { get; set; }
	}
}
