using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductInCategoryController : BaseController<CategoryInProduct>
	{
		private readonly ICategoryInProductRepository _ProductInCategoryRepository;
		public ProductInCategoryController(ICategoryInProductRepository ProductInCategoryRepository,ApplicationDbContext context, IBaseRepository<CategoryInProduct> BaseRepository) : base(context, BaseRepository)
		{
			_ProductInCategoryRepository= ProductInCategoryRepository;
		}
		[HttpPost]
		[Route("paging")]
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


			var result = _ProductInCategoryRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.Product.Name.ToLower().Contains(search.ToLower())
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
	}
}
