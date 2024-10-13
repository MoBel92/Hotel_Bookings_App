using static System.Net.Mime.MediaTypeNames;
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

        // Property to hold uploaded images
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        // Property to hold saved image paths
        public List<string> ImagePaths { get; set; } = new List<string>();

        // Owner/Admin properties - optional now
        public int? OwnerId { get; set; } // Nullable OwnerId
    }
}
