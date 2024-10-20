namespace StartMyNewApp.Domain.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        // Fetches a list of all entities of type T
        Task<IEnumerable<T>> GetListAsync();

        // Fetch a single entity of type T by its ID, returns null if not found
        Task<T?> GetAsync(int id);  // Nullable return type to handle potential null results

        // Adds a new entity of type T to the database
        Task AddAsync(T entity);

        // Updates an existing entity of type T in the database
        Task UpdateAsync(T entity);

        // Deletes an entity of type T from the database
        Task DeleteAsync(T entity);
    }
}
