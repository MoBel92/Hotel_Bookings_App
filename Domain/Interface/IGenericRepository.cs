namespace StartMyNewApp.Domain.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T?> GetAsync(int id);
        Task<int> AddAsync(T entity); // Return the ID after adding
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> ExistsAsync(int id);
    }
}
