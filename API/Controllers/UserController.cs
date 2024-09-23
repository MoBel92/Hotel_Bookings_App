using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; // Assuming DTOs are in this namespace
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AddGenericHandler<User, UserCreateDto> _addHandler;
    private readonly UpdateGenericHandler<User, UserUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<User> _deleteHandler;
    private readonly GetGenericHandler<User, UserReadDto> _getHandler;
    private readonly GetListGenericHandler<User, UserReadDto> _getListHandler;

    public UserController(
        AddGenericHandler<User, UserCreateDto> addHandler,
        UpdateGenericHandler<User, UserUpdateDto> updateHandler,
        DeleteGenericHandler<User> deleteHandler,
        GetGenericHandler<User, UserReadDto> getHandler,
        GetListGenericHandler<User, UserReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/User
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _getListHandler.Handle();
        return Ok(users); // Return 200 OK with the list of users
    }

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _getHandler.Handle(id);
        return user != null ? Ok(user) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/User
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserCreateDto dto)
    {
        if (dto == null) return BadRequest("User cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetUser), new { id = dto.Username }, dto); // Adjust based on ID usage
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
    {
        if (id != dto.IdUser) return BadRequest("User ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
