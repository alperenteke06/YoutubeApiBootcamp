using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.ProductDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;

        public ProductsController(ApiContext context, IValidator<Product> validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationRes = _validator.Validate(product);

            if (!validationRes.IsValid)
            {
                return BadRequest(validationRes.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return Ok("Product added successfully");
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);

            _context.Products.Add(value);
            _context.SaveChanges();

            return Ok("Product added successfully");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Product deleted succesfully");
        }

        [HttpGet("GetById")]
        public IActionResult GetProductById(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationRes = _validator.Validate(product);

            if (!validationRes.IsValid)
            {
                return BadRequest(validationRes.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Product updated successfully");
            }
        }
    }
}
