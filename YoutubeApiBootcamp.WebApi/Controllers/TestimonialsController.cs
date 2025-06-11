using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly ApiContext _context;

		public TestimonialsController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateTestimonial(Testimonial testimonial)
		{
			_context.Testimonials.Add(testimonial);
			_context.SaveChanges();

			return Ok("Testimonial Added Succesfully");
		}

		[HttpGet]
		public IActionResult GetTestimonials()
		{
			var values = _context.Testimonials.ToList();

			return Ok(values);
		}

		[HttpDelete]
		public IActionResult DeleteTestimonial(int testimonialId)
		{
			var deletedTestimonial = _context.Testimonials.Find(testimonialId);
			_context.Testimonials.Remove(deletedTestimonial);
			_context.SaveChanges();

			return Ok("Testimonial Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetTestimonialById(int id)
		{
			var Testimonial = _context.Testimonials.Find(id);

			return Ok(Testimonial);
		}

		[HttpPut]
		public IActionResult UpdateTestimonial(Testimonial testimonial)
		{
			_context.Testimonials.Update(testimonial);
			_context.SaveChanges();

			return Ok("Testimonial Updated Succesfully");
		}
	}
}
