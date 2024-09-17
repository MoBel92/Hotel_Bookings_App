using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly AddGenericHandler<Person> _addHandler;
    private readonly UpdateGenericHandler<Person> _updateHandler;
    private readonly DeleteGenericHandler<Person> _deleteHandler;
    private readonly GetGenericHandler<Person> _getHandler;
    private readonly GetListGenericHandler<Person> _getListHandler;

    public PersonController(
        AddGenericHandler<Person> addHandler,
        UpdateGenericHandler<Person> updateHandler,
        DeleteGenericHandler<Person> deleteHandler,
        GetGenericHandler<Person> getHandler,
        GetListGenericHandler<Person> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Person
    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var persons = await _getListHandler.Handle();
        return Ok(persons);
    }

    // GET: api/Person/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await _getHandler.Handle(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    // POST: api/Person
    [HttpPost]
    public async Task<IActionResult> AddPerson([FromBody] Person person)
    {
        await _addHandler.Handle(person);
        return CreatedAtAction(nameof(GetPerson), new { id = person.IdPersonne }, person);
    }

    // PUT: api/Person/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
    {
        if (id != person.IdPersonne)
        {
            return BadRequest("Person ID mismatch");
        }

        await _updateHandler.Handle(person);
        return NoContent();
    }

    // DELETE: api/Person/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }
}
