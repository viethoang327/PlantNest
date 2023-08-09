﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlantNestApp.Data;
using PlantNestApp.DataTransferObject;
using PlantNestApp.Repository;

namespace PlantNestApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController<T> : ControllerBase where T : class
	{
		private IBaseRepository<T> _BaseRepository;
		private ApplicationDbContext _context;
		public BaseController(ApplicationDbContext context, IBaseRepository<T> BaseRepository)
		{
			_context = context;
			_BaseRepository = BaseRepository;
		}

		[HttpGet]
		public async Task< IActionResult > Create(T entity)
		{
			var result = await _BaseRepository.CreteAsync(entity);

			if (result != null )
			{
				return Ok(result);

			}
			else 
			{
				return BadRequest("Error");
			}

			
		}
		[HttpPut]
		public async Task<IActionResult> Update(T entity)
		{
			var result = await _BaseRepository.UpdateAsync(entity);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest("Error");
			}
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _BaseRepository.DeleteAsync(id);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest("Error");
			}
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _BaseRepository.GetAllAsync();
			if(result != null)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest("Error");
			}
		}










		}
}
