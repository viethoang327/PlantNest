using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using System.Dynamic;

namespace PlantNestApp.Repository
{
	public interface ICart : IBaseRepository<Cart>
	{
		Task<List<Cartminifly>> GetCartMinifyAsync(string userId);
	}
	public class CartRepository : BaseRepository<Cart>, ICart
	{
		public CartRepository(ApplicationDbContext context) : base(context)
		{
		}
		public async Task<List<Cartminifly>> GetCartMinifyAsync(string userId)
		{
			var query = _db.carts.Where(r => r.isDeleted != true);
			var result = from q in _db.carts.Where(r => r.isDeleted != true)
						 join p in _db.products.AsQueryable() on q.ProductID equals p.Id
						 join us in _db.customerUsers.AsQueryable() on q.UserID equals us.Id
						 where us.Id.Equals(userId)
						 select new Cartminifly { 
							  id = q.Id,
							  name = p.Name,
							  userID = us.Id,
							  price = q.Price ,
							 quantity = q.Quantity,
							 totalprice = q.Price * q.Quantity,
							  image = p.Image,

						 };
			var returnValue = await result.ToListAsync();

			return returnValue;
		}




	}
}
