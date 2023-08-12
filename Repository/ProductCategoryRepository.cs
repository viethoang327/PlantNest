using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICategoryProduct : IBaseRepository<Category>
	{
		Task<List<Category>> GetCategoriesByTypeAsync(string type);
	}
	public class ProductCategoryRepository : BaseRepository<Category>, ICategoryProduct
	{
		public ProductCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<Category>> GetCategoriesByTypeAsync(string type)
		{
			var result = _db.categories.Where(r => r.isDeleted != true && r.Type.Equals(type));
			return await result.ToListAsync();
		}

		
	}
}
