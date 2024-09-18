namespace StartMyNewApp.Domain.Commands
{
    public class AddLocationCommand
    {
        public string LocationName { get; set; } = string.Empty; // Initialized to empty string

        // Constructor to initialize the command
        public AddLocationCommand(string locationName)
        {
            LocationName = locationName;
        }
    }
}

