namespace StartMyNewApp.Domain.Models
{
    public class Notification
    {
        public int NotificationId { get; set; } // Primary key
        public int UserId { get; set; } // Foreign key to User
        public string Message { get; set; } = string.Empty; // Notification content
        public DateTime CreatedAt { get; set; } = DateTime.Now; // When the notification was created
        public bool IsRead { get; set; } = false; // Read status of the notification

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}
