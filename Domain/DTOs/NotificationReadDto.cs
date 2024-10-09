namespace StartMyNewApp.Domain.DTOs
{
    public class NotificationReadDto
    {
        public int NotificationId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public bool IsRead { get; set; } = false; 
    }
}

