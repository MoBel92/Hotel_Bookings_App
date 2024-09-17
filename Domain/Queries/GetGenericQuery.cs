namespace StartMyNewApp.Domain.Queries
{
    public class GetGenericQuery<T> where T : class
    {
        public int Id { get; set; }

        public GetGenericQuery(int id)
        {
            Id = id;
        }
    }
}
