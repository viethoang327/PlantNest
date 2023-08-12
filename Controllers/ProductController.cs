using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class ProductController : BaseController<Models.Product>
	{
		private readonly IProduct _ProductRepository;
		public ProductController(IProduct ProductRepository, ApplicationDbContext context, IBaseRepository<Models.Product> BaseRepository) : base(context, BaseRepository)
		{
			_ProductRepository = ProductRepository;
		}
		[HttpPost]
		[Route("comparison")]
		public async Task<IActionResult> DataTableAjaxRespone(DataTableAjaxPostModel postModel)
		{

			var search = "";
			if (postModel.search != null)
			{
				search = postModel.search.value;
			}


			var columName = "id";
			var columASC = false;

			if (postModel.order != null)
			{
				columName = postModel.columns[postModel.order[0].column].name;
				if (postModel.order[0].dir.Equals("asc"))
				{
					columASC = true;
				}
				if (postModel.order[0].dir.Equals("desc"))
				{
					columASC = false;
				}
			}

			var start = postModel.start;
			var length = postModel.length;


			var result = _ProductRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.Name.ToLower().Contains(search.ToLower())
					)
				),
				columName,
				columASC,
				start,
				postModel.draw,
				length


				);
			return Ok(result);
		}

		[HttpGet]
		[Route("GetAllProductMinify")]
		public async Task<IActionResult> GetAllProductMinify()
		{
			var result = await _ProductRepository.GetProductMinifyAsync();
			return Ok(result);
		}
		[HttpGet]
		[Route("GetProductByIdFullDetailAsync")]
		public async Task<IActionResult> GetProductByIdDetailAsync(int id)
		{
			var result = await _ProductRepository.GetProductByIdFullDetailAsync(id);
			return Ok(result);
		}
		[HttpGet]
		[Route("GetProductBycategories")]
		public async Task<IActionResult> GetProductBycategories(int categoryId)
		{
			var result = await _ProductRepository.GetproductBycategoriesAsync(categoryId);
			return Ok(result);
		}
		[HttpGet]
		[Route("Getquantityproductbycategories")]
		public async Task<IActionResult> Getquantityproductbycategories()
		{
			var result = await _ProductRepository.GetCategoriesWithCountProduct();
			return Ok(result);
		}
	}
}
