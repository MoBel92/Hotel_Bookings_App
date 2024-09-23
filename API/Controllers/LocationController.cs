using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; // Assuming DTOs are in this namespace
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly AddGenericHandler<Location, LocationCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Location, LocationUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Location> _deleteHandler;
    private readonly GetGenericHandler<Location, LocationReadDto> _getHandler;
    private readonly GetListGenericHandler<Location, LocationReadDto> _getListHandler;

    public LocationController(
        AddGenericHandler<Location, LocationCreateDto> addHandler,
        UpdateGenericHandler<Location, LocationUpdateDto> updateHandler,
        DeleteGenericHandler<Location> deleteHandler,
        GetGenericHandler<Location, LocationReadDto> getHandler,
        GetListGenericHandler<Location, LocationReadDto> getListHandler)
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
        return location != null ? Ok(location) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Location
    [HttpPost]
    public async Task<IActionResult> AddLocation([FromBody] LocationCreateDto dto)
    {
        if (dto == null) return BadRequest("Location cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetLocation), new { id = dto.LocationName }, dto); // Adjust based on ID usage
    }

    // PUT: api/Location/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationUpdateDto dto)
    {
        if (id != dto.IdLocation) return BadRequest("Location ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
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
