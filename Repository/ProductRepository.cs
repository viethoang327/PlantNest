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
			var query = _db.categoryInProducts.Include(r => r.Product).Include(r => r.Category).Where(r => r.Product.isDeleted != true);
			var result = from q in query
						 group q by new
						 {
							 q.Product.Name,
							 q.Product.Id,
							 q.Product.Description,
							 q.Product.Image,
							 q.Product.Price,
							 q.Product.Quantity,
							 q.Category.Type,
							 q.Product.Rating,
							 q.Product.DiscountPercentage

						 } into grouped
						 select new ProductMinify
						 {
							 title = grouped.Key.Name,
							 id = grouped.Key.Id,
							 description = grouped.Key.Description,
							 image = grouped.Key.Image,
							 price = grouped.Key.Price,
							 quantity = grouped.Key.Quantity,
							 priceAfterDiscount = grouped.Key.Price * grouped.Key.DiscountPercentage / 100,
							 rating = grouped.Key.Rating,
							 discountPercentage = grouped.Key.DiscountPercentage,
							 categoriesName = grouped.Select(r => r.Category.Name).ToList(),
							 categoriesId = grouped.Select(r => r.Category.Id).ToList(),
							 categoriesType = grouped.Key.Type,
							
						 };
			return await result.ToListAsync();
		}
	}
}
