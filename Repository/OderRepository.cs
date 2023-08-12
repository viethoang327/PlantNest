using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IOder : IBaseRepository<Order>
	{
		Task<List<OrderDetail>> GetOderMinifyAsync(int orderId);
	}
	public class OderRepository : BaseRepository<Order>, IOder
	{
		public OderRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<OrderDetail>> GetOderMinifyAsync(int orderId)
		{

		//	var query = _db.ordersDetail.Where(r => r.isDeleted != true);
			var query = _db.ordersDetail.Include(r => r.Order).Include(r => r.Product).Where(r => r.Product.isDeleted != true && r.OrderID == orderId);
			return await query.ToListAsync();
		}
		//public async Task<List<OderMinifile>> GetOderMinifyAsync()
		//{

		//}
	}
}
