using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : Controller
	{
		private readonly ApiContext _context;

		public ServicesController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateService(Service service)
		{
			_context.Services.Add(service);
			_context.SaveChanges();

			return Ok("Service Added Succesfully");
		}

		[HttpGet]
		public IActionResult GetServices()
		{
			var values = _context.Services.ToList();

			return Ok(values);
		}

		[HttpDelete]
		public IActionResult DeleteService(int serviceId)
		{
			var deletedService = _context.Services.Find(serviceId);
			_context.Services.Remove(deletedService);
			_context.SaveChanges();

			return Ok("Service Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetServiceById(int id)
		{
			var service = _context.Services.Find(id);

			return Ok(service);
		}

		[HttpPut]
		public IActionResult UpdateService(Service service)
		{
			_context.Services.Update(service);
			_context.SaveChanges();

			return Ok("Service Updated Succesfully");
		}
	}
}
