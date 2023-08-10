using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface INewInCate : IBaseRepository<NewsInCategory>
	{
	}
	public class NewInCategoryRepository : BaseRepository<NewsInCategory>, INewInCate
	{
		public NewInCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
