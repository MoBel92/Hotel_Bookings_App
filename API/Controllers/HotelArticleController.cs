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

    public HotelArticleController(
        AddGenericHandler<HotelArticle, HotelArticleCreateDto> addHandler,
        UpdateGenericHandler<HotelArticle, HotelArticleUpdateDto> updateHandler,
        DeleteGenericHandler<HotelArticle> deleteHandler,
        GetGenericHandler<HotelArticle, HotelArticleReadDto> getHandler,
        GetListGenericHandler<HotelArticle, HotelArticleReadDto> getListHandler)
    {
        _addHandler = addHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
        _getListHandler = getListHandler;
    }

    // Helper to construct full image URLs
    private string GetFullImageUrl(string imagePath)
    {
        return $"{Request.Scheme}://{Request.Host}/uploads/{imagePath}";
    }

    // GET: api/HotelArticle?sortBy=city&order=asc
    [HttpGet]
    public async Task<IActionResult> GetHotelArticles(string? sortBy = null, string? order = "asc")
    {
        var hotelArticles = await _getListHandler.Handle() ?? Enumerable.Empty<HotelArticleReadDto>();

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

        // Convert stored image filenames to full URLs
        foreach (var article in hotelArticles)
        {
            article.ImagePaths = article.ImagePaths.Select(GetFullImageUrl).ToList();
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

        // Convert stored image filenames to full URLs
        hotelArticle.ImagePaths = hotelArticle.ImagePaths.Select(GetFullImageUrl).ToList();

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

        // Directory for uploaded images
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        // Handle the uploaded images
        List<string> imagePaths = new List<string>();
        if (dto.Images != null && dto.Images.Count > 0)
        {
            foreach (var formFile in dto.Images)
            {
                if (formFile.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    // Save the file to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    // Store only the filename
                    imagePaths.Add(uniqueFileName);
                }
            }
        }

        // Add the image paths (filenames) to the DTO
        dto.ImagePaths = imagePaths;

        // Call the handler to add the hotel article
        await _addHandler.Handle(dto);

        // Return a success response
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

        // Directory for uploaded images
        var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }

        // Handle the new images being uploaded
        List<string> newImagePaths = new List<string>();
        if (dto.NewImages != null && dto.NewImages.Count > 0)
        {
            foreach (var formFile in dto.NewImages)
            {
                if (formFile.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    // Save the file to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    // Store only the filename
                    newImagePaths.Add(uniqueFileName);
                }
            }
        }

        // Merge existing image paths with new ones
        dto.ImagePaths.AddRange(newImagePaths);

        // Call the handler to update the hotel article
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
}



