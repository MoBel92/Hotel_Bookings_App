namespace StartMyNewApp.Domain.DTOs
{

    public class MessageReadDto
    {
        public int MessageId { get; set; } 
        public int SenderId { get; set; } 
        public int ReceiverId { get; set; } 
        public string MessageBody { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } 
        public bool IsRead { get; set; } 

        // Optional related data for display purposes
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty; 
    }



}