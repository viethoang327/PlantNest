using PlantNestApp.Models;

namespace PlantNestApp.DataTransferObject
{
	public class CategoriesByTypeDTO
	{
		public string CategoryType { get; set; }
		public List<Category> Categories { get;  set; }
	}
}
