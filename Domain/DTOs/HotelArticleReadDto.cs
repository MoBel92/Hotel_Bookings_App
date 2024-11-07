    namespace StartMyNewApp.Domain.DTOs
    {
    public class HotelArticleReadDto
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

        // Property to hold paths of images associated with the hotel article
        public List<string> ImagePaths { get; set; } = new List<string>();

        // Owner/Admin details
        public int OwnerId { get; set; }
        public string OwnerName { get; set; } = string.Empty;

        // Related data (minimal as needed)
        public List<int> RoomIds { get; set; } = new List<int>();
        public List<int> CommentIds { get; set; } = new List<int>();
        public List<int> BookingIds { get; set; } = new List<int>();
        public List<int> AmenityIds { get; set; } = new List<int>();
    }
}

