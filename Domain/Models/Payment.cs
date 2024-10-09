namespace StartMyNewApp.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; } // Foreign key to User
        public int BookingId { get; set; } // Foreign key to Booking
        public decimal TotalAmount { get; set; } 
        public string PaymentMethod { get; set; } = string.Empty; 
        public string PaymentStatus { get; set; } = string.Empty; 

        public virtual User? User { get; set; } 
        public virtual Booking? Booking { get; set; } 
    }
}


