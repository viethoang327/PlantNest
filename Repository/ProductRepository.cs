using PlantNestApp.Data;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IProduct : IBaseRepository<Product>
	{
	}
	public class ProductRepository : BaseRepository<Product>, IProduct
	{
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
