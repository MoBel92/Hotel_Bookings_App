namespace StartMyNewApp.Domain.DTOs
{
    public class NotificationUpdateDto
    {
        public int NotificationId { get; set; } // Primary key
        public bool IsRead { get; set; } = false; // Updated read status of the notification
    }
}
