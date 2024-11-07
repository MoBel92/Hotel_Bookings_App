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

        public async Task<int> Handle(TDto dto)
        {
            // Map DTO to entity and add to repository
            var entity = _mapper.Map<T>(dto);
            await _repository.AddAsync(entity);

            // Assuming the entity has a property named "Id" that represents the primary key.
            // You may need to modify this to match your actual ID property (e.g., "IdUser").
            var idProperty = typeof(T).GetProperty("IdUser");
            if (idProperty == null) throw new Exception("Id property not found on entity.");

            return (int)idProperty.GetValue(entity);
        }
    }
}
