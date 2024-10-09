using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; 
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AddGenericHandler<Payment, PaymentCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Payment, PaymentUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Payment> _deleteHandler;
    private readonly GetGenericHandler<Payment, PaymentReadDto> _getHandler;
    private readonly GetListGenericHandler<Payment, PaymentReadDto> _getListHandler;

    public PaymentController(
        AddGenericHandler<Payment, PaymentCreateDto> addHandler,
        UpdateGenericHandler<Payment, PaymentUpdateDto> updateHandler,
        DeleteGenericHandler<Payment> deleteHandler,
        GetGenericHandler<Payment, PaymentReadDto> getHandler,
        GetListGenericHandler<Payment, PaymentReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Payment
    [HttpGet]
    public async Task<IActionResult> GetPayments() => Ok(await _getListHandler.Handle());

    // GET: api/Payment/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payment = await _getHandler.Handle(id);
        return payment != null ? Ok(payment) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Payment
    [HttpPost]
    public async Task<IActionResult> AddPayment([FromBody] PaymentCreateDto dto)
    {
        if (dto == null) return BadRequest("Payment cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetPayment), new { id = dto.PaymentMethod }, dto); // Adjust ID if necessary
    }

    // PUT: api/Payment/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentUpdateDto dto)
    {
        if (id != dto.PaymentId) return BadRequest("Payment ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Payment/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
