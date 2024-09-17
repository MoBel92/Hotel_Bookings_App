using Microsoft.EntityFrameworkCore;
using StartMyNewApp.Domain.Interface;  // Corrected namespace for IGenericRepository
using DATA.Context;  // Corrected namespace for AppDbContext

namespace StartMyNewApp.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext using DI
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        // Fetches a list of all entities of type T
        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Fetch a single entity of type T by its ID, throws an exception if not found
        public async Task<T> GetAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"{typeof(T).Name} with Id {id} not found.");
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

        // Deletes an entity of type T from the database
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
