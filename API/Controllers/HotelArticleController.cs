using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs;
using System.Linq;
using StartMyNewApp.Domain.Models;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class HotelArticleController : ControllerBase
{
    private readonly AddGenericHandler<HotelArticle, HotelArticleCreateDto> _addHandler;
    private readonly UpdateGenericHandler<HotelArticle, HotelArticleUpdateDto> _updateHandler;
    private readonly DeleteGenericHandler<HotelArticle> _deleteHandler;
    private readonly GetGenericHandler<HotelArticle, HotelArticleReadDto> _getHandler;
    private readonly GetListGenericHandler<HotelArticle, HotelArticleReadDto> _getListHandler;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HotelArticleController(
        AddGenericHandler<HotelArticle, HotelArticleCreateDto> addHandler,
        UpdateGenericHandler<HotelArticle, HotelArticleUpdateDto> updateHandler,
        DeleteGenericHandler<HotelArticle> deleteHandler,
        GetGenericHandler<HotelArticle, HotelArticleReadDto> getHandler,
        GetListGenericHandler<HotelArticle, HotelArticleReadDto> getListHandler,
        IWebHostEnvironment webHostEnvironment)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET: api/HotelArticle
    [HttpGet]
    public async Task<IActionResult> GetHotelArticles(string? sortBy = null, string? order = "asc")
    {
        var hotelArticles = await _getListHandler.Handle() ?? Enumerable.Empty<HotelArticleReadDto>();

        // Add image paths for each hotel
        foreach (var hotel in hotelArticles)
        {
            hotel.ImagePaths = GetHotelImagePaths(hotel.HotelName);
        }

        // Sorting logic
        if (!string.IsNullOrEmpty(sortBy))
        {
            hotelArticles = sortBy.ToLower() switch
            {
                "city" => order.ToLower() == "desc"
                    ? hotelArticles.OrderByDescending(h => h.City ?? string.Empty)
                    : hotelArticles.OrderBy(h => h.City ?? string.Empty),
                "hotelstars" => order.ToLower() == "desc"
                    ? hotelArticles.OrderByDescending(h => h.HotelStars)
                    : hotelArticles.OrderBy(h => h.HotelStars),
                _ => hotelArticles
            };
        }

        return Ok(hotelArticles.ToList());
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

        // Add image paths for the specific hotel
        hotelArticle.ImagePaths = GetHotelImagePaths(hotelArticle.HotelName);

        return Ok(hotelArticle);
    }

    // POST: api/HotelArticle
    [HttpPost]
    public async Task<IActionResult> AddHotelArticle([FromForm] HotelArticleCreateDto dto)
    {
        if (dto == null)
        {
            return BadRequest("HotelArticle cannot be null");
        }

        // Call the handler to add the hotel article without processing images
        await _addHandler.Handle(dto);

        return CreatedAtAction(nameof(GetHotelArticle), new { id = dto.HotelName }, dto);
    }

    // PUT: api/HotelArticle/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotelArticle(int id, [FromForm] HotelArticleUpdateDto dto)
    {
        if (dto == null || id != dto.HotelID)
        {
            return BadRequest("Hotel Article ID mismatch or the article is null.");
        }

        await _updateHandler.Handle(dto);
        return NoContent();
    }

    // DELETE: api/HotelArticle/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotelArticle(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent();
    }

    // Helper method to get image paths for a hotel
    private List<string> GetHotelImagePaths(string hotelName)
    {
        if (string.IsNullOrWhiteSpace(hotelName))
        {
            return new List<string>(); // Return an empty list if the hotel name is invalid
        }

        var hotelImagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", hotelName);
        if (!Directory.Exists(hotelImagesFolder))
        {
            return new List<string>(); // Return an empty list if the folder does not exist
        }

        // Get all image files in the folder and return their filenames
        return Directory.GetFiles(hotelImagesFolder)
            .Select(filePath => Path.GetFileName(filePath)) // Extract filenames only
            .ToList();
    }
}





