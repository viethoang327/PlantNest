using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IOderDetail : IBaseRepository<OrderDetail>
	{
	}
	public class OderDetailRepopsitory : BaseRepository<OrderDetail>, IOderDetail
	{
		public OderDetailRepopsitory(ApplicationDbContext context) : base(context)
		{
		}
	}
}
