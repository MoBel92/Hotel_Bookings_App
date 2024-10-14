using Microsoft.AspNetCore.Http;
using System;
namespace StartMyNewApp.Domain.DTOs
{
    public class HotelArticleUpdateDto
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set; } = string.Empty;
        public int HotelStars { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Property to handle new uploaded images
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

        // Property to hold existing image paths
        public List<string> ImagePaths { get; set; } = new List<string>();
    }

}
