namespace StartMyNewApp.Domain.Queries
{
    public class FilteredListGenericQuery<T> where T : class
    {
        public Dictionary<string, (object value, string @operator)> Filters { get; set; }

        // Constructor to initialize filters
        public FilteredListGenericQuery(Dictionary<string, (object value, string @operator)> filters)
        {
            Filters = filters;
        }

        // Default constructor in case no filters are provided
        public FilteredListGenericQuery()
        {
            Filters = new Dictionary<string, (object value, string @operator)>();
        }

        // Add a filter dynamically
        public void AddFilter(string fieldName, object value, string @operator)
        {
            Filters[fieldName] = (value, @operator);
        }

        // Clear all filters
        public void ClearFilters()
        {
            Filters.Clear();
        }
    }
}
