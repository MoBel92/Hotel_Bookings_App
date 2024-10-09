namespace StartMyNewApp.Domain.DTOs
{
    public class PaymentUpdateDto
    {
        public int PaymentId { get; set; } 
        public string PaymentStatus { get; set; } = string.Empty; // Update the status of the payment (e.g., Completed, Failed)
    }
}

