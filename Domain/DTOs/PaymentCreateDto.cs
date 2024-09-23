namespace StartMyNewApp.Domain.DTOs
{
    public class PaymentCreateDto
    {
        public int UserId { get; set; } // ID of the user making the payment
        public int BookingId { get; set; } // ID of the associated booking
        public decimal TotalAmount { get; set; } // Total amount for the payment
        public string PaymentMethod { get; set; } = string.Empty; // Method of payment (e.g., Credit Card, PayPal)
        public string PaymentStatus { get; set; } = "Pending"; // Default to Pending, can be updated later
    }
}

