namespace StartMyNewApp.Domain.DTOs
{
    public class NotificationUpdateDto
    {
        public int NotificationId { get; set; } 
        public bool IsRead { get; set; } = false; 
    }
}
