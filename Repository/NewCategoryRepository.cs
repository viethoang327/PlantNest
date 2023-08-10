using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface INewCate : IBaseRepository<NewsCategory>
	{
	}
	public class NewCategoryRepository : BaseRepository<NewsCategory>, INewCate
	{
		public NewCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
