using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;

namespace StartMyNewApp.Domain.Handlers
{
    public class GetGenericHandler<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GetGenericHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
