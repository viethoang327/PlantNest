using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
	public class UserController : ControllerBase
	{
		
		private readonly UserManager<CustomerUser> _userManager;
		public UserController( UserManager<CustomerUser> userManager)
		{
			
			_userManager = userManager;
		}
		[HttpGet]
		[Route("GetAllUser")]
		public async Task<IActionResult> GetAllUser()
		{
			var result = await _userManager.Users.ToListAsync();

			return Ok(result);
		}
		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(string userid)
		{
			var result = await _userManager.FindByIdAsync(userid);
			if (result != null)
			{
				await _userManager.DeleteAsync(result);
				return Ok("bạn đã xoá thành công");
			}
			
			return Ok(result);
		}
	}
}
