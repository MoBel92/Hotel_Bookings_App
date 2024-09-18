namespace StartMyNewApp.Domain.Commands
{
    public class UpdateLocationCommand
    {
        public int IdLocation { get; set; } // The ID of the location to be updated
        public string LocationName { get; set; } = string.Empty; // Initialized to empty string

        // Constructor to initialize the command
        public UpdateLocationCommand(int idLocation, string locationName)
        {
            IdLocation = idLocation;
            LocationName = locationName;
        }
    }
}
