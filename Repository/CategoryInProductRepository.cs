using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICategoryInProductRepository : IBaseRepository<CategoryInProduct>
	{
	}
	public class CategoryInProductRepository : BaseRepository<CategoryInProduct>, ICategoryInProductRepository
	{
		public CategoryInProductRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
