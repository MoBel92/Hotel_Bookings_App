namespace StartMyNewApp.Domain.DTOs
{

    public class MessageReadDto
    {
        public int MessageId { get; set; } // Primary key
        public int SenderId { get; set; } // ID of the sender
        public int ReceiverId { get; set; } // ID of the receiver
        public string MessageBody { get; set; } = string.Empty; // Content of the message
        public DateTime SentDate { get; set; } // Date the message was sent
        public bool IsRead { get; set; } // Read status

        // Optional related data for display purposes
        public string SenderName { get; set; } = string.Empty; // Name of the sender
        public string ReceiverName { get; set; } = string.Empty; // Name of the receiver
    }



}