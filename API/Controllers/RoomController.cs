using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly AddGenericHandler<Room> _addHandler;
    private readonly UpdateGenericHandler<Room> _updateHandler;
    private readonly DeleteGenericHandler<Room> _deleteHandler;
    private readonly GetGenericHandler<Room> _getHandler;
    private readonly GetListGenericHandler<Room> _getListHandler;

    public RoomController(AddGenericHandler<Room> addHandler,
                          UpdateGenericHandler<Room> updateHandler,
                          DeleteGenericHandler<Room> deleteHandler,
                          GetGenericHandler<Room> getHandler,
                          GetListGenericHandler<Room> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms() => Ok(await _getListHandler.Handle());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(int id)
    {
        var room = await _getHandler.Handle(id);
        return room != null ? Ok(room) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddRoom([FromBody] Room room)
    {
        if (room == null) return BadRequest("Room cannot be null");
        await _addHandler.Handle(room);
        return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room room)
    {
        if (id != room.RoomId) return BadRequest("Room ID mismatch");
        await _updateHandler.Handle(room);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}

