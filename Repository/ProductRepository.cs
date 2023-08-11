using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IProduct : IBaseRepository<Product>
	{
		Task<List<ProductMinify>> GetProductMinifyAsync();
	}
	public class ProductRepository : BaseRepository<Product>, IProduct
	{
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<ProductMinify>> GetProductMinifyAsync()
		{
			var query = _db.categoryInProducts.Include(r => r.Product).Include(r => r.Category);
			var result = from q in query
						 group q by new
						 {
							 q.Product.Name,
							 q.Product.Id,
							 q.Product.Description,
							 q.Product.Image,
							 q.Product.Price,
							 q.Product.Quantity,
						 } into grouped
						 select new ProductMinify
						 {
							 title = grouped.Key.Name,
							 id = grouped.Key.Id,
							 description = grouped.Key.Description,
							 image = grouped.Key.Image,
							 price = grouped.Key.Price,
							 quantity = grouped.Key.Quantity,
							 priceAfterDiscount = grouped.Key.Price * 90 / 100,
							 discountPercentage = 10,
							 rating = 5,
							 categoriesName = grouped.Select(r => r.Category.Name).ToList()
						 };
			return await result.ToListAsync();
		}
	}
}
