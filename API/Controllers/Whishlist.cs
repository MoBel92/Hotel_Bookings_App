using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class WishlistController : ControllerBase
{
    private readonly AddGenericHandler<Wishlist> _addHandler;
    private readonly UpdateGenericHandler<Wishlist> _updateHandler;
    private readonly DeleteGenericHandler<Wishlist> _deleteHandler;
    private readonly GetGenericHandler<Wishlist> _getHandler;
    private readonly GetListGenericHandler<Wishlist> _getListHandler;

    public WishlistController(AddGenericHandler<Wishlist> addHandler,
                              UpdateGenericHandler<Wishlist> updateHandler,
                              DeleteGenericHandler<Wishlist> deleteHandler,
                              GetGenericHandler<Wishlist> getHandler,
                              GetListGenericHandler<Wishlist> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetWishlists() => Ok(await _getListHandler.Handle());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishlist(int id)
    {
        var wishlist = await _getHandler.Handle(id);
        return wishlist != null ? Ok(wishlist) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddWishlist([FromBody] Wishlist wishlist)
    {
        if (wishlist == null) return BadRequest("Wishlist cannot be null");
        await _addHandler.Handle(wishlist);
        return CreatedAtAction(nameof(GetWishlist), new { id = wishlist.WishlistId }, wishlist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWishlist(int id, [FromBody] Wishlist wishlist)
    {
        if (id != wishlist.WishlistId) return BadRequest("Wishlist ID mismatch");
        await _updateHandler.Handle(wishlist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishlist(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}
