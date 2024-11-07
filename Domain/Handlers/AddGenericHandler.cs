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

            // Assuming the entity has a property named "IdUser" that represents the primary key.
            // Modify this to match your actual ID property if needed.
            var idProperty = typeof(T).GetProperty("IdUser");
            if (idProperty == null)
            {
                throw new Exception("Id property not found on entity.");
            }

            // Safely get the value and check if it's null before casting
            var idValue = idProperty.GetValue(entity);
            if (idValue == null)
            {
                throw new Exception("The Id value is null after adding the entity.");
            }

            return (int)idValue;
        }
    }
}
