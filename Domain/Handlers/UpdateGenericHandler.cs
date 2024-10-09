using System.Threading.Tasks;
using StartMyNewApp.Domain.Interface;
using AutoMapper; 

namespace StartMyNewApp.Domain.Handlers
{
    public class UpdateGenericHandler<T, TUpdateDto> where T : class where TUpdateDto : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper; // Inject AutoMapper for mapping DTO to model.

        public UpdateGenericHandler(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(TUpdateDto dto)
        {
            // Map the DTO to the domain model
            var entity = _mapper.Map<T>(dto);

            // Update the mapped entity in the repository
            await _repository.UpdateAsync(entity);
        }
    }
}
