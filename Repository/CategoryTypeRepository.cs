using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICatetype : IBaseRepository<CategoryType>
	{
	}
	public class CategoryTypeRepository : BaseRepository<CategoryType>, ICatetype
	{
		public CategoryTypeRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
