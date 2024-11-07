using Microsoft.AspNetCore.Http;

namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleCreateDto
    {
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set; } = string.Empty;
        public int HotelStars { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Property to hold uploaded images as IFormFile for file uploads
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        // Optional property to store image paths after processing
        public List<string> ImagePaths { get; set; } = new List<string>();

        // Nullable property for the Owner/Admin creating the article
        public int? OwnerId { get; set; }
    }
}
