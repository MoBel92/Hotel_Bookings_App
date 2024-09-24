using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;

namespace StartMyNewApp.Domain.Handlers
{
    public class DeleteGenericHandler<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public DeleteGenericHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity != null)
                {
                    await _repository.DeleteAsync(entity);
                }
                else
                {
                    // Log or handle the case where the entity was not found
                    Console.WriteLine($"Entity with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or rethrow it as needed
                Console.WriteLine($"Error deleting entity: {ex.Message}");
                throw; // Optionally rethrow if you want to propagate the error
            }
        }

    }
}
