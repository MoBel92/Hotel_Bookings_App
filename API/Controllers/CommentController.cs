using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs; // Assuming DTOs are in this namespace
using StartMyNewApp.Domain.Models;
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly AddGenericHandler<Comment, CommentCreateDto> _addHandler;
    private readonly UpdateGenericHandler<Comment, CommentUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<Comment> _deleteHandler;
    private readonly GetGenericHandler<Comment, CommentReadDto> _getHandler;
    private readonly GetListGenericHandler<Comment, CommentReadDto> _getListHandler;

    public CommentController(
        AddGenericHandler<Comment, CommentCreateDto> addHandler,
        UpdateGenericHandler<Comment, CommentUpdateDto> updateHandler,
        DeleteGenericHandler<Comment> deleteHandler,
        GetGenericHandler<Comment, CommentReadDto> getHandler,
        GetListGenericHandler<Comment, CommentReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/Comment
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var comments = await _getListHandler.Handle();
        return Ok(comments); // Return 200 OK with the list of comments
    }

    // GET: api/Comment/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var comment = await _getHandler.Handle(id);
        return comment != null ? Ok(comment) : NotFound(); // Return 200 OK or 404 Not Found
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CommentCreateDto dto)
    {
        if (dto == null) return BadRequest("Comment cannot be null");
        await _addHandler.Handle(dto);
        return CreatedAtAction(nameof(GetComment), new { id = dto.HotelID }, dto); // Adjust ID if necessary
    }

    // PUT: api/Comment/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentUpdateDto dto)
    {
        if (id != dto.IdComment) return BadRequest("Comment ID mismatch"); // Return 400 Bad Request
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/Comment/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
