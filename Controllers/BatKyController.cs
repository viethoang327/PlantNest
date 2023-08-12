using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BatKyController : ControllerBase
	{
		[HttpGet]
		[Route("Test1")]
		public IActionResult Test()
		{
			return Ok("ok");
		}
	}
	
}
