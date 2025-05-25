using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ChefsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetChefList()
		{
			var values = _context.Chefs.ToList();

			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateChef(Chef chef)
		{
			_context.Chefs.Add(chef);
			_context.SaveChanges();

			return Ok("Chef Added Succesfully");
		}

		[HttpDelete]
		public IActionResult DeleteChef(int chefId)
		{
			var deletedChef = _context.Chefs.Find(chefId);
			_context.Chefs.Remove(deletedChef);
			_context.SaveChanges();

			return Ok("Chef Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetChefById(int id)
		{
			return Ok(_context.Chefs.Find(id));
		}

		[HttpPut]
		public IActionResult UpdateChef(Chef chef)
		{
			_context.Chefs.Update(chef);
			_context.SaveChanges();

			return Ok("Chef Updated Succesfully");
		}
	}
}
