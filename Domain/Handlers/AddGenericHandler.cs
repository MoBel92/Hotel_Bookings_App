using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper; // Assuming you are using AutoMapper, add this reference.

namespace StartMyNewApp.Domain.Handlers
{
    public class AddGenericHandler<T, TDto> where T : class where TDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper; // Inject the mapper for DTO to model conversion.

        public AddGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(TDto dto)
        {
            // Map the DTO to the domain model
            var entity = _mapper.Map<T>(dto);

            // Add the mapped entity to the repository
            await _repository.AddAsync(entity);
        }
    }
}
