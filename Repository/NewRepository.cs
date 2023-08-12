using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using System.Linq.Expressions;

namespace PlantNestApp.Repository
{
	public interface INew : IBaseRepository<News>
	{
		Task<List<NewsMinifly>> GetNewsMinifyAsync();
		Task<NewsMinifly> GetNewsByIdFullDetailAsync(int id);
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
	}
}
