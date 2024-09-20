using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class AmenityController : ControllerBase
{
    private readonly AddGenericHandler<Amenity> _addHandler;
    private readonly UpdateGenericHandler<Amenity> _updateHandler;
    private readonly DeleteGenericHandler<Amenity> _deleteHandler;
    private readonly GetGenericHandler<Amenity> _getHandler;
    private readonly GetListGenericHandler<Amenity> _getListHandler;

    public AmenityController(AddGenericHandler<Amenity> addHandler,
                             UpdateGenericHandler<Amenity> updateHandler,
                             DeleteGenericHandler<Amenity> deleteHandler,
                             GetGenericHandler<Amenity> getHandler,
                             GetListGenericHandler<Amenity> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAmenities() => Ok(await _getListHandler.Handle());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAmenity(int id)
    {
        var amenity = await _getHandler.Handle(id);
        return amenity != null ? Ok(amenity) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddAmenity([FromBody] Amenity amenity)
    {
        if (amenity == null) return BadRequest("Amenity cannot be null");
        await _addHandler.Handle(amenity);
        return CreatedAtAction(nameof(GetAmenity), new { id = amenity.AmenityId }, amenity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAmenity(int id, [FromBody] Amenity amenity)
    {
        if (id != amenity.AmenityId) return BadRequest("Amenity ID mismatch");
        await _updateHandler.Handle(amenity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAmenity(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}

