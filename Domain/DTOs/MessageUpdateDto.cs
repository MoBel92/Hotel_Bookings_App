namespace StartMyNewApp.Domain.DTOs
{
    public class MessageUpdateDto
    {
        public int MessageId { get; set; } // ID of the message to update
        public bool IsRead { get; set; } // Update the read status of the message
    }




}