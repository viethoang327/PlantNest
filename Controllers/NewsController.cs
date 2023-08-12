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
	public class NewsController : BaseController<News>
	{
		private readonly INew _NewRepository;
		public NewsController(INew NewRepository,ApplicationDbContext context, IBaseRepository<News> BaseRepository) : base(context, BaseRepository)
		{
			_NewRepository = NewRepository;
		}
		[HttpPost]
		[Route("search")]
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


			var result = _NewRepository.BuildResponseForDataTableLibrary(
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
		[Route("GetAllNewsMinify")]
		public async Task<IActionResult> GetAllNewsMinify()
		{
			var result = await _NewRepository.GetNewsMinifyAsync();
			return Ok(result);
		}
		[HttpGet]
		[Route("GetNewsByIdFullDetailAsync")]
		public async Task<IActionResult> GetNewsByIdDetailAsync(int id)
		{
			var result = await _NewRepository.GetNewsByIdFullDetailAsync(id);
			return Ok(result);
		}
	}
}
