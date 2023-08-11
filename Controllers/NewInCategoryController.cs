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
	public class NewInCategoryController : BaseController<NewsInCategory>
	{
		private readonly INewInCate _NewInCateRepository;
		public NewInCategoryController(INewInCate NewInCateRepository, ApplicationDbContext context, IBaseRepository<NewsInCategory> BaseRepository) : base(context, BaseRepository)
		{
			_NewInCateRepository = NewInCateRepository;

		}
		[HttpPost]
		[Route("DataTableAjaxRespone")]
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


			var result = _NewInCateRepository.BuildResponseForDataTableLibrary(
				r => (string.IsNullOrEmpty(search)) || (
					(!string.IsNullOrEmpty(search)) && (
						r.News.Name.ToLower().Contains(search.ToLower())
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
		[Route("LayCateNew")]
		public async Task<IActionResult> LayCAteNew(int newId)
		{
			var result = await _NewInCateRepository.GetCategoryNewByNewId(newId);
			return Ok(result);
		}
	}
}
