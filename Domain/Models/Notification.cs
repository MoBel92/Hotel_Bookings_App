namespace StartMyNewApp.Domain.Models
{
    public class Notification
    {
        public int NotificationId { get; set; } 
        public int UserId { get; set; } // Foreign key to User
        public string Message { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public bool IsRead { get; set; } = false; // Read status of the notification

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}
