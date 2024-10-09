namespace StartMyNewApp.Domain.Interface  
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
