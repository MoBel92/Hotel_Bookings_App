using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper;

namespace StartMyNewApp.Domain.Handlers
{
    public class AddGenericHandler<T, TDto> where T : class where TDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public AddGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _repository.AddAsync(entity);
        }
    }
}
