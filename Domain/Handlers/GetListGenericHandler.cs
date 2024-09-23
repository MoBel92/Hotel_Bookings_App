using System.Collections.Generic;
using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper; // Assuming AutoMapper is used for mapping.

namespace StartMyNewApp.Domain.Handlers
{
    public class GetListGenericHandler<T, TReadDto> where T : class where TReadDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper; // Inject AutoMapper for mapping entities to DTOs.

        public GetListGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TReadDto>> Handle()
        {
            // Get the list of entities from the repository
            var entities = await _repository.GetListAsync();

            // Map the list of entities to a list of read DTOs
            var dtos = _mapper.Map<IEnumerable<TReadDto>>(entities);

            return dtos;
        }
    }
}
