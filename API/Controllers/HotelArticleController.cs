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

    // PUT: api/HotelArticle/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotelArticle(int id, [FromForm] HotelArticleUpdateDto dto)
    {
        if (dto == null || id != dto.HotelID)
        {
            return BadRequest("Hotel Article ID mismatch or the article is null.");
        }

        // Ensure ImagePaths is initialized before processing
        dto.ImagePaths ??= new List<string>();

        // Process new images if provided
        if (dto.NewImages != null && dto.NewImages.Count > 0)
        {
            var imagesFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", dto.HotelName);
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            foreach (var image in dto.NewImages)
            {
                var filePath = Path.Combine(imagesFolderPath, image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                // Add the new image path to ImagePaths
                dto.ImagePaths.Add(image.FileName);
            }
        }

        // Ensure ImagePaths contains only valid paths
        dto.ImagePaths = dto.ImagePaths?.Where(path => !string.IsNullOrWhiteSpace(path)).ToList() ?? new List<string>();

        // Update the hotel article using the handler
        await _updateHandler.Handle(dto);
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

        // Generate full URLs for the images
        var baseUrl = $"{Request.Scheme}://{Request.Host}/images/{hotelName}/";
        return Directory.GetFiles(hotelImagesFolder)
            .Select(filePath => baseUrl + Path.GetFileName(filePath)) // Generate full URLs
            .ToList();
    }

    // Other existing methods (Get, Post, Delete, etc.) remain unchanged
}






