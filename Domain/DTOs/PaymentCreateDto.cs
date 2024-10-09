namespace StartMyNewApp.Domain.DTOs
{
    public class PaymentCreateDto
    {
        public int UserId { get; set; } 
        public int BookingId { get; set; } 
        public decimal TotalAmount { get; set; } 
        public string PaymentMethod { get; set; } = string.Empty; // Method of payment (e.g., Credit Card, PayPal)
        public string PaymentStatus { get; set; } = "Pending"; // Default to Pending, can be updated later
    }
}

