using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IOder : IBaseRepository<Order>
	{
		Task<List<OderMinifile>> GetOderMinifyAsync();
	}
	public class OderRepository : BaseRepository<Order>, IOder
	{
		public OderRepository(ApplicationDbContext context) : base(context)
		{
		}

		public Task<List<OderMinifile>> GetOderMinifyAsync()
		{
			throw new NotImplementedException();
		}
		//public async Task<List<OderMinifile>> GetOderMinifyAsync()
		//{

		//}
	}
}
