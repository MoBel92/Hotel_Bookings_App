using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; // Assuming DTOs are in this namespace
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly AddGenericHandler<Room, RoomCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Room, RoomUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Room> _deleteHandler;
    private readonly GetGenericHandler<Room, RoomReadDto> _getHandler;
    private readonly GetListGenericHandler<Room, RoomReadDto> _getListHandler;

    public RoomController(
        AddGenericHandler<Room, RoomCreateDto> addHandler,
        UpdateGenericHandler<Room, RoomUpdateDto> updateHandler,
        DeleteGenericHandler<Room> deleteHandler,
        GetGenericHandler<Room, RoomReadDto> getHandler,
        GetListGenericHandler<Room, RoomReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Room
    [HttpGet]
    public async Task<IActionResult> GetRooms() => Ok(await _getListHandler.Handle());

    // GET: api/Room/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(int id)
    {
        var room = await _getHandler.Handle(id);
        return room != null ? Ok(room) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Room
    [HttpPost]
    public async Task<IActionResult> AddRoom([FromBody] RoomCreateDto dto)
    {
        if (dto == null) return BadRequest("Room cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetRoom), new { id = dto.RoomType }, dto); // Adjust ID if necessary
    }

    // PUT: api/Room/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomUpdateDto dto)
    {
        if (id != dto.RoomId) return BadRequest("Room ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Room/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}

