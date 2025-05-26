using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.FeatureDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFeatures()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);

            _context.Features.Add(values);
            _context.SaveChanges();

            return Ok("Feature Added Succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var deletedValue = _context.Features.Find(id);

            _context.Features.Remove(deletedValue);

            return Ok("Feature deleted succesfully");
        }

        [HttpGet("GetById")]
        public IActionResult GetFeatureById(int id)
        {
            var value = _context.Features.Find(id);
            
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);

            _context.Features.Update(value);
            _context.SaveChanges();

            return Ok("Feature updated successfully");
        }
    }
}
