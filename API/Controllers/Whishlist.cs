using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; 
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class WishlistController : ControllerBase
{
    private readonly AddGenericHandler<Wishlist, WishlistCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Wishlist, WishlistUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Wishlist> _deleteHandler;
    private readonly GetGenericHandler<Wishlist, WishlistReadDto> _getHandler;
    private readonly GetListGenericHandler<Wishlist, WishlistReadDto> _getListHandler;

    public WishlistController(
        AddGenericHandler<Wishlist, WishlistCreateDto> addHandler,
        UpdateGenericHandler<Wishlist, WishlistUpdateDto> updateHandler,
        DeleteGenericHandler<Wishlist> deleteHandler,
        GetGenericHandler<Wishlist, WishlistReadDto> getHandler,
        GetListGenericHandler<Wishlist, WishlistReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Wishlist
    [HttpGet]
    public async Task<IActionResult> GetWishlists() => Ok(await _getListHandler.Handle());

    // GET: api/Wishlist/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishlist(int id)
    {
        var wishlist = await _getHandler.Handle(id);
        return wishlist != null ? Ok(wishlist) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Wishlist
    [HttpPost]
    public async Task<IActionResult> AddWishlist([FromBody] WishlistCreateDto dto)
    {
        if (dto == null) return BadRequest("Wishlist cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetWishlist), new { id = dto.UserId }, dto); // Adjust based on ID usage
    }

    // PUT: api/Wishlist/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWishlist(int id, [FromBody] WishlistUpdateDto dto)
    {
        if (id != dto.WishlistId) return BadRequest("Wishlist ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Wishlist/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishlist(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
