using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs;
using StartMyNewApp.Domain.Models;

namespace StartMyNewApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly AddGenericHandler<Notification, NotificationCreateDto> _addHandler;
        private readonly UpdateGenericHandler<Notification, NotificationUpdateDto> _updateHandler;
        private readonly DeleteGenericHandler<Notification> _deleteHandler;
        private readonly GetGenericHandler<Notification, NotificationReadDto> _getHandler;
        private readonly GetListGenericHandler<Notification, NotificationReadDto> _getListHandler;

        public NotificationController(
            AddGenericHandler<Notification, NotificationCreateDto> addHandler,
            UpdateGenericHandler<Notification, NotificationUpdateDto> updateHandler,
            DeleteGenericHandler<Notification> deleteHandler,
            GetGenericHandler<Notification, NotificationReadDto> getHandler,
            GetListGenericHandler<Notification, NotificationReadDto> getListHandler)
        {
            _addHandler = addHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getHandler = getHandler;
            _getListHandler = getListHandler;
        }

        // GET: api/Notification
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _getListHandler.Handle();
            return Ok(notifications); // Return 200 OK with the list of notifications
        }

        // GET: api/Notification/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var notification = await _getHandler.Handle(id);
            return notification != null ? Ok(notification) : NotFound(); // Return 200 OK or 404 Not Found
        }

        // POST: api/Notification
        [HttpPost]
        public async Task<IActionResult> AddNotification([FromBody] NotificationCreateDto dto)
        {
            if (dto == null) return BadRequest("Notification data cannot be null");
            await _addHandler.Handle(dto);
            return CreatedAtAction(nameof(GetNotification), new { id = dto.UserId }, dto); // Adjust based on ID usage
        }

        // PUT: api/Notification/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] NotificationUpdateDto dto)
        {
            if (id != dto.NotificationId) return BadRequest("Notification ID mismatch"); // Return 400 Bad Request
            await _updateHandler.Handle(dto);
            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/Notification/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _deleteHandler.Handle(id);
            return NoContent(); // Return 204 No Content
        }
    }
}
