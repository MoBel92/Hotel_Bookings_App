using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AddGenericHandler<Book> _addHandler;
    private readonly UpdateGenericHandler<Book> _updateHandler;
    private readonly DeleteGenericHandler<Book> _deleteHandler;
    private readonly GetGenericHandler<Book> _getHandler;
    private readonly GetListGenericHandler<Book> _getListHandler;

    public BookController(
        AddGenericHandler<Book> addHandler,
        UpdateGenericHandler<Book> updateHandler,
        DeleteGenericHandler<Book> deleteHandler,
        GetGenericHandler<Book> getHandler,
        GetListGenericHandler<Book> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Book
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _getListHandler.Handle();
        return Ok(books); // Return 200 OK with the list of books
    }

    // GET: api/Book/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _getHandler.Handle(id);
        if (book == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(book);
    }

    // POST: api/Book
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        await _addHandler.Handle(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book); // Return 201 Created
    }

    // PUT: api/Book/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
    {
        if (id != book.Id)
        {
            return BadRequest("Book ID mismatch"); // Return 400 Bad Request
        }

        await _updateHandler.Handle(book);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Book/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
