namespace StartMyNewApp.Domain.Queries
{
    public class FilteredListGenericQuery<T> where T : class
    {
        public Dictionary<string, object> Filters { get; set; } = new Dictionary<string, object>();

        public FilteredListGenericQuery(Dictionary<string, object> filters)
        {
            Filters = filters;
        }
    }
}