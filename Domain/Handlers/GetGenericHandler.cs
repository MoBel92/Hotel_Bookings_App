using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper; 

namespace StartMyNewApp.Domain.Handlers
{
    public class GetGenericHandler<T, TReadDto> where T : class where TReadDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper; // Inject AutoMapper for mapping the entity to the DTO.

        public GetGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TReadDto> Handle(int id)
        {
            // Fetch the entity by its ID
            var entity = await _repository.GetAsync(id);

            // Map the entity to the read DTO
            var dto = _mapper.Map<TReadDto>(entity);

            return dto;
        }
    }
}
