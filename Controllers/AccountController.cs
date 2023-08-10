﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNestApp.Models;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountRepository _accountRepository;
		public AccountController(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
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
	}
}
