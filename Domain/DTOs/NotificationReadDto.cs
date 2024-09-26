namespace StartMyNewApp.Domain.DTOs
{
    public class NotificationReadDto
    {
        public int NotificationId { get; set; } // Primary key
        public string Message { get; set; } = string.Empty; // Notification content
        public DateTime CreatedAt { get; set; } = DateTime.Now; // When the notification was created
        public bool IsRead { get; set; } = false; // Read status of the notification
    }
}

