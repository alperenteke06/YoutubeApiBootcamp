using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class YummyEventsController : ControllerBase
	{
		private readonly ApiContext _context;

		public YummyEventsController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateYummyEvent(YummyEvent yummyEvent)
		{
			_context.YummyEvents.Add(yummyEvent);
			_context.SaveChanges();

			return Ok("Event Added Succesfully");
		}

		[HttpGet]
		public IActionResult GetYummyEvents()
		{
			var values = _context.YummyEvents.ToList();

			return Ok(values);
		}

		[HttpDelete]
		public IActionResult DeleteYummyEvent(int yummyEventId)
		{
			var deletedYummyEvent = _context.YummyEvents.Find(yummyEventId);
			_context.YummyEvents.Remove(deletedYummyEvent);
			_context.SaveChanges();

			return Ok("Event Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetYummyEventById(int id)
		{
			var yummyEvent = _context.YummyEvents.Find(id);

			return Ok(yummyEvent);
		}

		[HttpPut]
		public IActionResult UpdateYummyEvent(YummyEvent yummyEvent)
		{
			_context.YummyEvents.Update(yummyEvent);
			_context.SaveChanges();

			return Ok("Event Updated Succesfully");
		}
	}
}
