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
            var entity = await _repository.GetAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}
