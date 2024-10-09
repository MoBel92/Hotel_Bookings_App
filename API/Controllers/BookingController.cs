using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; 
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly AddGenericHandler<Booking, BookingCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Booking, BookingUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Booking> _deleteHandler;
    private readonly GetGenericHandler<Booking, BookingReadDto> _getHandler;
    private readonly GetListGenericHandler<Booking, BookingReadDto> _getListHandler;

    public BookingController(
        AddGenericHandler<Booking, BookingCreateDto> addHandler,
        UpdateGenericHandler<Booking, BookingUpdateDto> updateHandler,
        DeleteGenericHandler<Booking> deleteHandler,
        GetGenericHandler<Booking, BookingReadDto> getHandler,
        GetListGenericHandler<Booking, BookingReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Booking
    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _getListHandler.Handle();
        return Ok(bookings); // Return 200 OK with the list of bookings
    }

    // GET: api/Booking/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var booking = await _getHandler.Handle(id);
        return booking != null ? Ok(booking) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Booking
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] BookingCreateDto dto)
    {
        if (dto == null) return BadRequest("Booking data cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetBooking), new { id = dto.UserId }, dto); // Adjust ID for the specific use case
    }

    // PUT: api/Booking/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDto dto)
    {
        if (id != dto.IdBooking) return BadRequest("Booking ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Booking/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
