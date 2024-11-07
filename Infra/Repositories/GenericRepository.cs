using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;
using DATA.Context;


namespace StartMyNewApp.Infra.Repositories
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
    }

    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            IQueryable<T> query = _context.Set<T>();

            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
            {
                query = query.Where(e => (e as ISoftDeletable)!.IsDeleted == false);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null || (entity is ISoftDeletable deletableEntity && deletableEntity.IsDeleted))
            {
                return null;
            }
            return entity;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            // Retrieve the ID property of the entity after saving
            var idProperty = typeof(T).GetProperty("IdUser") ?? typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new Exception("ID property not found on entity.");
            }

            // Return the ID value
            return (int)idProperty.GetValue(entity)!;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is ISoftDeletable deletableEntity)
            {
                deletableEntity.IsDeleted = true;
                _context.Set<T>().Update(entity);
            }
            else
            {
                _context.Set<T>().Remove(entity);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity != null && (!(entity is ISoftDeletable deletableEntity) || !deletableEntity.IsDeleted);
        }
    }
}

