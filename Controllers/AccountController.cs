using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository _accountRepository;
		private readonly UserManager<CustomerUser> _userManager;
		public AccountController(IAccountRepository accountRepository, UserManager<CustomerUser> userManager)
		{
			_accountRepository = accountRepository;
			_userManager = userManager;
		}
		[HttpPost]
		[Route("SignUp")]
		public async Task<IActionResult> SignUp(SingUp singUp)
		{
			var result = await _accountRepository.SingUpAsync(singUp);
			if (result.Succeeded)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest("Error");
			}

		}
		[HttpPost]
		[Route("SignIn")]
		public async Task<IActionResult> SignIn(SingIn singIn)
		{
			var result = await _accountRepository.SingInAsync(singIn);
			if (string.IsNullOrEmpty(result))
			{
				return Ok(result);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		[Route("SignOut")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return Ok("Đã logout thành công.");
		}
		[HttpDelete]
		[Route("DeleteRole")]
		public async Task<IActionResult> Delete()
		{
			var result = await _accountRepository.DeleteRole();
			return Ok("xoa quyen thanh cong");
		}
		[HttpPost]
		[Route("AddQuyen ")]

		public async Task<IActionResult> AddRoles(SingUp singUp)
		{
			var result = await _accountRepository.SingUpAsyncss(singUp);
			return Ok("Add thanh cong");

		}
		
	}
}
