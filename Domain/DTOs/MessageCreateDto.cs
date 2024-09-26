namespace StartMyNewApp.Domain.DTOs
{
    public class MessageCreateDto
    {
        public int SenderId { get; set; } // ID of the user sending the message
        public int ReceiverId { get; set; } // ID of the user receiving the message
        public string MessageBody { get; set; } = string.Empty; // Content of the message
    }
}
