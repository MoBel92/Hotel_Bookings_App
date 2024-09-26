using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs;
using StartMyNewApp.Domain.Models;

namespace StartMyNewApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly AddGenericHandler<Message, MessageCreateDto> _addHandler;
        private readonly GetGenericHandler<Message, MessageReadDto> _getHandler;
        private readonly GetListGenericHandler<Message, MessageReadDto> _getListHandler;
        private readonly UpdateGenericHandler<Message, MessageUpdateDto> _updateHandler;

        public MessageController(
            AddGenericHandler<Message, MessageCreateDto> addHandler,
            GetGenericHandler<Message, MessageReadDto> getHandler,
            GetListGenericHandler<Message, MessageReadDto> getListHandler,
            UpdateGenericHandler<Message, MessageUpdateDto> updateHandler)
        {
            _addHandler = addHandler;
            _getHandler = getHandler;
            _getListHandler = getListHandler;
            _updateHandler = updateHandler;
        }

        // GET: api/Message
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _getListHandler.Handle();
            return Ok(messages);
        }

        // GET: api/Message/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var message = await _getHandler.Handle(id);
            return message != null ? Ok(message) : NotFound();
        }

        // POST: api/Message
        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody] MessageCreateDto dto)
        {
            if (dto == null) return BadRequest("Message data cannot be null.");
            await _addHandler.Handle(dto);
            return CreatedAtAction(nameof(GetMessage), new { id = dto.SenderId }, dto);
        }

        // PUT: api/Message/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] MessageUpdateDto dto)
        {
            if (id != dto.MessageId) return BadRequest("Message ID mismatch.");
            await _updateHandler.Handle(dto);
            return NoContent();
        }
    }
}

