using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Commands;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AddGenericHandler<User> _addHandler;
    private readonly UpdateGenericHandler<User> _updateHandler;
    private readonly DeleteGenericHandler<User> _deleteHandler;
    private readonly GetGenericHandler<User> _getHandler;
    private readonly GetListGenericHandler<User> _getListHandler;

    public UserController(
        AddGenericHandler<User> addHandler,
        UpdateGenericHandler<User> updateHandler,
        DeleteGenericHandler<User> deleteHandler,
        GetGenericHandler<User> getHandler,
        GetListGenericHandler<User> getListHandler)
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
        if (user == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(user);
    }

    // POST: api/User
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
    {
        var user = new User
        {
            Username = command.Username,
            Name = command.Name,
            Email = command.Email,
            Password = command.Password,
            PhoneNumber = command.PhoneNumber
        };

        await _addHandler.Handle(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.IdUser }, user); // Return 201 Created
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.IdUser)
        {
            return BadRequest("User ID mismatch"); // Return 400 Bad Request
        }

        var user = new User
        {
            IdUser = command.IdUser,
            Username = command.Username,
            Name = command.Name,
            Email = command.Email,
            Password = command.Password,
            PhoneNumber = command.PhoneNumber
        };

        await _updateHandler.Handle(user);
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
