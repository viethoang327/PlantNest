using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlantNestApp.Repository
{
	public interface INew : IBaseRepository<News>
	{
		Task<List<NewsMinifly>> GetNewsMinifyAsync();
		Task<NewsMinifly> GetNewsByIdFullDetailAsync(int id);
		Task<NewsMinifly> GetNewsByCategoriesNewsFullDetailAsync(int id);
		Task<List<CountNewsInCategory>> GetCategoriesWithCountNews();
	}
	public class NewRepository : BaseRepository<News>, INew
	{
		public NewRepository(ApplicationDbContext context) : base(context)
		{
		}
		public async Task<List<NewsMinifly>> GetNewsMinifyAsync()
		{
			var query = _db.newsInCategories.Include(r => r.News).Include(r => r.NewsCategory).Where(r => r.News.isDeleted != true);
			var result = from q in query
						 group q by new
						 {
							 q.News.Name,
							 q.News.Id,
							 q.News.Description,
							 q.News.Image,
							 q.News.Content,
							 q.News.Author,
							 q.NewsCategory.Type
							
							

						 } into grouped
						 select new NewsMinifly
						 {
							 name = grouped.Key.Name,
							 id = grouped.Key.Id,
							 description = grouped.Key.Description,
							 image = grouped.Key.Image,
							 content = grouped.Key.Content,
							 author = grouped.Key.Author,
							 categoriesName = grouped.Select(r => r.NewsCategory.Name).ToList(),
							 categoriesId = grouped.Select(r => r.NewsCategory.Id).ToList(),
							 categoriestype = grouped.Key.Type,

						 };

			return await result.ToListAsync();
		}

		public async Task<NewsMinifly> GetNewsByIdFullDetailAsync(int id)
		{
			var query = _db.newsInCategories.Include(r => r.News).Include(r => r.NewsCategory).Where(r => r.News.isDeleted != true);
			var result = from q in query
						 group q by new
						 {
							 q.News.Name,
							 q.News.Id,
							 q.News.Description,
							 q.News.Image,
							 q.News.Content,
							 q.News.Author,
							 q.NewsCategory.Type


						 } into grouped
						 select new NewsMinifly
						 {
							 name = grouped.Key.Name,
							 id = grouped.Key.Id,
							 description = grouped.Key.Description,
							 image = grouped.Key.Image,
							 content = grouped.Key.Content,
							 author = grouped.Key.Author,
							 categoriesName = grouped.Select(r => r.NewsCategory.Name).ToList(),
							 categoriesId = grouped.Select(r => r.NewsCategory.Id).ToList(),
							 categoriestype = grouped.Key.Type,

						 };
			var kq = await result.Where(r => r.id == id).FirstOrDefaultAsync();
			return kq;
		}
		public async Task<NewsMinifly> GetNewsByCategoriesNewsFullDetailAsync(int id)
		{
			var query = _db.newsInCategories.Include(r => r.News).Include(r => r.NewsCategory).Where(r => r.News.isDeleted != true && r.NewsCategory.Id==id);
			var result = from q in query
						 group q by new
						 {
							 q.News.Name,
							 q.News.Id,
							 q.News.Description,
							 q.News.Image,
							 q.News.Content,
							 q.News.Author,
							 q.NewsCategory.Type


						 } into grouped
						 select new NewsMinifly
						 {
							 name = grouped.Key.Name,
							 id = grouped.Key.Id,
							 description = grouped.Key.Description,
							 image = grouped.Key.Image,
							 content = grouped.Key.Content,
							 author = grouped.Key.Author,
							 categoriesName = grouped.Select(r => r.NewsCategory.Name).ToList(),
							 categoriesId = grouped.Select(r => r.NewsCategory.Id).ToList(),
							 categoriestype = grouped.Key.Type,

						 };
			var kq = await result.Where(r => r.id == id).FirstOrDefaultAsync();
			return kq;
		}
		public async Task<List<CountNewsInCategory>> GetCategoriesWithCountNews()
		{
			var query = from cp in _db.newsInCategories
						join c in _db.newsCategories on cp.NewsCategoryID equals c.Id
						group cp by new { c.Id, c.Name } into grouped
						select new CountNewsInCategory
						{
							CategoryId = grouped.Key.Id,
							CategoryName = grouped.Key.Name,
							CountProduct = grouped.Count()
						};
			return await query.ToListAsync();
		}
	}
}
