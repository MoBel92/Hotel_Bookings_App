namespace StartMyNewApp.Domain.Interface  // You can adjust the namespace to match your folder structure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetAsync(int id);  // No nullable return here, matches Solution Two
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
