using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IOder : IBaseRepository<Order>
	{
	}
	public class OderRepository : BaseRepository<Order>, IOder
	{
		public OderRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
