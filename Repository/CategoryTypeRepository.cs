using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface ICatetype : IBaseRepository<CategoryType>
	{
		Task<List<CategoriesByTypeDTO>> GetCategoriesByType();
	}
	public class CategoryTypeRepository : BaseRepository<CategoryType>, ICatetype
	{
		public CategoryTypeRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<CategoriesByTypeDTO>> GetCategoriesByType()
		{
			var result = new List<CategoriesByTypeDTO>();
			//Dau tien la lay ra tat ca cac type

			var types = await _db.categoriesType.ToListAsync();
			var categories = await _db.categories.ToListAsync();
			foreach(var t in types)
			{
				var obj = new CategoriesByTypeDTO();
				obj.CategoryType = t.Name;
				obj.Categories = categories.Where(r => r.Type.Equals(t.Name)).ToList();
				result.Add(obj);
			}
			return result;
		}
	}
}
