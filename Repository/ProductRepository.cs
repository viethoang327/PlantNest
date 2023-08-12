using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;

namespace PlantNestApp.Repository
{
	public interface IProduct : IBaseRepository<Product>
	{
		Task<List<ProductMinify>> GetProductMinifyAsync();
		Task<ProductMinify> GetProductByIdFullDetailAsync(int id);
		Task<List<Product>> GetproductBycategoriesAsync(int id);
		Task<List<CountProductInCategory>> GetCategoriesWithCountProduct();

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

		public async Task<ProductMinify> GetProductByIdFullDetailAsync(int id)
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
			var kq = await result.Where(r => r.id == id).FirstOrDefaultAsync();
			return kq;
		}
		public async Task<List<Product>> GetproductBycategoriesAsync(int id)
		{
			var result = from p in _db.products
						 join cp in _db.categoryInProducts on p.Id equals cp.ProductID
						 join c in _db.categories on cp.CategoryID equals c.Id
						 where c.Id == id
						 select p;

			//var kieuInclude = _db.categoryInProducts.Include(r => r.Category).Include(r => r.Product).Where(r => r.CategoryID == id).Select(r => r.Product);

			return await result.ToListAsync();
		}

		public async Task<List<CountProductInCategory>> GetCategoriesWithCountProduct()
		{
			var query = from cp in _db.categoryInProducts
						join c in _db.categories on cp.CategoryID equals c.Id
						group cp by new { c.Id, c.Name/*, c.Image*/ } into grouped
						select new CountProductInCategory
						{
							CategoryId = grouped.Key.Id,
							CategoryName = grouped.Key.Name,
							CountProduct = grouped.Count()
						};
			return await query.ToListAsync();
		}
	}
}
