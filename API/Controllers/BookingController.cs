using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Commands;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly AddGenericHandler<Booking> _addHandler;
    private readonly UpdateGenericHandler<Booking> _updateHandler;
    private readonly DeleteGenericHandler<Booking> _deleteHandler;
    private readonly GetGenericHandler<Booking> _getHandler;
    private readonly GetListGenericHandler<Booking> _getListHandler;

    public BookingController(
        AddGenericHandler<Booking> addHandler,
        UpdateGenericHandler<Booking> updateHandler,
        DeleteGenericHandler<Booking> deleteHandler,
        GetGenericHandler<Booking> getHandler,
        GetListGenericHandler<Booking> getListHandler)
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
        if (booking == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(booking);
    }

    // POST: api/Booking
    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] AddBookingCommand command)
    {
        var booking = new Booking
        {
            UserId = command.UserId,
            HotelID = command.HotelID,
            CheckInDate = command.CheckInDate,
            CheckOutDate = command.CheckOutDate
        };

        await _addHandler.Handle(booking);
        return CreatedAtAction(nameof(GetBooking), new { id = booking.IdBooking }, booking); // Return 201 Created
    }

    // PUT: api/Booking/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingCommand command)
    {
        if (id != command.IdBooking)
        {
            return BadRequest("Booking ID mismatch"); // Return 400 Bad Request
        }

        var booking = new Booking
        {
            IdBooking = command.IdBooking,
            UserId = command.UserId,
            HotelID = command.HotelID,
            CheckInDate = command.CheckInDate,
            CheckOutDate = command.CheckOutDate
        };

        await _updateHandler.Handle(booking);
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
