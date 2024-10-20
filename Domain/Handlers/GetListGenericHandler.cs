using System.Collections.Generic;
using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper;

namespace StartMyNewApp.Domain.Handlers
{
    public class GetListGenericHandler<T, TReadDto> where T : class where TReadDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GetListGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TReadDto>> Handle()
        {
            var entities = await _repository.GetListAsync();
            var dtos = _mapper.Map<IEnumerable<TReadDto>>(entities);
            return dtos;
        }
    }
}

