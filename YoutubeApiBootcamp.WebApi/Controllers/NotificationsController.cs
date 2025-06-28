using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApiBootcamp.WebApi.Context;
using YoutubeApiBootcamp.WebApi.Dtos.NotificationDtos;
using YoutubeApiBootcamp.WebApi.Entities;

namespace YoutubeApiBootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public NotificationsController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNotifications()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var values = _mapper.Map<Notification>(createNotificationDto);

            _context.Notifications.Add(values);
            _context.SaveChanges();

            return Ok("Notification Added Succesfully");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var deletedValue = _context.Notifications.Find(id);

            _context.Notifications.Remove(deletedValue);

            return Ok("Notification deleted succesfully");
        }

        [HttpGet("GetById")]
        public IActionResult GetNotificationById(int id)
        {
            var value = _context.Notifications.Find(id);

            return Ok(_mapper.Map<GetNotificationByIdDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);

            _context.Notifications.Update(value);
            _context.SaveChanges();

            return Ok("Notification updated successfully");
        }
    }
}
