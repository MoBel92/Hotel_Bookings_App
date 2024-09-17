using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly AddGenericHandler<Reservation> _addHandler;
    private readonly UpdateGenericHandler<Reservation> _updateHandler;
    private readonly DeleteGenericHandler<Reservation> _deleteHandler;
    private readonly GetGenericHandler<Reservation> _getHandler;
    private readonly GetListGenericHandler<Reservation> _getListHandler;

    public ReservationController(
        AddGenericHandler<Reservation> addHandler,
        UpdateGenericHandler<Reservation> updateHandler,
        DeleteGenericHandler<Reservation> deleteHandler,
        GetGenericHandler<Reservation> getHandler,
        GetListGenericHandler<Reservation> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Reservation
    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var reservations = await _getListHandler.Handle();
        return Ok(reservations);
    }

    // GET: api/Reservation/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservation(int id)
    {
        var reservation = await _getHandler.Handle(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation);
    }

    // POST: api/Reservation
    [HttpPost]
    public async Task<IActionResult> AddReservation([FromBody] Reservation reservation)
    {
        await _addHandler.Handle(reservation);
        return CreatedAtAction(nameof(GetReservation), new { id = reservation.IdReservation }, reservation);
    }

    // PUT: api/Reservation/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation reservation)
    {
        if (id != reservation.IdReservation)
        {
            return BadRequest("Reservation ID mismatch");
        }

        await _updateHandler.Handle(reservation);
        return NoContent();
    }

    // DELETE: api/Reservation/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}
