using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICategoryInProductRepository : IBaseRepository<CategoryInProduct>
	{
		Task<List<Category>> GetCategoryByProductId(int productId);
		
	}
	public class CategoryInProductRepository : BaseRepository<CategoryInProduct>, ICategoryInProductRepository
	{
		public CategoryInProductRepository(ApplicationDbContext context) : base(context)
		{
		}
		public Task<List<Category>> GetCategoryByProductId(int productId)
		{

			var query = from c in _db.categories
						join cp in _db.categoryInProducts on c.Id equals cp.CategoryID
						join p in _db.products on cp.ProductID equals p.Id
						where p.Id == productId
						select c;
			return query.ToListAsync();

		}

	}
}
