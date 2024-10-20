using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;
using DATA.Context;


namespace StartMyNewApp.Infra.Repositories
{
    // Custom exception for entity not found scenarios
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }

    // Interface for soft deletable entities
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext using DI
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        // Fetches a list of all entities of type T, excluding soft-deleted ones if applicable
        public async Task<IEnumerable<T>> GetListAsync()
        {
            IQueryable<T> query = _context.Set<T>();

            // If the entity supports soft deletion, filter out deleted entities
            if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
            {
                query = query.Where(e => (e as ISoftDeletable).IsDeleted == false);
            }

            return await query.ToListAsync();
        }

        // Fetch a single entity of type T by its ID, throws an exception if not found
        public async Task<T> GetAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException($"{typeof(T).Name} with Id {id} not found.");
            }

            // Check if the entity is soft deleted and throw an exception if necessary
            if (entity is ISoftDeletable deletableEntity && deletableEntity.IsDeleted)
            {
                throw new EntityNotFoundException($"{typeof(T).Name} with Id {id} is deleted.");
            }

            return entity;
        }

        // Adds a new entity of type T to the database
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Updates an existing entity of type T in the database
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        // Soft delete or remove an entity of type T from the database
        public async Task DeleteAsync(T entity)
        {
            if (entity is ISoftDeletable deletableEntity)
            {
                // Perform a soft delete
                deletableEntity.IsDeleted = true;
                _context.Set<T>().Update(entity);
            }
            else
            {
                // Hard delete
                _context.Set<T>().Remove(entity);
            }

            await _context.SaveChangesAsync();
        }

        // Method to check if the entity exists in the database
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }
    }
}
