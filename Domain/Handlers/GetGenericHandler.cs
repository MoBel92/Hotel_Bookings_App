using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper;

namespace StartMyNewApp.Domain.Handlers
{
    public class GetGenericHandler<T, TReadDto> where T : class where TReadDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GetGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TReadDto?> Handle(int id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity == null)
            {
                return null; // Or throw an exception if you prefer.
            }

            var dto = _mapper.Map<TReadDto>(entity);
            return dto;
        }
    }
}
