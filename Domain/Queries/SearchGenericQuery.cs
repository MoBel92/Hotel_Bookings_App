namespace StartMyNewApp.Domain.Queries
{
    public class SearchGenericQuery<T> where T : class
    {
        public string SearchTerm { get; set; } = string.Empty;

        public SearchGenericQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}