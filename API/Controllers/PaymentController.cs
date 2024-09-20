using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AddGenericHandler<Payment> _addHandler;
    private readonly UpdateGenericHandler<Payment> _updateHandler;
    private readonly DeleteGenericHandler<Payment> _deleteHandler;
    private readonly GetGenericHandler<Payment> _getHandler;
    private readonly GetListGenericHandler<Payment> _getListHandler;

    public PaymentController(AddGenericHandler<Payment> addHandler,
                             UpdateGenericHandler<Payment> updateHandler,
                             DeleteGenericHandler<Payment> deleteHandler,
                             GetGenericHandler<Payment> getHandler,
                             GetListGenericHandler<Payment> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetPayments() => Ok(await _getListHandler.Handle());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payment = await _getHandler.Handle(id);
        return payment != null ? Ok(payment) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddPayment([FromBody] Payment payment)
    {
        if (payment == null) return BadRequest("Payment cannot be null");
        await _addHandler.Handle(payment);
        return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
    {
        if (id != payment.PaymentId) return BadRequest("Payment ID mismatch");
        await _updateHandler.Handle(payment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}
