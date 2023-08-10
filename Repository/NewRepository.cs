using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using System.Linq.Expressions;

namespace PlantNestApp.Repository
{
	public interface INew : IBaseRepository<News>
	{
	}
	public class NewRepository : BaseRepository<News>, INew
	{
		public NewRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
