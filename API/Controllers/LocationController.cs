using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Commands;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly AddGenericHandler<Location> _addHandler;
    private readonly UpdateGenericHandler<Location> _updateHandler;
    private readonly DeleteGenericHandler<Location> _deleteHandler;
    private readonly GetGenericHandler<Location> _getHandler;
    private readonly GetListGenericHandler<Location> _getListHandler;

    public LocationController(
        AddGenericHandler<Location> addHandler,
        UpdateGenericHandler<Location> updateHandler,
        DeleteGenericHandler<Location> deleteHandler,
        GetGenericHandler<Location> getHandler,
        GetListGenericHandler<Location> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Location
    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await _getListHandler.Handle();
        return Ok(locations); // Return 200 OK with the list of locations
    }

    // GET: api/Location/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var location = await _getHandler.Handle(id);
        if (location == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(location);
    }

    // POST: api/Location
    [HttpPost]
    public async Task<IActionResult> AddLocation([FromBody] AddLocationCommand command)
    {
        var location = new Location
        {
            LocationName = command.LocationName
        };

        await _addHandler.Handle(location);
        return CreatedAtAction(nameof(GetLocation), new { id = location.IdLocation }, location); // Return 201 Created
    }

    // PUT: api/Location/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationCommand command)
    {
        if (id != command.IdLocation)
        {
            return BadRequest("Location ID mismatch"); // Return 400 Bad Request
        }

        var location = new Location
        {
            IdLocation = command.IdLocation,
            LocationName = command.LocationName
        };

        await _updateHandler.Handle(location);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Location/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
