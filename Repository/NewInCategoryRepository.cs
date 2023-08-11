using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface INewInCate : IBaseRepository<NewsInCategory>
	{
		Task<List<NewsCategory>> GetCategoryNewByNewId(int productId);
	}
	public class NewInCategoryRepository : BaseRepository<NewsInCategory>, INewInCate
	{
		public NewInCategoryRepository(ApplicationDbContext context) : base(context)
		{

		}
		public Task<List<NewsCategory>> GetCategoryNewByNewId(int newId)
		{

			var query = from c in _db.newsCategories
						join cp in _db.newsInCategories on c.Id equals cp.NewsCategoryID
						join p in _db.news on cp.NewsID equals p.Id
						where p.Id == newId
						select c;
			return query.ToListAsync();

		}


	}
}
