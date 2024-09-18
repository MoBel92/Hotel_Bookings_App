using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Commands;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly AddGenericHandler<Comment> _addHandler;
    private readonly UpdateGenericHandler<Comment> _updateHandler;
    private readonly DeleteGenericHandler<Comment> _deleteHandler;
    private readonly GetGenericHandler<Comment> _getHandler;
    private readonly GetListGenericHandler<Comment> _getListHandler;

    public CommentController(
        AddGenericHandler<Comment> addHandler,
        UpdateGenericHandler<Comment> updateHandler,
        DeleteGenericHandler<Comment> deleteHandler,
        GetGenericHandler<Comment> getHandler,
        GetListGenericHandler<Comment> getListHandler)
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
        if (comment == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(comment);
    }

    // POST: api/Comment
    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] AddCommentCommand command)
    {
        var comment = new Comment
        {
            Body = command.Body,
            HotelID = command.HotelID
        };

        await _addHandler.Handle(comment);
        return CreatedAtAction(nameof(GetComment), new { id = comment.IdComment }, comment); // Return 201 Created
    }

    // PUT: api/Comment/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentCommand command)
    {
        if (id != command.IdComment)
        {
            return BadRequest("Comment ID mismatch"); // Return 400 Bad Request
        }

        var comment = new Comment
        {
            IdComment = command.IdComment,
            Body = command.Body,
            HotelID = command.HotelID
        };

        await _updateHandler.Handle(comment);
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
