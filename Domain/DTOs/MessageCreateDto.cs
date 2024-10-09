namespace StartMyNewApp.Domain.DTOs
{
    public class MessageCreateDto
    {
        public int SenderId { get; set; } 
        public int ReceiverId { get; set; } 
        public string MessageBody { get; set; } = string.Empty; 
    }
}
