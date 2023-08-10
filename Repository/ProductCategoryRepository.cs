using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICategoryProduct : IBaseRepository<Category>
	{
	}
	public class ProductCategoryRepository : BaseRepository<Category>, ICategoryProduct
	{
		public ProductCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
