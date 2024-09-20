namespace StartMyNewApp.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public int BookingId { get; set; } // Foreign key to Booking
        public decimal TotalAmount { get; set; } // Ensure precision and scale defined in DbContext
        public string PaymentMethod { get; set; } = string.Empty; // Default value
        public string PaymentStatus { get; set; } = string.Empty; // Default value

        public virtual User? User { get; set; } // Make this nullable
        public virtual Booking? Booking { get; set; } // Make this nullable
    }
}


