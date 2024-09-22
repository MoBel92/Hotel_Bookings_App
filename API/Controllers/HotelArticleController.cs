using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.Models;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class HotelArticleController : ControllerBase
{
    private readonly AddGenericHandler<HotelArticle> _addHandler;
    private readonly UpdateGenericHandler<HotelArticle> _updateHandler;
    private readonly DeleteGenericHandler<HotelArticle> _deleteHandler;
    private readonly GetGenericHandler<HotelArticle> _getHandler;
    private readonly GetListGenericHandler<HotelArticle> _getListHandler;

    public HotelArticleController(
        AddGenericHandler<HotelArticle> addHandler,
        UpdateGenericHandler<HotelArticle> updateHandler,
        DeleteGenericHandler<HotelArticle> deleteHandler,
        GetGenericHandler<HotelArticle> getHandler,
        GetListGenericHandler<HotelArticle> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // GET: api/HotelArticle?sortBy=city&order=asc
    [HttpGet]
    public async Task<IActionResult> GetHotelArticles(string? sortBy = null, string? order = "asc")
    {
        var hotelArticles = await _getListHandler.Handle();

        // Sorting logic
        if (!string.IsNullOrEmpty(sortBy))
        {
            hotelArticles = sortBy.ToLower() switch
            {
                "city" => order.ToLower() == "desc"
                    ? hotelArticles.OrderByDescending(h => h.City ?? string.Empty) // Use ?? to provide a default
                    : hotelArticles.OrderBy(h => h.City ?? string.Empty),
                "hotelstars" => order.ToLower() == "desc"
                    ? hotelArticles.OrderByDescending(h => h.HotelStars)
                    : hotelArticles.OrderBy(h => h.HotelStars),
                _ => hotelArticles // Default if sortBy is not recognized
            };
        }

        // Log the sorted result
        Console.WriteLine($"Sorted hotel articles: {string.Join(", ", hotelArticles.Select(h => h.HotelName + " - " + (h.City ?? "Unknown City")))}");

        return Ok(hotelArticles.ToList()); // Return 200 OK with the sorted list of hotel articles
    }



    // GET: api/HotelArticle/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotelArticle(int id)
    {
        var hotelArticle = await _getHandler.Handle(id);
        if (hotelArticle == null)
        {
            return NotFound(); 
        }
        return Ok(hotelArticle);
    }

    // POST: api/HotelArticle
    [HttpPost]
    public async Task<IActionResult> AddHotelArticle([FromBody] HotelArticle hotelArticle)
    {
        if (hotelArticle == null)
        {
            return BadRequest("HotelArticle cannot be null"); 
        }

        await _addHandler.Handle(hotelArticle);
        return CreatedAtAction(nameof(GetHotelArticle), new { id = hotelArticle.HotelID }, hotelArticle);
    }

    // PUT: api/HotelArticle/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotelArticle(int id, [FromBody] HotelArticle hotelArticle)
    {
        if (id != hotelArticle.HotelID)
        {
            return BadRequest("Hotel Article ID mismatch"); 
        }

        await _updateHandler.Handle(hotelArticle);
        return NoContent(); 
    }

    // DELETE: api/HotelArticle/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotelArticle(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); 
    }
}
