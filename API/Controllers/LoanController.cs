using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly AddGenericHandler<Loan> _addHandler;
    private readonly UpdateGenericHandler<Loan> _updateHandler;
    private readonly DeleteGenericHandler<Loan> _deleteHandler;
    private readonly GetGenericHandler<Loan> _getHandler;
    private readonly GetListGenericHandler<Loan> _getListHandler;

    public LoanController(
        AddGenericHandler<Loan> addHandler,
        UpdateGenericHandler<Loan> updateHandler,
        DeleteGenericHandler<Loan> deleteHandler,
        GetGenericHandler<Loan> getHandler,
        GetListGenericHandler<Loan> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Loan
    [HttpGet]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _getListHandler.Handle();
        return Ok(loans);
    }

    // GET: api/Loan/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLoan(int id)
    {
        var loan = await _getHandler.Handle(id);
        if (loan == null)
        {
            return NotFound();
        }
        return Ok(loan);
    }

    // POST: api/Loan
    [HttpPost]
    public async Task<IActionResult> AddLoan([FromBody] Loan loan)
    {
        await _addHandler.Handle(loan);
        return CreatedAtAction(nameof(GetLoan), new { id = loan.IdEmprunt }, loan);
    }

    // PUT: api/Loan/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLoan(int id, [FromBody] Loan loan)
    {
        if (id != loan.IdEmprunt)
        {
            return BadRequest("Loan ID mismatch");
        }

        await _updateHandler.Handle(loan);
        return NoContent();
    }

    // DELETE: api/Loan/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoan(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}
