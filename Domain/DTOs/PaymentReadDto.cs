namespace StartMyNewApp.Domain.DTOs
{
    public class PaymentReadDto
    {
        public int PaymentId { get; set; } 
        public decimal TotalAmount { get; set; } 
        public string PaymentMethod { get; set; } = string.Empty; 
        public string PaymentStatus { get; set; } = string.Empty; 

        // Optional: include minimal related information if needed
        public string Username { get; set; } = string.Empty; 
        public int BookingId { get; set; }
    }
}

