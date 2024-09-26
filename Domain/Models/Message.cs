namespace StartMyNewApp.Domain.Models
{
    public class Message
    {
        public int MessageId { get; set; } // Primary key
        public int SenderId { get; set; } // Foreign key to User (sender)
        public int ReceiverId { get; set; } // Foreign key to User (receiver)
        public string MessageBody { get; set; } = string.Empty; // Content of the message
        public DateTime SentDate { get; set; } = DateTime.Now; // Date the message was sent
        public bool IsRead { get; set; } = false; // Read status of the message

        // Navigation properties
        public virtual User Sender { get; set; } = null!; // Navigation to sender
        public virtual User Receiver { get; set; } = null!; // Navigation to receiver
    }
}


