﻿using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs;
using StartMyNewApp.Domain.Models;
using System.Threading.Tasks;

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
        try
        {
            var users = await _getListHandler.Handle();
            return Ok(users);
        }
        catch (Exception ex)
        {
            // Log the exception here if needed
            return StatusCode(500, "An error occurred while fetching users.");
        }
    }

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _getHandler.Handle(id);
            return user != null ? Ok(user) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while fetching the user.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserCreateDto dto)
    {
        if (dto == null) return BadRequest("User cannot be null");

        try
        {
            // Get the created user's ID from the handler
            var createdUserId = await _addHandler.Handle(dto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUserId }, dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while adding the user.");
        }
    }


    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
    {
        if (id != dto.IdUser) return BadRequest("User ID mismatch");

        try
        {
            await _updateHandler.Handle(dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while updating the user.");
        }
    }

    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _deleteHandler.Handle(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while deleting the user.");
        }
    }
}

