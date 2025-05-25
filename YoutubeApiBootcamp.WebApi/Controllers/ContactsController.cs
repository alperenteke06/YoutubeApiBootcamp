using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.ContactDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ContactsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetContacts()
		{
			var values = _context.Contacts.ToList();

			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateContacts(CreateContactDto createContactDto)
		{
			Contact contact = new Contact();

			contact.Email = createContactDto.Email;
			contact.Address = createContactDto.Address;
			contact.Phone = createContactDto.Phone;
			contact.MapLocation = createContactDto.MapLocation;
			contact.OpenHours = createContactDto.OpenHours;

			_context.Contacts.Add(contact);
			_context.SaveChanges();

			return Ok("Contact Added Succesfully");
		}

		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			var value = _context.Contacts.Find(id);

			_context.Contacts.Remove(value);
			_context.SaveChanges();

			return Ok("Contact Deleted Succesfully");
		}

		[HttpGet("GetById")]
		public IActionResult GetContactById(int id)
		{
			var value = _context.Contacts.Find(id);

			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			Contact contact = new Contact();

			contact.Email = updateContactDto.Email;
			contact.Address = updateContactDto.Address;
			contact.Phone = updateContactDto.Phone;
			contact.ContactId = updateContactDto.ContactId;
			contact.MapLocation = updateContactDto.MapLocation;
			contact.OpenHours = updateContactDto.OpenHours;

			_context.Contacts.Update(contact);
			_context.SaveChanges();

			return Ok("Contact Updated Succesfully");
		}
	}
}
