using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.MessageDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public ContactMessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactMessages()
        {
            var values = _context.ContactMessages.ToList();

            return Ok(_mapper.Map<List<ResultContactMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateContactMessage(CreateContactMessageDto createContactMessageDto)
        {
            var value = _mapper.Map<ContactMessage>(createContactMessageDto);

            _context.ContactMessages.Add(value);
            _context.SaveChanges();

            return Ok("Contact Message added successfully");
        }

        [HttpDelete]
        public IActionResult DeleteContactMessage(int id)
        {
            var value = _context.ContactMessages.Find(id);

            _context.ContactMessages.Remove(value);
            _context.SaveChanges();

            return Ok("Contact Message deleted successfully");
        }

        [HttpGet("GetById")]
        public IActionResult GetContactMessageById(int id)
        {
            var value = _context.ContactMessages.Find(id);

            return Ok(_mapper.Map<GetByIdContactMessageDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateContactMessage(UpdateContactMessageDto updateContactMessageDto)
        {
            var value = _mapper.Map<ContactMessage>(updateContactMessageDto);

            _context.ContactMessages.Update(value);
            _context.SaveChanges();

            return Ok("Contact Message updated successfully");
        }
    }
}
