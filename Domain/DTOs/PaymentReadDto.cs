namespace StartMyNewApp.Domain.DTOs
{
    public class PaymentReadDto
    {
        public int PaymentId { get; set; } // Unique identifier for the payment
        public decimal TotalAmount { get; set; } // Total amount of the payment
        public string PaymentMethod { get; set; } = string.Empty; // Method of payment
        public string PaymentStatus { get; set; } = string.Empty; // Status of the payment

        // Optional: include minimal related information if needed
        public string Username { get; set; } = string.Empty; // Username of the user who made the payment
        public int BookingId { get; set; } // ID of the related booking, if needed for context
    }
}

