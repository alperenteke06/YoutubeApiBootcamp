using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.CategoryDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var value = _mapper.Map<Category>(createCategoryDto);

			_context.Categories.Add(value);
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
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
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
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
            var value = _mapper.Map<Category>(updateCategoryDto);

            _context.Categories.Update(value);
			_context.SaveChanges();

			return Ok("Category Updated Succesfully");
		}
	}
}
