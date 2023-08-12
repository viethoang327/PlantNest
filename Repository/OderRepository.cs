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
		public async Task<List<OderMinifile>> GetOderMinifyAsync()
		{
			var query = _db.ordersDetail.Include(r => r.Order).ThenInclude(r => r.customerUser).Where(r => r.Order.isDeleted != true);
			var result = from q in query
						 let customerId = q.Order.customerUser.Id
						 group q by new
						 {
							 q.Order.Id,
							 customerId,
							 q.Order.Code,
							 q.Order.Address,
							 q.Order.Phone,
							 q.Order.TotalMoney,
							 
							
							

						 } into grouped
						 select new OderMinifile
						 {
							
							 id = grouped.Key.Id,
							 userID = grouped.Key.customerId,
							 code = grouped.Key.Code,
							 address = grouped.Key.Address,
							 phone= grouped.Key.Phone,
							 totalMoney = grouped.Key.TotalMoney,
							 

						 };
			return await result.ToListAsync();
		}
	}
}
