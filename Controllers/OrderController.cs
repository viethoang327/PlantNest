using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Models;
using PlantNestApp.Repository;
using PlantNestApp.Models;
using PlantNestApp.DataTransferObject.UserDTO;

namespace PlantNestApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
	public class OrderController : BaseController<Models.Order>
	{
		private readonly IOder _OderRepository;
		public OrderController(IOder OderRepository,ApplicationDbContext context, IBaseRepository<Models.Order> BaseRepository) : base(context, BaseRepository)
		{
			_OderRepository = OderRepository;
		}
		[HttpPost]
		[Route("pagingfilter")]
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


			var result = _OderRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.Code.ToLower().Contains(search.ToLower())
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
		[Route("GetOderMinifyAsync")]
		public async Task<IActionResult> GetOderMinifyAsync()
		{
			var result = await _OderRepository.GetOderMinifyAsync();
			return Ok(result);
		}
	}
}
