﻿using Microsoft.AspNetCore.Mvc;
using StartMyNewApp.Domain.Handlers;
using StartMyNewApp.Domain.DTOs;
using System.Linq;
using StartMyNewApp.Domain.Models;
using Microsoft.AspNetCore.Http;
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
            return NotFound(); // Return 404 if not found
        }
        return Ok(hotelArticle); // Return 200 OK with the found hotel article
    }

    // POST: api/HotelArticle
    [HttpPost]
    public async Task<IActionResult> AddHotelArticle([FromForm] HotelArticleCreateDto dto)
    {
        if (dto == null)
        {
            return BadRequest("HotelArticle cannot be null");
        }

        // Ensure the "wwwroot/uploads" directory exists
        var uploadPath = Path.Combine("wwwroot", "uploads");
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath); // Create the directory if it doesn't exist
        }

        // Handle the uploaded images
        List<string> imagePaths = new List<string>();
        if (dto.Images != null && dto.Images.Count > 0)
        {
            foreach (var formFile in dto.Images)
            {
                if (formFile.Length > 0)
                {
                    // Define the path where the file will be stored
                    var filePath = Path.Combine(uploadPath, formFile.FileName);

                    // Save the file to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    // Store the relative path to the uploaded file (to be saved in the database)
                    imagePaths.Add("/uploads/" + formFile.FileName);
                }
            }
        }

        // Add the image paths to the DTO
        dto.ImagePaths = imagePaths;

        // Call the handler to add the hotel article
        await _addHandler.Handle(dto);

        // Return a success response
        return CreatedAtAction(nameof(GetHotelArticle), new { id = dto.HotelName }, dto);
    }

    // PUT: api/HotelArticle/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotelArticle(int id, [FromBody] HotelArticleUpdateDto dto)
    {
        if (dto == null || id != dto.HotelID)
        {
            return BadRequest("Hotel Article ID mismatch or the article is null"); // Return 400 Bad Request if IDs do not match
        }
        await _updateHandler.Handle(dto);
        return NoContent(); // Return 204 No Content
    }

    // DELETE: api/HotelArticle/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotelArticle(int id)
    {
        await _deleteHandler.Handle(id);
        return NoContent(); // Return 204 No Content
    }
}
