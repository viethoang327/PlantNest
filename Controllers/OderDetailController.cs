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
	public class OderDetailController : BaseController<OrderDetail>
	{
		private readonly IOderDetail _OderDetailRepository;
		public OderDetailController(IOderDetail OderDetailRepository,ApplicationDbContext context, IBaseRepository<OrderDetail> BaseRepository) : base(context, BaseRepository)
		{
			_OderDetailRepository= OderDetailRepository;
		}
		[HttpPost]
		[Route("pagingcomparison")]
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


			var result = _OderDetailRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.Order.Code.ToLower().Contains(search.ToLower())
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
