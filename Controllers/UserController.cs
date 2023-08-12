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
		private readonly RoleManager<IdentityRole> _roleManager;
		public UserController( UserManager<CustomerUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			
			_userManager = userManager;
			_roleManager = roleManager;
		}
		[HttpGet]
		[Route("GetAllUser")]
		public async Task<IActionResult> GetAllUser()
		{
			var users = await _userManager.Users.ToListAsync();
			var usersWithRoles = new List<object>();

			foreach (var user in users)
			{
				var roles = await _userManager.GetRolesAsync(user);

				var userWithRoles = new
				{
					user,
					Roles = roles.ToList()
				};

				usersWithRoles.Add(userWithRoles);
			}


			return Ok(usersWithRoles);
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
