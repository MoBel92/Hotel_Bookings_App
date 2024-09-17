using System.Collections.Generic;
using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;

namespace StartMyNewApp.Domain.Handlers
{
    public class GetListGenericHandler<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GetListGenericHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> Handle()
        {
            // Get the list of entities from the repository
            return await _repository.GetListAsync();
        }
    }
}
