using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; 
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class AmenityController : ControllerBase
{
    private readonly AddGenericHandler<Amenity, AmenityCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Amenity, AmenityUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Amenity> _deleteHandler;
    private readonly GetGenericHandler<Amenity, AmenityReadDto> _getHandler;
    private readonly GetListGenericHandler<Amenity, AmenityReadDto> _getListHandler;

    public AmenityController(
        AddGenericHandler<Amenity, AmenityCreateDto> addHandler,
        UpdateGenericHandler<Amenity, AmenityUpdateDto> updateHandler,
        DeleteGenericHandler<Amenity> deleteHandler,
        GetGenericHandler<Amenity, AmenityReadDto> getHandler,
        GetListGenericHandler<Amenity, AmenityReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Amenity
    [HttpGet]
    public async Task<IActionResult> GetAmenities() => Ok(await _getListHandler.Handle());

    // GET: api/Amenity/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAmenity(int id)
    {
        var amenity = await _getHandler.Handle(id);
        return amenity != null ? Ok(amenity) : NotFound();
    }

    // POST: api/Amenity
    [HttpPost]
    public async Task<IActionResult> AddAmenity([FromBody] AmenityCreateDto dto)
    {
        if (dto == null) return BadRequest("Amenity cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetAmenity), new { id = dto.Name }, dto); // Adjust based on primary key use
    }

    // PUT: api/Amenity/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAmenity(int id, [FromBody] AmenityUpdateDto dto)
    {
        if (id != dto.AmenityId) return BadRequest("Amenity ID mismatch");
        await _updateHandler.Handle(dto);
        return NoContent();
    }

    // DELETE: api/Amenity/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAmenity(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}

