using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Data;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : BaseController<Cart>
	{
		public readonly ICart _CartRepository;
		public CartController(ICart CartRepository,ApplicationDbContext context, IBaseRepository<Cart> BaseRepository) : base(context, BaseRepository)
		{
			_CartRepository= CartRepository;
		}

		[HttpGet]
		[Route("GetAllCart")]
		public async Task<IActionResult> GetAllCart(string userId)
		{
			var result = await _CartRepository.GetCartMinifyAsync(userId);
			return Ok(result);
		}
	}
}
