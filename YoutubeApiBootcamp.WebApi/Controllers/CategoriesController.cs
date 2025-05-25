using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;

		public CategoriesController(ApiContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();

			return Ok("Category Added Succesfully");
		}

		[HttpGet]
		public IActionResult GetCategories()
		{
			var values = _context.Categories.ToList();

			return Ok(values);
		}

		[HttpDelete]
		public IActionResult DeleteCategory(int categoryId)
		{
			var deletedCategory = _context.Categories.Find(categoryId);
			_context.Categories.Remove(deletedCategory);
			_context.SaveChanges();

			return Ok("Category Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetCategoryById(int id)
		{
			var category = _context.Categories.Find(id);

			return Ok(category);
		}

		[HttpPut]
		public IActionResult UpdateCategory(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();

			return Ok("Category Updated Succesfully");
		}
	}
}
